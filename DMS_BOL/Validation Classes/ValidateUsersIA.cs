using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateUsersIA
    {
        [Required(ErrorMessage = "Provide user id")]
        [Display(Name = "User ID")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid User ID Type")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Provide updated by user id")]
        [Display(Name = "Updated By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid UpdatedBy Type")]
        public int UserUpdatedBy { get; set; }

    }
}
