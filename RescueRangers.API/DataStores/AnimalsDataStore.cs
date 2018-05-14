using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.DataStores
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
                    ImageUrl = "https://i.imgur.com/w6TFe5X.jpg",
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
                },
                 new AnimalDto()
                {
                    Id = 8,
                    Name = "Wishbone",
                    Species = "Dog",
                    ImageUrl = "https://i.imgur.com/cQrg37y.jpg",
                    Gender = "M",
                    Description = "Very well read.",
                    IsAdopted = false
                },
                  new AnimalDto()
                {
                    Id = 9,
                    Name = "Ezmeralda",
                    Species = "Dog",
                    ImageUrl = "https://i.imgur.com/rYVmcFk.jpg",
                    Gender = "F",
                    Description = "Very bad dog",
                    IsAdopted = true
                },
                  new AnimalDto()
                {
                    Id = 10,
                    Name = "Michelle",
                    Species = "Dog",
                    ImageUrl = "https://i.imgur.com/tSsZaew.jpg",
                    Gender = "F",
                    Description = "Very long dog",
                    IsAdopted = false
                },

                  new AnimalDto()
                {
                    Id = 11,
                    Name = "Chad",
                    Species = "Dog",
                    ImageUrl = "https://i.imgur.com/IatTsRr.jpg",
                    Gender = "M",
                    Description = "Good boy",
                    IsAdopted = false
                },
                  new AnimalDto()
                {
                    Id = 13,
                    Name = "Chelsea",
                    Species = "Pig",
                    ImageUrl = "https://i.imgur.com/RaksJVO.jpg",
                    Gender = "F",
                    Description = "Funny pig",
                    IsAdopted = false
                },
            };
        }
    }
}
