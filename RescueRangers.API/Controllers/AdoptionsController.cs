using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.DataStores;

namespace RescueRangers.API.Controllers
{
    [Route("api/[controller]")]
    public class AdoptionsController : Controller
    {
        [HttpGet()]
        public IActionResult GetAdoptions()
        {
            return Ok(AdoptionsDataStore.Current.Adoptions);
        }

        [HttpPost()]
        public IActionResult CreateAdoption([FromBody] AdoptionBody AdoptionBody)
        {
            if (AdoptionBody.Animal == null || AdoptionBody.Adopter == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var currentAdopters = DataStores.AdoptersDataStore.Current.Adopters;

            uint HighestAdopterId;
            if (currentAdopters.Any())
            {
                HighestAdopterId = currentAdopters.Max(adopter => adopter.Id);
            } else
            {
                HighestAdopterId = 0;
            }
            
            var newAdopter = new AdopterDto()
            {
                Id = ++HighestAdopterId,
                FirstName = AdoptionBody.Adopter.FirstName,
                LastName = AdoptionBody.Adopter.LastName, 
                Address = AdoptionBody.Adopter.Address,
                City = AdoptionBody.Adopter.City,
                Zipcode = AdoptionBody.Adopter.Zipcode,
                PhoneNo = AdoptionBody.Adopter.PhoneNo
            };
            AdoptersDataStore.Current.Adopters.Add(newAdopter);

            var CurrentAdoptions = DataStores.AdoptionsDataStore.Current.Adoptions;
            uint HighestAdoptionId;

            if ( CurrentAdoptions.Any())
            {
                HighestAdoptionId = DataStores.AdoptionsDataStore.Current.Adoptions.Max(adoption => adoption.Id);
            } else
            {
                HighestAdoptionId = 0;
            }

            var newAdoption = new AdoptionDto()
            {
                Id = ++HighestAdoptionId,
                AdopterId = newAdopter.Id,
                AnimalId = AdoptionBody.Animal.Id,
                Date = DateTime.Today
            };
            AdoptionsDataStore.Current.Adoptions.Add(newAdoption);

            var animalToUpdate = AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == AdoptionBody.Animal.Id);
            if ( animalToUpdate == null )
            {
                return NotFound();
            }

            animalToUpdate.IsAdopted = true;
            animalToUpdate.AdoptionId = newAdoption.Id;

            return Ok(animalToUpdate);
        }
    }
}