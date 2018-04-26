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
        public uint Id { get; set; }

        [Required]
        public uint AnimalId { get; set; }

        [Required]
        public uint AdopterId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
