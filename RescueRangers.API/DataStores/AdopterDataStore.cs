using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.DataStores
{
    public class AdoptersDataStore
    {
        public static AdoptersDataStore Current { get; } = new AdoptersDataStore();

        public List<AdopterDto> Adopters { get; set; }
        public AdoptersDataStore() => Adopters = new List<AdopterDto>() { };
    }
}
