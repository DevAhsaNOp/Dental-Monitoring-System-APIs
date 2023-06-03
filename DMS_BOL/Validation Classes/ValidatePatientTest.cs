using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DMS_BOL.Validation_Classes
{
    public class ValidatePatientTest
    {
        public int PT_ID { get; set; }

        [Required(ErrorMessage = "Provide Patinet ID")]
        [Display(Name = "Patient ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Patient ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Patient")]
        public int? PT_PatientID { get; set; }

        public DateTime? PT_Datetime { get; set; }

        [Required(ErrorMessage = "Provide Test Images Folder Path")]
        [Display(Name = "Images Folder")]
        public string PT_Images { get; set; }
        public List<string> Images { get; set; }
        public ValidateAddress PatientAddress { get; set; }
        public string PT_Pdf { get; set; }
        public string PT_IdentifiedDiseases { get; set; }
        public string PT_Remarks { get; set; }
        public bool? PT_IsActive { get; set; }
        public bool? PT_IsArchive { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(5, 50, ErrorMessage = "Minimum 5 images you need to upload")]
        public int ImagesCount { get; set; }

        public virtual tblPatient tblPatient { get; set; }
    }
}
