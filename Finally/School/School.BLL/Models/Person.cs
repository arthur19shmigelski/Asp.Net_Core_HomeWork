using System;
using System.ComponentModel.DataAnnotations;

namespace School.BLL.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field <FirstName> can't be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field <LastName> can't be empty")]
        public string LastName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BirthDate { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
