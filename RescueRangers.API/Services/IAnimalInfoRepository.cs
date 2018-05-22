using RescueRangers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Services
{
    public interface IAnimalInfoRepository
    {
        IEnumerable<Animal> GetAnimals();

        Animal GetAnimal(uint animalId);
        void AddAnimal(Animal animal);
        void DeleteAnimal(Animal animal);
        IEnumerable<Adoption> GetAdoptions();
        IEnumerable<Adopter> GetAdopters();
        void AddAdoption(Adoption adoption);
        void DeleteAdoption(Adoption adoption);
        void AddAdopter(Adopter adopter);
        bool Save();
    }
}
