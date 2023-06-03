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
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Year Of Experience")]
        public string DoctorYearsOfExperience { get; set; }

        [Display(Name = "Work Phone Number")]
        [RegularExpression(@"03[0-9]{2}(?!1234567)(?!1111111)(?!7654321)[-]?[0-9]{7}", ErrorMessage = "Invalid Phone Number")]
        public string DoctorWorkPhoneNumber { get; set; }

        [Display(Name = "Awards and Achievements")]
        public string DoctorAwardsAndAchievements { get; set; }

        [Required(ErrorMessage = "About Me")]
        [Display(Name = "About Me")]
        [StringLength(1000, MinimumLength = 500, ErrorMessage = "Character length should be in between 500-800")]
        public string DoctorAboutMe { get; set; }

        [Required(ErrorMessage = "Minimum One day Should Be Added")]
        [Display(Name = "Number of checkup days")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Number of checkup days")]
        [Range(1, 7, ErrorMessage = "Invalid Number of checkup days")]
        public int? MinimumOnedayShouldBeAdded { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Is Profile Completed")]
        public bool? D_IsProfileCompleted { get; set; }

        public int? DoctorSatisfactionRate { get; set; }

        [Required(ErrorMessage = "Response Time")]
        [Display(Name = "Response Time")]
        [Range(1, 100, ErrorMessage = "Invalid Number of Response Time")]
        [RegularExpression("^\\d{0,3}$", ErrorMessage = "Invalid Number of Response Time")]
        public int? DoctorResponseTime { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Hospital Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        public string WEX_HospitalName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Designation")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        public string WEX_Designation { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Still Working")]
        public bool WEX_IsWorking { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Start Working Date")]
        public DateTime? WEX_FromDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "End of Working Date")]
        public DateTime? WEX_ToDate { get; set; }

        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        public virtual ICollection<tblDiagnostic> tblDiagnostics { get; set; }
        public virtual ICollection<tblDoctorReview> tblDoctorReviews { get; set; }
        public virtual ICollection<tblDoctorWorkExperience> tblDoctorWorkExperiences { get; set; }
        public virtual ICollection<tblOfflineConsultaionDetail> tblOfflineConsultaionDetails { get; set; }
        public virtual ICollection<tblOnlineConsultaionDetail> tblOnlineConsultaionDetails { get; set; }
    }
}
