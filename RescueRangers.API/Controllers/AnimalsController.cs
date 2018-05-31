using AutoMapper;
using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.Services;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RescueRangers.API.Controllers
{
    /// <summary>
    /// Animals Controller
    /// </summary>
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        private ILogger<AnimalsController> _logger;
        private IAnimalInfoRepository _animalInfoRepository;
        public AnimalsController
            (
            ILogger<AnimalsController> logger, 
            IAnimalInfoRepository animalInfoRepository
            )
        {
            _logger = logger;
            _animalInfoRepository = animalInfoRepository;
        }

        private void DeleteRelatedAdoptions(int animalId)
        {
            var relatedAdoptions = _animalInfoRepository.GetAdoptions().Where(adoption => adoption.AnimalId == animalId);
            foreach (var adoption in relatedAdoptions)
            {
                _animalInfoRepository.DeleteAdoption(adoption);
            }
        }

        /// <summary>
        /// Get All Animals
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animalEntities = _animalInfoRepository.GetAnimals();
            var results = Mapper.Map<IEnumerable<AnimalDto>>(animalEntities);

            return Ok(results);
        }

        /// <summary>
        /// Get a specific animal by its ID
        /// </summary>
        /// <param name="id">Animal ID</param>
        /// <returns>Animal with specified ID</returns>

        [HttpGet("{id}", Name = "GetAnimal")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animalInfoRepository.GetAnimal(id);
            if (animal == null)
            {
                _logger.LogInformation($"Animal with id {id} not found.");
                return NotFound($"Animal with id {id} not found.");
            }

            var animalToReturn = Mapper.Map<AnimalDto>(animal);
            return Ok(animalToReturn);
        }

        /// <summary>
        /// Create a new Animal
        /// </summary>
        /// <param name="animal">New Animal's information</param>
        /// <returns>Newly created animal</returns>

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] AnimalDto animal)

        {
            if (animal == null)
            {
                _logger.LogInformation($"No animal for creation. {animal} was provided.");
                return BadRequest($"No animal for creation. null was provided.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAnimal = Mapper.Map<Entities.Animal>(animal);
            _animalInfoRepository.AddAnimal(newAnimal);

            // If animal is successfully created, map the animal info to Data transfer Object to return
            if (!_animalInfoRepository.Save())
            {
                return StatusCode(500, $"{newAnimal} was not saved succesfully.");
            }

            var successfullyCreatedAnimal = Mapper.Map<Models.AnimalDto>(newAnimal);
            return CreatedAtRoute("GetAnimal", new { id = newAnimal.Id }, successfullyCreatedAnimal);
        }

        /// <summary>
        /// Update an animal's information
        /// </summary>
        /// <param name="id">Animal's ID</param>
        /// <param name="updatedAnimalInfo">Animal with updated information</param>
        /// <returns>Newly updated animal</returns>

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] AnimalDto updatedAnimalInfo )
        {
            if ( updatedAnimalInfo == null )
            {
                _logger.LogInformation($"Information needed to update animal. {updatedAnimalInfo} was provided.");
                return BadRequest();
            }
            if ( !ModelState.IsValid )
            {
                return BadRequest();
            }

            // Find the animal to update
            var currentAnimals = _animalInfoRepository.GetAnimals();
            var animalToUpdate = currentAnimals.FirstOrDefault(animal => animal.Id == id);
            if (animalToUpdate == null)
            {
                return NotFound();
            }

            // Map the new info to animal to be updated and save
            Mapper.Map(updatedAnimalInfo, animalToUpdate);
            if (!_animalInfoRepository.Save())
            {
                return StatusCode(500);
            }

            return Ok(animalToUpdate);
        }

        /// <summary>
        /// Delete an animal
        /// </summary>
        /// <param name="id">Animal's ID</param>
        /// <returns>Nothing</returns>

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalEntities = _animalInfoRepository.GetAnimals();
            var animalToDelete = animalEntities.FirstOrDefault(animal => animal.Id == id);
            if ( animalToDelete == null )
            {
                _logger.LogInformation($"Animal with id {id} not found.");
                return NotFound(); 
            }

            DeleteRelatedAdoptions(id);

            _animalInfoRepository.DeleteAnimal(animalToDelete);

            if (!_animalInfoRepository.Save())
            {
                _logger.LogInformation($"Deletion of {animalToDelete} unsuccessful.");
                return StatusCode(500);
            }

            return Ok();
        }


    }
}
