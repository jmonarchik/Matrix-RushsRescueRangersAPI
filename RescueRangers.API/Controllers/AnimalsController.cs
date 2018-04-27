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
            return Ok(DataStores.AnimalsDataStore.Current.Animals);
        }

        [HttpGet("{id}", Name = "GetAnimal")]
        public IActionResult GetAnimal(int id)
        {
            var animalToReturn = DataStores.AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);
            if (animalToReturn == null)
            {
                return NoContent();
            }
            return Ok(animalToReturn);
        }

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

            var AnimalToUpdate = DataStores.AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);


            if (AnimalToUpdate == null)
            {
                return NotFound();

            }

            AnimalToUpdate.Name = UpdatedAnimalInfo.Name;
            AnimalToUpdate.Species = UpdatedAnimalInfo.Species;
            AnimalToUpdate.ImageUrl = UpdatedAnimalInfo.ImageUrl;
            AnimalToUpdate.Gender = UpdatedAnimalInfo.Gender;
            AnimalToUpdate.Description = UpdatedAnimalInfo.Description;

            return Ok(AnimalToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalToDelete = DataStores.AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);
            if ( animalToDelete == null )
            {
                return NotFound(); 
            }
            DataStores.AnimalsDataStore.Current.Animals.Remove(animalToDelete);

            return NoContent();
        }
    }
}
