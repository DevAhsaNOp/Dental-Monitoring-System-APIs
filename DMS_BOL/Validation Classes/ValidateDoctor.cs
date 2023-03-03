using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctor : ValidateUsersProfiles
    {
        [Display(Name = "Doctor Specialization")]
        public string DoctorSpecialization { get; set; }

        [Display(Name = "Year Of Experience")]
        public string DoctorYearsOfExperience { get; set; }

        [Display(Name = "Work Phone Number")]
        public string DoctorWorkPhoneNumber { get; set; }

        [Display(Name = "Awards and Achievements")]
        public string DoctorAwardsAndAchievements { get; set; }

        [Display(Name = "About Me")]
        public string DoctorAboutMe { get; set; }

        [Display(Name = "Is Profile Completed")]
        public bool? D_IsProfileCompleted { get; set; }

        public int? DoctorSatisfactionRate { get; set; }

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
