using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RescueRangers.API.Controllers
{
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        [HttpGet()]
        public IActionResult GetAnimals()
        {
            return Ok(AnimalsDataStore.Current.Animals);
        }
        [HttpGet("{id}", Name = "GetAnimal")]
        public IActionResult GetAnimal(int id)
        {
            var animalToReturn = AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);
            if (animalToReturn == null)
            {
                return NoContent();
            }
            return Ok(animalToReturn);
        }
        [HttpPost()]
        public IActionResult CreateAnimal(
            [FromBody] AnimalForCreationDto Animal)
        {
            if(Animal == null)
            {
                return BadRequest();
            }
            var highestAnimalId = AnimalsDataStore.Current.Animals.Max(animal => animal.Id);
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
            AnimalsDataStore.Current.Animals.Add(newAnimal);
            return CreatedAtRoute("GetAnimal", new { id = newAnimal.Id }, newAnimal);
        }
    }
}
