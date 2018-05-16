using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RescueRangers.API.Entities
{
    public class Adoption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }
        [Required]
        [ForeignKey("AdopterId")]
        public int AdopterId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
