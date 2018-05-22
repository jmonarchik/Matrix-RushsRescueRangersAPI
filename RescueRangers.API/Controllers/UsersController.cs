using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpPost()]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            return Ok(user);
        }
    }
}
