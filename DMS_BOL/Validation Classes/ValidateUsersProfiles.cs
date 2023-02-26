using System.ComponentModel.DataAnnotations;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateUsersProfiles
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Provide your first name")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(50, ErrorMessage = "First Name Max Length should be under 50")]
        [MinLength(5, ErrorMessage = "First Name Min Length should be 5")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Provide your last name")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are allow")]
        [MaxLength(50, ErrorMessage = "Last Name Max Length should be under 50")]
        [MinLength(5, ErrorMessage = "Last Name Min Length should be 5")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Provide your phone number")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"03[0-9]{2}(?!1234567)(?!1111111)(?!7654321)[0-9]{7}", ErrorMessage = "Invalid Phone Number")]
        public string UserPhoneNumber { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"03[0-9]{2}(?!1234567)(?!1111111)(?!7654321)[0-9]{7}", ErrorMessage = "Invalid Phone Number")]
        public string UserUpdatePhoneNumber { get; set; }
        
        [Display(Name ="User Address")]
        public int UserAddressID { get; set; }

        [Display(Name = "User Role")]
        public int UserRoleID { get; set; }

        [Required(ErrorMessage = "Provide your profile image")]
        [Display(Name ="Profile Image")]
        public string UserProfileImage { get; set; }

        [Required(ErrorMessage = "Provide your email address")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email Address")]
        public string UserEmail { get; set; }

        [Display(Name = "Email Address")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email Address")]
        public string UserUpdateEmail { get; set; }

        [Required(ErrorMessage = "Provide secure password")]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password should contain minimum 8 characters in length and At least one uppercase, lowercase English letter and one digit and special character")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Provide your gender")]
        [Display(Name = "Gender")]
        [Range(1, int.MaxValue, ErrorMessage = "Must select a Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Provide created by user id")]
        [Display(Name = "Created By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid CreatedBy Type")]
        public int? UserCreatedBy { get; set; }

        [Display(Name = "Created On")]
        public System.DateTime? UserCreatedOn { get; set; }

        [Required(ErrorMessage = "Provide updated by user id")]
        [Display(Name = "Updated By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid UpdatedBy Type")]
        public int? UserUpdatedBy { get; set; }

        [Display(Name = "Updated On")]
        public System.DateTime? UserUpdatedOn { get; set; }

        [Display(Name = "User Is Active")]
        public bool? UserIsActive { get; set; }

        [Display(Name = "User Is Archive")]
        public bool? UserIsArchive { get; set; }

        [Required(ErrorMessage = "Provide your OTP")]
        [Display(Name = "OTP")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid OTP")]
        public string UserOTP { get; set; }

        [Display(Name = "User Verified")]
        public bool? UserVerified { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Display(Name = "State")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "Must select a State")]
        //public string State { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Display(Name = "City")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "Must select a City")]
        //public string City { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Display(Name = "Area")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "Must select a Area")]
        //public string Area { get; set; }

        [Required(ErrorMessage = "Provide your state")]
        [Display(Name = "State")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "Provide your city")]
        [Display(Name = "City")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Provide you area")]
        [Display(Name = "Area")]
        public int AreaID { get; set; }

        [Display(Name = "Address")]
        public string CompleteAddress { get; set; }

        public virtual tblAddress tblAddress { get; set; }
        public virtual tblRole tblRole { get; set; }
    }
}
