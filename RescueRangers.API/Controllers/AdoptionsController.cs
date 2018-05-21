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

namespace RescueRangers.API.Controllers
{
    /// <summary>
    /// Adoptions Controller
    /// </summary>
    [Route("api/[controller]")]
    public class AdoptionsController : Controller
    {
        private IAnimalInfoRepository _animalInfoRepository;
        public AdoptionsController(IAnimalInfoRepository animalInfoRepository)
        {
            _animalInfoRepository = animalInfoRepository;
        }
        private Adopter newAdopter;
        private uint newAdopterId;
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
            animal.AdoptionId = newAdoption.Id;
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
        /// <param name="adoptionBody">Object containing adopter and animal objects</param>
        /// <returns>Adopted animal</returns>
        [HttpPost()]
        public IActionResult CreateAdoption([FromBody] AdoptionBody adoptionBody)
        {
            if (adoptionBody.Animal == null || adoptionBody.Adopter == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CreateAdopter(adoptionBody.Adopter);

            newAdoption = new Adoption()
            {
                AdopterId = newAdopterId,
                AnimalId = adoptionBody.Animal.Id,
                Date = DateTime.Today
            };

            _animalInfoRepository.AddAdoption(newAdoption);
            if (!_animalInfoRepository.Save())
            {
                return StatusCode(500);
            }

            var animalToUpdate = _animalInfoRepository.GetAnimal(adoptionBody.Animal.Id);
            if ( animalToUpdate == null )
            {
                return NotFound();
            }
            return UpdateAnimal(animalToUpdate);
        }

    }
}