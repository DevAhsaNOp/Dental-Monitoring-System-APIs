using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateUsersLogin
    {
        [Required(ErrorMessage = "Provide your email address")]
        [Display(Name = "Email Address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Provide secure password")]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

    }
}
