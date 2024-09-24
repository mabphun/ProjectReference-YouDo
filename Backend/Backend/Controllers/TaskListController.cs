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
using System.IdentityModel.Tokens.Jwt;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private ITaskListLogic _taskListLogic;
        private MapperHelperService _mapper;
        private IHubContext<NotificationHub> _hubContext;
        private IUserConnectionRepository _connections;

        public TaskListController(
            ITaskListLogic taskListLogic, 
            MapperHelperService mapper, 
            IHubContext<NotificationHub> hubContext,
            IUserConnectionRepository userConnectionRepository
        )
        {
            _taskListLogic = taskListLogic;
            _mapper = mapper;
            _hubContext = hubContext;
            _connections = userConnectionRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TaskListDto>>> GetTaskListsAsync()
        {
            try
            {
                var userid = User.GetUserId();
                if (userid == null)
                {
                    return BadRequest("Error! Request was denied because User is not found!");
                }
                var taskLists = await _taskListLogic.GetAuthorizedTaskListsAsync(userid);
                var taskListDtos = new List<TaskListDto>();
                foreach (var taskList in taskLists)
                {
                    var dto = _mapper.MapTaskListDtoFromTaskList(taskList);
                    taskListDtos.Add(dto);
                }

                return Ok(taskListDtos);
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
        public async Task<ActionResult<TaskListDto>> GetTaskListAsync(string id)
        {
            try
            {
                var userid = User.GetUserId();
                if (userid == null)
                {
                    return Unauthorized("Error! Request was denied because User is not found!");
                }
                var taskList = await _taskListLogic.GetAuthorizedTaskListAsync(userid, id);

                var dto = _mapper.MapTaskListDtoFromTaskList(taskList);


                return Ok(dto);
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
        public async Task<ActionResult<TaskListDto>> CreateTaskListAsync([FromBody] CreateTaskListDto createTaskListDto)
        {
            try
            {
                var taskList = await _taskListLogic.CreateAsync(createTaskListDto);

                var dto = _mapper.MapTaskListDtoFromTaskList(taskList);

                return Ok(dto);
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

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTaskListAsync(string id)
        {
            try
            {
                var userid = User.GetUserId();
                await _taskListLogic.DeleteAsync(id, userid);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return Unauthorized(JsonConvert.SerializeObject(e.Message));
            }
            catch(ArgumentException e)
            {
                return NotFound(JsonConvert.SerializeObject(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, JsonConvert.SerializeObject(e.Message));
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<TaskListDto>> UpdateTaskList([FromBody] UpdateTaskListDto taskListDto)
        {
            try
            {
                var updatedList = await _taskListLogic.UpdateAsync(taskListDto);

                var itemDto = _mapper.MapTaskListDtoFromTaskList(updatedList);

                var connectionIds = new List<string>();
                foreach (var member in itemDto.AssignedMembers)
                {
                    var connection = await _connections.Read(member.Id);
                    if (connection != null)
                    {
                        connectionIds.Add(connection.ConnectionId);
                    }
                }
                var userId = User.GetUserId();
                var user = itemDto.AssignedMembers.FirstOrDefault(x => x.Id == userId);
                var notification = new NotificationDto()
                {
                    InitiatorUser = user,
                    ItemId = itemDto.Id,
                    ItemType = "list",
                    ItemName = itemDto.Name,
                    Action = "updated",
                    Time = DateTime.UtcNow,
                };
                await _hubContext.Clients.Clients(connectionIds).SendAsync("TaskListUpdateResponse", notification);

                return Ok(itemDto);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(JsonConvert.SerializeObject(e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
