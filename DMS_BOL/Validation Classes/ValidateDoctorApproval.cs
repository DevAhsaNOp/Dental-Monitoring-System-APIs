using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateDoctorApproval
    {
        public int N_ID { get; set; }

        [Required(ErrorMessage = "Provide Doctor ID")]
        [Display(Name = "Doctor ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid data Type")]
        public int? N_DoctorID { get; set; }
        public bool N_IsApproved { get; set; }
        public bool N_IsArchive { get; set; }
        public bool N_IsRead { get; set; }
        public DateTime N_CreateadOn { get; set; }

        [Required(ErrorMessage = "Provide Created By")]
        [Display(Name = "Created By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid data Type")]
        public bool N_CreatedBy { get; set; }
        public DateTime? N_UpdatedOn { get; set; }
        public bool? N_UpdatedBy { get; set; }

        public virtual tblDoctor tblDoctor { get; set; }
    }
}
