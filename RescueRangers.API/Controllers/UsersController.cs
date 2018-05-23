using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.Models;
using RescueRangers.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IAnimalInfoRepository _animalInfoRepository;
        public UsersController
            (
            IAnimalInfoRepository animalInfoRepository
            )
        {
            _animalInfoRepository = animalInfoRepository;
        }

        [HttpPost()]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if ( user == null )
            {
                return BadRequest($"No user for creation. null was provided.");
            }
            var newUser = Mapper.Map<Entities.User>(user);
            _animalInfoRepository.AddUser(newUser);


            if (!_animalInfoRepository.Save())
            {
                return StatusCode(500, $"{newUser} was not saved succesfully.");
            }

            var successfullyCreatedAnimal = Mapper.Map<Models.UserDto>(newUser);
            return CreatedAtRoute("GetAnimal", new { id = newUser.UserId }, successfullyCreatedAnimal);

        }
    }
}
