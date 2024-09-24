using Backend.DTOs;
using Backend.Extensions;
using Backend.Logics;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChangeLogController : ControllerBase
    {
        private IChangeLogLogic _changeLogLogic;

        public ChangeLogController(IChangeLogLogic changeLogLogic)
        {
            _changeLogLogic = changeLogLogic;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ChangeLogDto>>> GetChangeLogsAsync()
        {
            try
            {
                var changeLogs = await _changeLogLogic.ReadAsync();

                List<ChangeLogDto> dtos = new List<ChangeLogDto>();

                foreach (var changeLog in changeLogs) 
                {
                    var dto = MapFromChangeLog(changeLog);
                    dtos.Add(dto);
                }

                return Ok(dtos.OrderByDescending(x=> x.ChangeDate));
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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ChangeLogDto>> GetChangeLogAsync(string id)
        {
            try
            {
                var changeLog = await _changeLogLogic.ReadAsync(id);

                var dto = MapFromChangeLog(changeLog);

                return Ok(dto);
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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ChangeLogDto>> CreateChangeLogAsync([FromBody] CreateChangeLogDto dto)
        {
            try
            {
                var changeLog = MapToChangeLog(dto);

                await _changeLogLogic.CreateAsync(changeLog);

                var createdChangeLog = await _changeLogLogic.ReadAsync(changeLog.Id);
                
                var changeLogDto = MapFromChangeLog(createdChangeLog);
                
                return Ok(changeLogDto);
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
        public async Task<ActionResult> DeleteChangeLogAsync(string id)
        {
            try
            {
                await _changeLogLogic.DeleteAsync(id);

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

        private ChangeLog MapToChangeLog(CreateChangeLogDto dto)
        {
            ChangeLog changeLog = new ChangeLog()
            {
                ChangeDate = DateTime.UtcNow,
                ChangerId = dto.ChangerId,

                TaskItemId = dto.TaskItemId,

                OldTitle = dto.OldTitle,
                OldDetails = dto.OldDetails,
                OldPriority = (TaskItemPriority)int.Parse(dto.OldPriority),
                OldDeadline = DateTime.Parse(dto.OldDeadline).ToUniversalTime(),
                OldAssigneeId = dto.OldAssigneeId,
                OldWorkflowItemId = dto.OldWorkflowItem.Id,


                NewTitle = dto.NewTitle,
                NewDetails = dto.NewDetails,
                NewPriority = (TaskItemPriority)int.Parse(dto.NewPriority),
                NewDeadline = DateTime.Parse(dto.NewDeadline).ToUniversalTime(),
                NewAssigneeId = dto.NewAssigneeId,
                NewWorkflowItemId = dto.NewWorkflowItem.Id,
            };

            return changeLog;
        }

        private ChangeLogDto MapFromChangeLog(ChangeLog changeLog)
        {
            ChangeLogDto dto = new ChangeLogDto()
            {
                Id = changeLog.Id,
                ChangeDate = changeLog.ChangeDate,
                TaskItemId = changeLog.TaskItemId,
                
                OldTitle = changeLog.OldTitle,
                OldDetails = changeLog.OldDetails,
                OldPriority = changeLog.OldPriority.ToString(),
                OldDeadline = changeLog.OldDeadline.ToString(),
                OldAssigneeId = changeLog.OldAssigneeId,
                NewTitle = changeLog.NewTitle,
                NewDetails = changeLog.NewDetails,
                NewPriority = changeLog.NewPriority.ToString(),
                NewDeadline = changeLog.NewDeadline.ToString(),
                NewAssigneeId = changeLog.NewAssigneeId,
            };
            var oldWorkflowItem = changeLog.TaskItem.WorkflowItems.FirstOrDefault(x => changeLog.OldWorkflowItemId == x.Id);
            if (oldWorkflowItem == null) throw new ArgumentException("Error! Couldn't find Old WorkflowItem!");
            dto.OldWorkflowItem = oldWorkflowItem;

            var newWorkflowItem = changeLog.TaskItem.WorkflowItems.FirstOrDefault(x => changeLog.NewWorkflowItemId == x.Id);
            if (newWorkflowItem == null) throw new ArgumentException("Error! Couldn't find New WorkflowItem!");
            dto.NewWorkflowItem = newWorkflowItem;

            var changerUser = changeLog.TaskItem.TaskList.AssignedMembers
                .Where(x=> x.AppUserId == changeLog.ChangerId)
                .Select(x=> x.AppUser)
                .FirstOrDefault();
            if (changerUser == null) throw new ArgumentException("Error! Couldn't find Changer User!");

            var changerUserDto = new AppUserDto()
            {
                Id = changerUser.Id,
                FirstName = changerUser.FirstName,
                LastName = changerUser.LastName,
                UserName = changerUser.UserName,
                Image = changerUser.Image,
            };
            dto.Changer = changerUserDto;

            var oldAssignee = changeLog.TaskItem.TaskList.AssignedMembers
                    .Where(x => x.AppUserId == changeLog.OldAssigneeId)
                    .Select(x => x.AppUser)
                    .FirstOrDefault();
            if (oldAssignee == null) throw new ArgumentException("Error! Couldn't find Changer User!");
            var oldAssigneeDto = new AppUserDto()
            {
                Id = oldAssignee.Id,
                FirstName = oldAssignee.FirstName,
                LastName = oldAssignee.LastName,
                UserName = oldAssignee.UserName,
                Image = oldAssignee.Image,
            };
            dto.OldAssignee = oldAssigneeDto;

            var newAssignee = changeLog.TaskItem.TaskList.AssignedMembers
                .Where(x => x.AppUserId == changeLog.NewAssigneeId)
                .Select(x => x.AppUser)
                .FirstOrDefault();
            if (newAssignee == null) throw new ArgumentException("Error! Couldn't find Changer User!");
            var newAssigneeDto = new AppUserDto()
            {
                Id = newAssignee.Id,
                FirstName = newAssignee.FirstName,
                LastName = newAssignee.LastName,
                UserName = newAssignee.UserName,
                Image = newAssignee.Image,
            };
            dto.NewAssignee = newAssigneeDto;

            return dto;
        }
    }
}
