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
        public Animal GetAnimal(uint animalId)
        {
            return _context.Animals.Where(animal => animal.Id == animalId).FirstOrDefault();
        }
        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
        }
        public void DeleteAnimal(Animal animal)
        {
            _context.Animals.Remove(animal);
        }
        public IEnumerable<Adoption> GetAdoptions()
        {
            return _context.Adoptions.ToList();
        }
        public void AddAdoption(Adoption adoption)
        {
            _context.Adoptions.Add(adoption);
        }
        public void DeleteAdoption(Adoption adoption)
        {
            _context.Adoptions.Remove(adoption);
        }
        public IEnumerable<Adopter> GetAdopters() 
        {
            return _context.Adopters.ToList();
        }
        public void AddAdopter(Adopter adopter)
        {
            _context.Adopters.Add(adopter);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
