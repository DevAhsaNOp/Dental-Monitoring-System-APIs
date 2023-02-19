using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctor : ValidateUsersProfiles
    {
        [Required(ErrorMessage = "Provide your specialization")]
        [Display(Name = "Doctor Specialization")]
        public string DoctorSpecialization { get; set; }

        [Required(ErrorMessage = "Provide your locations")]
        [Display(Name = "Doctor locations")]
        public string DoctorLocation { get; set; }

        [Required(ErrorMessage = "Provide your Hospital/Clinic names")]
        [Display(Name = "Doctor Hospital/Clinic names")]
        public string DoctorHospitals { get; set; }

        [Required(ErrorMessage = "Provide your timings")]
        [Display(Name = "Doctor Timings")]
        public string DoctorTiming { get; set; }

        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        public virtual ICollection<tblDiagnostic> tblDiagnostics { get; set; }
    }
}
