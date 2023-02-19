﻿using System;
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
        
        [Required(ErrorMessage = "Provide your address")]
        [Display(Name ="User Address")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Invalid Address Type")]
        public int UserAddressID { get; set; }

        [Required(ErrorMessage = "Provide your role")]
        [Display(Name = "User Role")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Role Type")]
        public int UserRoleID { get; set; }

        [Required(ErrorMessage = "Provide your profile image")]
        [Display(Name ="Profile Image")]
        public string UserProfileImage { get; set; }

        [Required(ErrorMessage = "Provide your email address")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email Address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Provide secure password")]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password should contain minimum 8 characters in length and At least one uppercase, lowercase English letter and one digit and special character")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Provide your password")]
        [Display(Name = "Password")]
        public string UserLoginPassword { get; set; }

        [Required(ErrorMessage = "Provide created by user id")]
        [Display(Name = "Created By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid CreatedBy Type")]
        public int? UserCreatedBy { get; set; }

        [Required(ErrorMessage = "Provide created on date/time")]
        [Display(Name = "Created On")]
        public System.DateTime? UserCreatedOn { get; set; }

        [Required(ErrorMessage = "Provide updated by user id")]
        [Display(Name = "Updated By")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid UpdatedBy Type")]
        public int? UserUpdatedBy { get; set; }

        [Required(ErrorMessage = "Provide updated on date/time")]
        [Display(Name = "Updated On")]
        public System.DateTime? UserUpdatedOn { get; set; }

        [Required(ErrorMessage = "Provide user is active")]
        [Display(Name = "User Is Active")]
        public bool? UserIsActive { get; set; }

        [Required(ErrorMessage = "Provide user is archive")]
        [Display(Name = "User Is Archive")]
        public bool? UserIsArchive { get; set; }

        [Required(ErrorMessage = "Provide your OTP")]
        [Display(Name = "OTP")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid OTP")]
        public string UserOTP { get; set; }

        [Required(ErrorMessage = "Provide user verified")]
        [Display(Name = "User Verified")]
        public bool? UserVerified { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "State")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a State")]
        public string State { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "City")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Area")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a Area")]
        public string Area { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "State")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a State")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "City")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a City")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Area")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must select a Area")]
        public int AreaID { get; set; }

        [Display(Name = "Address")]
        public string CompleteAddress { get; set; }

        public virtual tblAddress tblAddress { get; set; }
        public virtual tblRole tblRole { get; set; }
    }
}
