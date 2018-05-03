using System;
using System.Collections.Generic;
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
        public uint Id { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Street Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Zipcode
        /// </summary>
        public uint Zipcode { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNo { get; set; }
    }
}
