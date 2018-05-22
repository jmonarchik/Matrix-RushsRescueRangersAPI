using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    public class AdoptionDto
    {
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public int AdopterId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
