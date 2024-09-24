using Backend.Extensions;
using Backend.Logics;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserTaskListController : ControllerBase
    {
        private IUserTaskListLogic _userTaskListLogic;
        private ITaskListLogic _taskListLogic;

        public UserTaskListController(IUserTaskListLogic logic, ITaskListLogic taskListLogic)
        {
            _userTaskListLogic = logic;
            _taskListLogic = taskListLogic;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserTaskList>> GetUserTaskListsAsync()
        {
            return await _userTaskListLogic.ReadAsync();
        }

        [HttpGet("{userid}/{listid}")]
        [Authorize]
        public async Task<UserTaskList> GetUserTaskListAsync(string userid, string listid)
        {
            return await _userTaskListLogic.ReadAsync(userid, listid);
        }

        [HttpPost]
        [Authorize]
        public void CreateUserTaskList([FromBody] UserTaskList userTaskList)
        {
            _userTaskListLogic.CreateAsync(userTaskList);
        }

        [HttpDelete("{userid}/{listid}")]
        [Authorize]
        public async Task<ActionResult> DeleteUserTaskList(string userid, string listid)
        {
            try
            {
                var currentUserId = User.GetUserId();
                var taskList = await _taskListLogic.ReadAsync(listid);
                if (currentUserId != taskList.CreatorId) return Unauthorized("Only the Creator of the list can modify list users!");

                await _userTaskListLogic.DeleteAsync(userid, listid);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
