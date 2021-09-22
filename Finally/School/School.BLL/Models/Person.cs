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


        [Required(ErrorMessage = "Поле <Age> не может быть пустым")]
        [Range(16, 90, ErrorMessage = "Возраст должен быть от 16 до 90 лет!")]
        public int? Age { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
