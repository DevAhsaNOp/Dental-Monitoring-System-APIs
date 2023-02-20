using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateAddress
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Address")]
        public string CompleteAddress { get; set; }
    }
}
