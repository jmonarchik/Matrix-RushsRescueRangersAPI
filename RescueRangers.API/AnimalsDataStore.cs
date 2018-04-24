using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API
{
    public class AnimalsDataStore
    {
        public static AnimalsDataStore Current { get; } = new AnimalsDataStore();

        private const bool V = false;

        public List<AnimalDto> Animals {get; set;}

        public AnimalsDataStore()
        {
            Animals = new List<AnimalDto>()
            {
                new AnimalDto() {
                    Id = 1,
                    Name = "Fluffy",
                    Species = "Dog",
                    ImageUrl = "https://i.imgur.com/eZwTsb6.jpg",
                    Gender = "M",
                    Description = "Quis nostrum exercitationem ullam corporis suscipit laboriosam cosmos shores.",
                    IsAdopted = V
                },
                new AnimalDto()
                {
                    Id = 2,
                    Name = "Pickles",
                    Species = "Cat",
                    ImageUrl = "https://i.imgur.com/zItMO7k.jpg",
                    Gender = "M",
                    Description = "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
                    IsAdopted = V
                },
                new AnimalDto()
                {
                    Id = 5,
                    Name = "Brenda",
                    Species = "Dog",
                    ImageUrl = "https://i.imgur.com/nTt8wvq.jpg",
                    Gender = "F",
                    Description = "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
                    IsAdopted = true
                },
                new AnimalDto()
                {
                    Id = 6,
                    Name = "Henry",
                    Species = "dog",
                    ImageUrl = "https://i.imgur.com/5V21pDS.jpg",
                    Gender = "M",
                    Description = "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
                    IsAdopted = V
                },
                new AnimalDto()
                {
                    Id = 7,
                    Name = "Cathy",
                    Species = "Cat",
                    ImageUrl = "https://i.imgur.com/zItMO7k.jpg",
                    Gender = "M",
                    Description = "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
                    IsAdopted = V
                },
                new AnimalDto()
                {
                    Id = 3,
                    Name = "Trigger",
                    Species = "Horse",
                    ImageUrl = "https://i.imgur.com/I7gvJ42.jpg",
                    Gender = "F",
                    Description = "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
                    IsAdopted = true
                },
                 new AnimalDto()
                {
                    Id = 4,
                    Name = "Chorky",
                    Species = "Pig",
                    ImageUrl = "https://i.imgur.com/qJ30HYJ.jpg",
                    Gender = "M",
                    Description = "Realm of the galaxies extraordinary claims require extraordinary evidence tingling of the spine inconspicuous",
                    IsAdopted = true
                }
            };
        }
    }
}
