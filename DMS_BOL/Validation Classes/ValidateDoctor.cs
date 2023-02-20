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
        public string DoctorYearsOfExperience { get; set; }

        [Required(ErrorMessage = "Provide your offered services")]
        [Display(Name = "Offered Services")]
        public string DoctorOfferedServices { get; set; }

        [Required(ErrorMessage = "Provide your work phone number")]
        [Display(Name = "Work Phone Number")]
        public string DoctorWorkPhoneNumber { get; set; }

        [Display(Name = "Awards and Achievements")]
        public string DoctorAwardsAndAchievements { get; set; }

        [Required(ErrorMessage = "Provide your about me")]
        [Display(Name = "About Me")]
        public string DoctorAboutMe { get; set; }
        
        public int? DoctorSatisfactionRate { get; set; }

        [Required(ErrorMessage = "Provide your response time")]
        [Display(Name = "Response Time")]
        public int? DoctorResponseTime { get; set; }

        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        public virtual ICollection<tblDiagnostic> tblDiagnostics { get; set; }
        public virtual ICollection<tblDoctorReview> tblDoctorReviews { get; set; }
        public virtual ICollection<tblDoctorWorkExperience> tblDoctorWorkExperiences { get; set; }
        public virtual ICollection<tblOfflineConsultaionDetail> tblOfflineConsultaionDetails { get; set; }
        public virtual ICollection<tblOnlineConsultaionDetail> tblOnlineConsultaionDetails { get; set; }
    }
}
