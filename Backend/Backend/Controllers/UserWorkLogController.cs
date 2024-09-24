using Backend.DTOs;
using Backend.Helpers;
using Backend.Logics;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserWorkLogController : ControllerBase
    {
        private IUserWorkLogLogic _logic;
        private MapperHelperService _mapper;

        public UserWorkLogController(IUserWorkLogLogic logic, MapperHelperService mapper)
        {
            _logic = logic;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserWorkLog>> GetUserWorkLogs()
        {
            return await _logic.ReadAsync();
        }

        [HttpGet("{userid}/{taskid}")]
        [Authorize]
        public async Task<UserWorkLog> GetUserWorkLogAsync(string userid, string taskid)
        {
            return await _logic.ReadAsync(userid, taskid);
        }

        [HttpGet("u/{userid}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserWorkLogDto>>> GetUsersWorkLogs(string userid)
        {
            var uwls = await _logic.GetUsersWorkLogsAsync(userid);

            var dtos = new List<UserWorkLogDto>();
            foreach (var uwl in uwls)
            {
                var dto = _mapper.MapUsersWorkLogsForStatistics(uwl);
                dtos.Add(dto);
            }

            return Ok(dtos);
        }

        [HttpGet("total/{userid}")]
        [Authorize]
        public async Task<ActionResult<double>> GetTotalWorkingTime(string userid)
        {
            var result = await _logic.GetTotalWorkTimeAsync(userid);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserWorkLogDto>> CreateUserWorkLogAsync([FromBody] CreateUserWorkLogDto createDto)
        {
            var uwl = await _logic.CreateAsync(createDto);

            var dto = _mapper.MapUserWorkLogDtoFromUserWorkLog(uwl);

            return Ok(dto);
        }

        /*
        [HttpDelete("{userid}/{taskid}")]
        [Authorize]
        public void DeleteUser(string userid, string taskid)
        {
            _logic.Delete(userid, taskid);
        }

        [HttpPut]
        [Authorize]
        public void UpdateUser([FromBody] UserWorkLog userWorkLog)
        {
            _logic.Update(userWorkLog);
        }
        */
    }
}
