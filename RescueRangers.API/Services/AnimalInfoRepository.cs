using RescueRangers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Services
{
    public class AnimalInfoRepository : IAnimalInfoRepository
    {
        private WebApiDbContext _context;
        public AnimalInfoRepository(WebApiDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals.OrderBy(animal => animal.Id).ToList();
        }
        public Animal GetAnimal(int animalId)
        {
            return _context.Animals.Where(animal => animal.Id == animalId).FirstOrDefault();
        }
    }
}
