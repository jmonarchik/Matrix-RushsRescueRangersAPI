using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    public class AnimalForCreationDto
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool IsAdopted { get; set; }
        public uint ShelterId { get; set; }
    }
}
