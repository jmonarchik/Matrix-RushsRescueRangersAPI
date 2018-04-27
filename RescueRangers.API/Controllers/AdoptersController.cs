using RescueRangers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.DataStores;

namespace RescueRangers.API.Controllers
{
    [Route("api/[controller]")]
    public class AdoptersController : Controller
    {
        [HttpGet()]
        public IActionResult GetAdopters()
        {
            return Ok(AdoptersDataStore.Current.Adopters);
        }
    }
}
