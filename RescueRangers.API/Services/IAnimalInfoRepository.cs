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

        Animal GetAnimal(int animalId);
    }
}
