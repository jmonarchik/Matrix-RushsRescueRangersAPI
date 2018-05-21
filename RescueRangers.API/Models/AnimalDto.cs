using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    public class AnimalDto
    {
        public uint Id { get; set; }

        [Required(ErrorMessage = "You must provide a name.")]
        [MinLength(2, ErrorMessage ="Name must be at least 2 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a species value.")]
        public string Species { get; set; }

        [Required(ErrorMessage = "You must provide an image URL.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "You must provide a gender.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "You must provide a description.")]
        public string Description { get; set; }
        public bool IsAdopted{ get; set; }
        public uint? AdoptionId { get; set; }
        public uint ShelterId { get; set; }
     }
}
