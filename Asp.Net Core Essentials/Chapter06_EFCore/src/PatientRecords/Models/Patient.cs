using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRecords.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }
        [Display(Name = "Robot Doctor")]
        public int RobotDoctorId { get; set; }
        public RobotDoctor RobotDoctor { get; set; }

    }
}
