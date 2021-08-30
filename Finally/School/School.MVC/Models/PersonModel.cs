using School.MVC.Models.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace School.MVC.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field <FirstName> can't be empty")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Length for <FirstName> must be 3-20")]
        [RegularExpression("^[a-zA-Z][a-zA-Z]*$",ErrorMessage = "<FirstName> must have only letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field <LastName> can't be empty")]
        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "<LastName> must have only letters")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Length for <LastName> must be 3-20")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "<Email> is required")]
        [EmailAddress(ErrorMessage = "Invalid <Email> Address")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Length <Email> must be 5-30, consist of symbol @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "<Phone> is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid <Phone>")]
        public string Phone { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
