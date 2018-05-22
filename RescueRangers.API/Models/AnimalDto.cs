using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    public class AnimalDto
    {
        public int? Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "You must provide a name.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        public string Name { get; set; }

        /// <summary>
        /// Species
        /// </summary>
        [Required(ErrorMessage = "You must provide a species value.")]
        public string Species { get; set; }

        /// <summary>
        /// Image Url
        /// </summary>
        [Required(ErrorMessage = "You must provide an image URL.")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [Required(ErrorMessage = "You must provide a gender.")]
        public string Gender { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessage = "You must provide a description.")]
        public string Description { get; set; }

        /// <summary>
        /// Adoption Status (true or false)
        /// </summary>
        public bool IsAdopted{ get; set; }

        /// <summary>
        /// Shelter ID
        /// </summary>
        public uint ShelterId { get; set; }
     }
}
