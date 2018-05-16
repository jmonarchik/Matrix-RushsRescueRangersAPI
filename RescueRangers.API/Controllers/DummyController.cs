using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RescueRangers.API.Entities;

namespace RescueRangers.API.Controllers
{
    public class DummyController : Controller
    {
        private WebApiDbContext _ctx;

        public DummyController(WebApiDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDataBase()
        {
            return Ok();
        }
    }
}
