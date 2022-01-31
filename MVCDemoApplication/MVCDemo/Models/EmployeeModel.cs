using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class EmployeeModel
    {
        [Display(Name ="Employee ID")]
        [Range(100000,999999,ErrorMessage = "Please enter a valid employee id")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide a first name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please provide a last name")] 
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please provide a valid email address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Conform Email")]
        [Compare("EmailAddress", ErrorMessage = "The emails must match")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please provide a valid password")]
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength = 10, ErrorMessage = "The password's format is incorrect")]
        public string Password { get; set; }

        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passowrds must match")]
        public string ConfirmPassword { get; set; }
    }
}