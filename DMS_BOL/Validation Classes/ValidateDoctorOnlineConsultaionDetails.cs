using System;
using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctorOnlineConsultaionDetails
    {
        public int OCD_ID { get; set; }

        [Required(ErrorMessage = "Provide Doctor ID")]
        [Display(Name = "Doctor ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Doctor ID")]
        public int? OCD_DoctorID { get; set; }

        [Display(Name = "Monday Start Time")]
        public TimeSpan? OCD_MondayStartTime { get; set; }

        [Display(Name = "Monday End Time")]
        public TimeSpan? OCD_MondayEndTime { get; set; }

        [Display(Name = "Tuesday Start Time")]
        public TimeSpan? OCD_TuesdayStartTime { get; set; }

        [Display(Name = "Tuesday End Time")]
        public TimeSpan? OCD_TuesdayEndTime { get; set; }

        [Display(Name = "Wednesday Start Time")]
        public TimeSpan? OCD_WednesdayStartTime { get; set; }

        [Display(Name = "Wednesday End Time")]
        public TimeSpan? OCD_WednesdayEndTime { get; set; }

        [Display(Name = "Thursday Start Time")]
        public TimeSpan? OCD_ThursdayStartTime { get; set; }

        [Display(Name = "Thursday End Time")]
        public TimeSpan? OCD_ThursdayEndTime { get; set; }

        [Display(Name = "Friday Start Time")]
        public TimeSpan? OCD_FridayStartTime { get; set; }

        [Display(Name = "Friday End Time")]
        public TimeSpan? OCD_FridayEndTime { get; set; }

        [Display(Name = "Saturday Start Time")]
        public TimeSpan? OCD_SaturdayStartTime { get; set; }

        [Display(Name = "Saturday End Time")]
        public TimeSpan? OCD_SaturdayEndTime { get; set; }

        [Display(Name = "Sunday Start Time")]
        public TimeSpan? OCD_SundayStartTime { get; set; }

        [Display(Name = "Sunday End Time")]
        public TimeSpan? OCD_SundayEndTime { get; set; }

        [Required(ErrorMessage = "Provide Online Checkup Charges")]
        [Display(Name = "Online Checkup Charges")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Online Checkup Charges")]
        public decimal OCD_Charges { get; set; }

        public bool? OCD_IsActive { get; set; }

        public bool? OCD_IsArchive { get; set; }

        [Required(ErrorMessage = "Provide Created By")]
        [Display(Name = "Created By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Created By")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Created By")]
        public int? OCD_CreatedBy { get; set; }
        public DateTime? OCD_CreatedOn { get; set; }

        [Required(ErrorMessage = "Provide Updated By")]
        [Display(Name = "Updated By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Updated By")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Updated By")]
        public int? OCD_UpdatedBy { get; set; }

        public DateTime? OCD_UpdatedOn { get; set; }

        [Required(ErrorMessage = "Provide Number of checkup days")]
        [Display(Name = "Number of checkup days")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Number of checkup days")]
        [Range(1, 7, ErrorMessage = "Invalid Number of checkup days")]
        public int MinimumOnedayShouldBeAdded { get; set; }

        public virtual tblDoctor tblDoctor { get; set; }
    }
}
