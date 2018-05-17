﻿using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RescueRangers.API.Controllers
{
    /// <summary>
    /// Animals Controller
    /// </summary>
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        private IAnimalInfoRepository _animalInfoRepository;
        public AnimalsController(IAnimalInfoRepository animalInfoRepository)
        {
            _animalInfoRepository = animalInfoRepository;
        }

        /// <summary>
        /// Get All Animals
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetAnimals()
        {
            var animalEntities = _animalInfoRepository.GetAnimals();
            var results = new List<AnimalDto>();
            foreach (var animalEntity in animalEntities)
            {
                results.Add(new AnimalDto
                {
                    Id = animalEntity.Id,
                    Gender = animalEntity.Gender,
                    Species = animalEntity.Species,
                    ImageUrl = animalEntity.ImageUrl,
                    Description = animalEntity.Description,
                    Name = animalEntity.Name
                });
            }

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
                return NotFound();
            }
            var animalToReturn = new AnimalDto()
            {
                Id = animal.Id,
                Gender = animal.Gender,
                Species = animal.Species,
                ImageUrl = animal.ImageUrl,
                Description = animal.Description,
                Name = animal.Name

            };

            return Ok(animalToReturn);
        }
        /// <summary>
        /// Create a new Animal
        /// </summary>
        /// <param name="Animal">New Animal's information</param>
        /// <returns>Newly created animal</returns>
        [HttpPost()]
        public IActionResult CreateAnimal([FromBody] AnimalForCreationDto Animal)

        {
            if (Animal == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var highestAnimalId = DataStores.AnimalsDataStore.Current.Animals.Max(animal => animal.Id);
            var newAnimal = new AnimalDto()
            {
                Id = ++highestAnimalId,
                Name = Animal.Name,
                Species = Animal.Species,
                ImageUrl = Animal.ImageUrl,
                Gender = Animal.Gender,
                Description = Animal.Description,
                IsAdopted = Animal.IsAdopted,
                ShelterId = Animal.ShelterId
            };

            DataStores.AnimalsDataStore.Current.Animals.Add(newAnimal);
            return CreatedAtRoute("GetAnimal", new { id = newAnimal.Id }, newAnimal);
        }
        /// <summary>
        /// Update an animal's information
        /// </summary>
        /// <param name="id">Animal's ID</param>
        /// <param name="UpdatedAnimalInfo">Animal with updated information</param>
        /// <returns>Newly updated animal</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] AnimalDto UpdatedAnimalInfo )
        {
            if ( UpdatedAnimalInfo == null )
            {
                return BadRequest();
            }
            if ( !ModelState.IsValid )
            {
                return BadRequest();
            }

            var animalToUpdate = DataStores.AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);


            if (animalToUpdate == null)
            {
                return NotFound();

            }

            animalToUpdate.Name = UpdatedAnimalInfo.Name;
            animalToUpdate.Species = UpdatedAnimalInfo.Species;
            animalToUpdate.ImageUrl = UpdatedAnimalInfo.ImageUrl;
            animalToUpdate.Gender = UpdatedAnimalInfo.Gender;
            animalToUpdate.Description = UpdatedAnimalInfo.Description;

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
            var animalToDelete = DataStores.AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);
            if ( animalToDelete == null )
            {
                return NotFound(); 
            }
            DataStores.AnimalsDataStore.Current.Animals.Remove(animalToDelete);

            return Ok();
        }
    }
}
