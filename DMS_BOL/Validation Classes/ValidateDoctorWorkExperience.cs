using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctorWorkExperience
    {
        public int WEX_ID { get; set; }

        [Required(ErrorMessage = "Provide Doctor ID")]
        [Display(Name = "Doctor ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Doctor ID")]
        public int? WEX_DoctorID { get; set; }

        [Display(Name = "Hospital Info")]
        public List<ValidateDoctorHospitalInfo> HospitalInfos { get; set; }

        public bool? WEX_IsActive { get; set; }

        public bool? WEX_IsArchive { get; set; }

        [Required(ErrorMessage = "Provide Created By")]
        [Display(Name = "Created By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Created By")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Created By")]
        public int? WEX_CreatedBy { get; set; }

        public DateTime? WEX_CreatedOn { get; set; }

        [Required(ErrorMessage = "Provide Updated By")]
        [Display(Name = "Updated By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Updated By")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Updated By")]
        public int? WEX_UpdatedBy { get; set; }

        public DateTime? WEX_UpdatedOn { get; set; }

        public virtual tblDoctor tblDoctor { get; set; }
    }

    public class ValidateDoctorHospitalInfo
    {
        public int HospitalID { get; set; }

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
    }
}
