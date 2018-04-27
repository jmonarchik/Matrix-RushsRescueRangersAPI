using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.DataStores
{
    public class AdoptionsDataStore
    {
        public static AdoptionsDataStore Current { get; } = new AdoptionsDataStore();

        public List<AdoptionDto> Adoptions { get; set; }
        public AdoptionsDataStore() => Adoptions = new List<AdoptionDto>() { };
    }
}
