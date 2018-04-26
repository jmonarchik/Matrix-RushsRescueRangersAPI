using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    public class AdoptionBody
    {
        public AnimalDto Animal { get; set; }
        public AdopterDto Adopter { get; set; }
    }
}
