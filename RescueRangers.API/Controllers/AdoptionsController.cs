using RescueRangers.API.Services;
using AutoMapper;
using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.DataStores;
using RescueRangers.API.Entities;
using Microsoft.Extensions.Logging;

namespace RescueRangers.API.Controllers
{
    /// <summary>
    /// Adoptions Controller
    /// </summary>
    [Route("api/[controller]")]
    public class AdoptionsController : Controller
    {
        private IAnimalInfoRepository _animalInfoRepository;
        private ILogger<AdoptionsController> _logger;
        public AdoptionsController(IAnimalInfoRepository animalInfoRepository, ILogger<AdoptionsController> logger)
        {
            _animalInfoRepository = animalInfoRepository;
            _logger = logger;
        }
        private Adopter newAdopter;
        private int newAdopterId;
        private Adoption newAdoption;

        private void CreateAdopter(AdopterDto adopter)
        {
            var currentAdopters = _animalInfoRepository.GetAdopters();
            newAdopter = Mapper.Map<Adopter>(adopter);
            _animalInfoRepository.AddAdopter(newAdopter);

            if (_animalInfoRepository.Save())
            {
                newAdopterId = newAdopter.Id;
            }
        }
        private IActionResult UpdateAnimal(Animal animal)
        {
            animal.IsAdopted = true;
            var animalToReturn = Mapper.Map<AnimalDto>(animal);
            return Ok(animal);
        }

        /// <summary>
        /// Get all adoptions
        /// </summary>
        /// <returns>Array of adoptions</returns>
        /// 
        [HttpGet()]
        public IActionResult GetAdoptions()
        {
            var adoptionEntities = _animalInfoRepository.GetAdoptions();
            var results = Mapper.Map<IEnumerable<AdoptionDto>>(adoptionEntities);
            return Ok(results);
        }

        /// <summary>
        /// Create a new adoption
        /// </summary>
        /// <param name="adoptionObject">Object containing adopter and animal objects</param>
        /// <returns>Adopted animal</returns>
        [HttpPost()]
        public IActionResult CreateAdoption([FromBody] AdoptionObject adoptionObject)
        {
            if (adoptionObject.Animal == null || adoptionObject.Adopter == null)
            {
                _logger.LogInformation($"Animal: {adoptionObject.Animal}, Adopter: {adoptionObject.Adopter} provided. Neither can be null.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Model state not valid. Message - {ModelState}");
                return BadRequest(ModelState);
            }

            CreateAdopter(adoptionObject.Adopter);

            newAdoption = new Adoption()
            {
                AdopterId = newAdopterId,
                AnimalId = adoptionObject.Animal.Id.GetValueOrDefault(),
                Date = DateTime.Today
            };

            _animalInfoRepository.AddAdoption(newAdoption);
            if (!_animalInfoRepository.Save())
            {
                _logger.LogInformation($"{newAdoption} not successfully saved.");
                return StatusCode(500);
            }

            var animalToUpdate = _animalInfoRepository.GetAnimal(adoptionObject.Animal.Id.GetValueOrDefault());
            if ( animalToUpdate == null )
            {
                _logger.LogInformation($"No animal found with id {adoptionObject.Animal.Id}");
                return NotFound();
            }
            return UpdateAnimal(animalToUpdate);
        }
    }
}