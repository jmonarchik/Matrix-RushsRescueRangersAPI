using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    /// <summary>
    /// New Animal
    /// </summary>
    public class AnimalForCreationDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Species
        /// </summary>
        public string Species { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Adoption Status (true or false)
        /// </summary>
        public bool IsAdopted { get; set; }
        /// <summary>
        /// Shelter ID
        /// </summary>
        public uint ShelterId { get; set; }
    }
}
