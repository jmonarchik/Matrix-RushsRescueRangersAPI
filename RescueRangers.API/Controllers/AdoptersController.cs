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
    /// <summary>
    /// Adopters controller
    /// </summary>
    [Route("api/[controller]")]
    public class AdoptersController : Controller
    {
        /// <summary>
        /// Get all adopters
        /// </summary>
        /// <returns>Array of current adopters</returns>
        [HttpGet()]
        public IActionResult GetAdopters()
        {
            return Ok(AdoptersDataStore.Current.Adopters);
        }
    }
}
