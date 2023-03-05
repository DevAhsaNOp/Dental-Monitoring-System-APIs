using System;
using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctorOfflineConsultaionDetails
    {
        public int OFCD_ID { get; set; }

        [Required(ErrorMessage = "Provide Doctor ID")]
        [Display(Name = "Doctor ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Doctor ID")]
        public int OFCD_DoctorID { get; set; }

        [Required(ErrorMessage = "Provide Hospital Name")]
        [Display(Name = "Hospital Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        public string OFCD_HospitalName { get; set; }

        [Required(ErrorMessage = "Provide your hospital phone number")]
        [Display(Name = "Hospital Phone Number")]
        [RegularExpression(@"03[0-9]{2}(?!1234567)(?!1111111)(?!7654321)[0-9]{7}", ErrorMessage = "Invalid Phone Number")]
        public string OFCD_HospitalPhoneNumber { get; set; }

        [Required(ErrorMessage = "Provide Address ID")]
        [Display(Name = "Address ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Address ID")]
        public int OFCD_HospitalAddressID { get; set; }

        [Display(Name = "Monday Start Time")]
        public TimeSpan? OFCD_MondayStartTime { get; set; }

        [Display(Name = "Monday End Time")]
        public TimeSpan? OFCD_MondayEndTime { get; set; }

        [Display(Name = "Tuesday Start Time")]
        public TimeSpan? OFCD_TuesdayStartTime { get; set; }

        [Display(Name = "Tuesday End Time")]
        public TimeSpan? OFCD_TuesdayEndTime { get; set; }

        [Display(Name = "Wednesday Start Time")]
        public TimeSpan? OFCD_WednesdayStartTime { get; set; }

        [Display(Name = "Wednesday End Time")]
        public TimeSpan? OFCD_WednesdayEndTime { get; set; }

        [Display(Name = "Thursday Start Time")]
        public TimeSpan? OFCD_ThursdayStartTime { get; set; }

        [Display(Name = "Thursday End Time")]
        public TimeSpan? OFCD_ThursdayEndTime { get; set; }

        [Display(Name = "Friday Start Time")]
        public TimeSpan? OFCD_FridayStartTime { get; set; }

        [Display(Name = "Friday End Time")]
        public TimeSpan? OFCD_FridayEndTime { get; set; }

        [Display(Name = "Saturday Start Time")]
        public TimeSpan? OFCD_SaturdayStartTime { get; set; }

        [Display(Name = "Saturday End Time")]
        public TimeSpan? OFCD_SaturdayEndTime { get; set; }

        [Display(Name = "Sunday Start Time")]
        public TimeSpan? OFCD_SundayStartTime { get; set; }

        [Display(Name = "Sunday End Time")]
        public TimeSpan? OFCD_SundayEndTime { get; set; }

        [Required(ErrorMessage = "Provide Checkup Charges")]
        [Display(Name = "Checkup Charges")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Checkup Charges")]
        public decimal OFCD_Charges { get; set; }
        
        public bool? OFCD_IsActive { get; set; }
        
        public bool? OFCD_IsArchive { get; set; }

        [Required(ErrorMessage = "Provide Created By")]
        [Display(Name = "Created By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Created By")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Created By")]
        public int? OFCD_CreatedBy { get; set; }
        
        public DateTime? OFCD_CreatedOn { get; set; }

        [Required(ErrorMessage = "Provide Updated By")]
        [Display(Name = "Updated By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Updated By")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Updated By")]
        public int? OFCD_UpdatedBy { get; set; }
        
        public DateTime? OFCD_UpdatedOn { get; set; }

        [Required(ErrorMessage = "Provide Number of checkup days")]
        [Display(Name = "Number of checkup days")]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,4})?$", ErrorMessage = "Invalid Number of checkup days")]
        [Range(1, 7, ErrorMessage = "Invalid Number of checkup days")]
        public int MinimumOnedayShouldBeAdded { get; set; }

        public virtual tblAddress tblAddress { get; set; }
        public virtual tblDoctor tblDoctor { get; set; }
    }
}
