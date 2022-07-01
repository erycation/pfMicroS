
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Get/name/{username}")]
        public UserDto GetUserByUsername(string username)
        {
            return _userService.GetUserByUsername(username);
        }

        [HttpGet("Application/Section/{userId}")]
        public UserApplicationSectionDto GetUserByUsername(int userId)
        {
            return _userService.GetUserApplicationSectionById(userId);
        }

        [HttpGet("Get/{userId}")]
        public UserDto GetUserById(int userId)
        {
            return _userService.GetUserById(userId);
        }

        [HttpGet("GetAll/{unitId}")]
        public List<UserDto> GetUsersByUnitsId(int unitId)
        {
            return _userService.GetUsersByUnitsId(unitId);
        }

        [HttpGet("GetAll")]
        public List<UserDto> GetAllUser([FromQuery] RequestUser requestUser)
        {
            return _userService.GetAllUser(requestUser);
        }

        [HttpGet("Titles")]
        public List<TitleDto> GetUserTitle()
        {
            return _userService.GetUserTitle();
        }

        [HttpPost("Add/{permisionGroupId}")]
        public IActionResult Add([FromBody] User user, int permisionGroupId)
        {
            var responseUser = _userService.AddUser(user, permisionGroupId);
            return Ok(new { message = $"User {responseUser.Username} is successfully added" , data = responseUser} );
        }

        [HttpPost("Update")]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return Ok(new { message = $"User details for {userDto.Username} is successfully updated"});
        }
    }
}
