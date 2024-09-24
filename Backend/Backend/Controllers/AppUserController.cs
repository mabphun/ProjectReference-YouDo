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
    public class AppUserController : ControllerBase
    {
        private IAppUserLogic _logic;
        private MapperHelperService _mapper;

        public AppUserController(IAppUserLogic logic, MapperHelperService mapper)
        {
            _logic = logic;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AppUserDto>>> GetAppUsers()
        {
            var users = await _logic.ReadAsync();

            var dtos = new List<AppUserDto>();
            foreach (var user in users) 
            { 
                var dto = _mapper.MapAppUserDtoFromAppUser(user);
                dtos.Add(dto);
            }

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppUserDto>> GetAppUser(string id)
        {
            try
            {
                var user = await _logic.ReadAsync(id);

                var dto = _mapper.MapAppUserDtoFromAppUser(user);

                return dto;
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
        public void CreateUser([FromBody] AppUser user)
        {
            _logic.Create(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void DeleteUser(string id)
        {
            _logic.Delete(id);
        }

        [HttpPut]
        [Authorize]
        public void UpdateUser([FromBody] AppUser user)
        {
            _logic.Update(user);
        }
    }
}
