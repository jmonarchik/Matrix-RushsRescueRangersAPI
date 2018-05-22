using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Entities
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool? IsAdopted { get; set; }
        public int? ShelterId { get; set; }
    }
}
