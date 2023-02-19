using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctor : ValidateUsersProfiles
    {
        [Required(ErrorMessage = "Provide your specialization")]
        [Display(Name = "Doctor Specialization")]
        public string DoctorSpecialization { get; set; }

        [Required(ErrorMessage = "Provide your year of experience")]
        [Display(Name = "Year Of Experience")]
        public string D_YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Provide your offered services")]
        [Display(Name = "Offered Services")]
        public string D_OfferedServices { get; set; }

        [Required(ErrorMessage = "Provide your work phone number")]
        [Display(Name = "Work Phone Number")]
        public string D_WorkPhoneNumber { get; set; }

        [Display(Name = "Awards and Achievements")]
        public string D_AwardsAndAchievements { get; set; }

        [Required(ErrorMessage = "Provide your about me")]
        [Display(Name = "About Me")]
        public string D_AboutMe { get; set; }
        
        public int? D_SatisfactionRate { get; set; }

        [Required(ErrorMessage = "Provide your response time")]
        [Display(Name = "Response Time")]
        public int? D_ResponseTime { get; set; }

        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        public virtual ICollection<tblDiagnostic> tblDiagnostics { get; set; }
        public virtual ICollection<tblDoctorWorkExperience> tblDoctorWorkExperiences { get; set; }
        public virtual ICollection<tblOfflineConsultaionDetail> tblOfflineConsultaionDetails { get; set; }
        public virtual ICollection<tblOnlineConsultaionDetail> tblOnlineConsultaionDetails { get; set; }
    }
}
