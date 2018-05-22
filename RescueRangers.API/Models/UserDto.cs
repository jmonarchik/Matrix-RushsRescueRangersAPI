using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RescueRangers.API.Models
{
    public class UserDto
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
