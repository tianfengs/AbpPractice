using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Models
{
    public class Human
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [StringLength(11)]
        public string SocialSecurityNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
