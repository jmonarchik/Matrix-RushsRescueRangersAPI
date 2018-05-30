using AutoMapper;
using RescueRangers.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RescueRangers.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RescueRangers.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if ( user == null )
            {
                return BadRequest("No user for creation. null was provided.");
            }
            var newUser = Mapper.Map<Entities.User>(user);
            _userRepository.AddUser(newUser);

            if (!_userRepository.Save())
            {
                return StatusCode(500, $"{newUser} was not saved succesfully.");
            }

            var successfullyCreatedUser = Mapper.Map<Models.UserDto>(newUser);
            return Ok(successfullyCreatedUser);

        }

        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] LoginRequestDto loginRequest)
        {
            if ( loginRequest == null )
            {
                return BadRequest("Not a valid login request.");
            }

            var allUsers = _userRepository.GetUsers();
            var userToLogin = allUsers.FirstOrDefault(user => user.UserName == loginRequest.Username);
            if ( userToLogin == null )
            {
                return NotFound();
            }
            if ( userToLogin.Password != loginRequest.Password )
            {
                return Unauthorized();
            }

            return Ok(userToLogin);
        }
    }
}
