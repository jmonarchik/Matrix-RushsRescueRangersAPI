using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Models
{
    /// <summary>
    /// AdopterDTO
    /// </summary>
    public class AdopterDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        [Required(ErrorMessage="You must provide a First Name.")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        [Required(ErrorMessage="You must provide a Last Name.")]
        public string LastName { get; set; }
        /// <summary>
        /// Street Address
        /// </summary>
        [Required(ErrorMessage = "You must provide an Address.")]
        public string Address { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [Required(ErrorMessage = "You must provide a City.")]
        public string City { get; set; }
        /// <summary>
        /// State
        /// </summary>
        [Required(ErrorMessage = "You must provide a State.")]
        public string State { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        [Required(ErrorMessage = "You must provide a Postal Code")]
        public int PostalCode { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        [Required(ErrorMessage = "You must provide a Phone Number.")]
        public string PhoneNo { get; set; }
    }
}
