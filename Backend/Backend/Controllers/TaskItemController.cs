using Backend.Data;
using Backend.DTOs;
using Backend.Extensions;
using Backend.Helpers;
using Backend.Hubs;
using Backend.Logics;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private ITaskItemLogic _logic;
        private MapperHelperService _mapper;
        private IUserConnectionRepository _connections;
        private IHubContext<NotificationHub> _hubContext;

        public TaskItemController(ITaskItemLogic logic, MapperHelperService mapper, IUserConnectionRepository userConnectionRepository, IHubContext<NotificationHub> hubContext)
        {
            _logic = logic;
            _mapper = mapper;
            _connections = userConnectionRepository;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            try
            {
                var taskItems = await _logic.ReadAsync();

                return Ok(taskItems);
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(JsonConvert.SerializeObject(e.Message));
            }
            catch (ArgumentException e)
            {
                return NotFound(JsonConvert.SerializeObject(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TaskItemDto>> GetTaskItemAsync(string id)
        {
            try
            {
                var taskItem = await _logic.ReadAsync(id);

                if (taskItem == null) return BadRequest("Error! No task item with this id: " + id);

                var itemDto = _mapper.MapTaskItemDtoFromTaskItem(taskItem);

                return Ok(itemDto);
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(JsonConvert.SerializeObject(e.Message));
            }
            catch (ArgumentException e)
            {
                return NotFound(JsonConvert.SerializeObject(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }
        }

        [HttpGet("c/{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskItemCreatedByUserAsync(string id)
        {
            try
            {
                var taskItems = await _logic.GetCreatedTaskItems(id);

                if (taskItems == null) return Ok(new List<TaskItemDto>());

                List<TaskItemDto> dtos = new List<TaskItemDto>();
                foreach (var task in taskItems)
                {
                    var dto = _mapper.MapTaskItemDtoFromTaskItem(task);
                    dtos.Add(dto);
                }

                return Ok(dtos);
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(JsonConvert.SerializeObject(e.Message));
            }
            catch (ArgumentException e)
            {
                return NotFound(JsonConvert.SerializeObject(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }
        }

        [HttpGet("wf/{order}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAuthorizedTaskItemsBySpecifiedWorkflow(int order)
        {
            try
            {
                var userid = User.GetUserId();
                var result = await _logic.GetAuthorizedTaskItemsBySpecifiedWorkflowAsync(userid, order);

                List<TaskItemDto> dtos = new List<TaskItemDto>();
                foreach (var task in result)
                {
                    var dto = _mapper.MapTaskItemDtoFromTaskItem(task);
                    dtos.Add(dto);
                }

                return Ok(dtos);
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(JsonConvert.SerializeObject(e.Message));
            }
            catch (ArgumentException e)
            {
                return NotFound(JsonConvert.SerializeObject(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TaskItemDto>> CreateTaskItem([FromBody] CreateTaskItemDto createItemDto)
        {
            try
            {
                var taskItem = await _logic.CreateAsync(createItemDto);

                var itemDto = _mapper.MapTaskItemDtoFromTaskItem(taskItem);

                var connectionIds = new List<string>();
                foreach (var member in itemDto.TaskList.AssignedMembers)
                {
                    var connection = await _connections.Read(member.Id);
                    if (connection != null)
                    {
                        connectionIds.Add(connection.ConnectionId);
                    }
                }

                var userId = User.GetUserId();
                var user = itemDto.TaskList.AssignedMembers.FirstOrDefault(x => x.Id == userId);
                var notification = new NotificationDto()
                {
                    InitiatorUser = user,
                    ItemId = itemDto.Id,
                    ItemType = "task",
                    ItemName = itemDto.Title,
                    Action = "created",
                    Time = DateTime.UtcNow,
                };

                await _hubContext.Clients.Clients(connectionIds).SendAsync("TaskItemCreatedResponse", notification);

                return Ok(itemDto);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTaskItemAsync(string id)
        {
            try
            {
                var userId = User.GetUserId();
                var taskItem = await _logic.ReadAsync(id);
                if (taskItem.CreatorId != userId)
                    return Unauthorized("Only the creator of the task can delete it.");
                await _logic.DeleteAsync(id);

                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<TaskItem>> UpdateTaskItem([FromBody] UpdateTaskItemDto taskItemDto)
        {
            try
            {
                var updatedItem = await _logic.UpdateAsync(taskItemDto);

                var itemDto = _mapper.MapTaskItemDtoFromTaskItem(updatedItem);
                
                var connectionIds = new List<string>();
                foreach (var member in itemDto.TaskList.AssignedMembers)
                {
                    var connection = await _connections.Read(member.Id);
                    if (connection != null)
                    {
                        connectionIds.Add(connection.ConnectionId);
                    }
                }
                
                var userId = User.GetUserId();
                var user = itemDto.TaskList.AssignedMembers.FirstOrDefault(x => x.Id == userId);
                var notification = new NotificationDto()
                {
                    InitiatorUser = user,
                    ItemId = itemDto.Id,
                    ItemType = "task",
                    ItemName = itemDto.Title,
                    Action = "updated",
                    Time = DateTime.UtcNow,
                };
                
                await _hubContext.Clients.Clients(connectionIds).SendAsync("TaskItemUpdateResponse", notification);

                return Ok(itemDto);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
