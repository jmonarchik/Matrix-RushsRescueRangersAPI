using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.DataStores;
using RescueRangers.API.Entities;
using RescueRangers.API.Services;


namespace RescueRangers.API.Controllers
{
    /// <summary>
    /// Adopters controller
    /// </summary>
    [Route("api/[controller]")]
    public class AdoptersController : Controller
    {
        private IAnimalInfoRepository _animalInfoRepository;
        public AdoptersController(IAnimalInfoRepository animalInfoRepository)
        {
            _animalInfoRepository = animalInfoRepository;
        }

        /// <summary>
        /// Get all adopters
        /// </summary>
        /// <returns>Array of current adopters</returns>
        [HttpGet()]
        public IActionResult GetAdopters()
        {
            return Ok(_animalInfoRepository.GetAdopters());
        }
    }
}
