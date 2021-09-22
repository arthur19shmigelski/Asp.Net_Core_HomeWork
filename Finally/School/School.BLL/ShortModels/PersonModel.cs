using System;
using System.ComponentModel.DataAnnotations;

namespace School.BLL.ShortModels
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле -FirstName- не может быть пустым")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Длина поля -FirstName- должна быть 3-20")]
        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "Поле -FirstName- должно содержать только буквы")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле -LastName- не может быть пустым")]
        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "Поле -LastName- должно содержать только буквы")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Длина поля -LastName- должна быть 3-20")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле -Age- не может быть пустым")]
        [Range(16,90,ErrorMessage ="Возраст должен быть от 16 до 90 лет!")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Поле -Email- не может быть пустым")]
        [EmailAddress(ErrorMessage = "Некорректный -Email- адрес")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Длина поля -Email- должна быть 5-30, а также содержать символ @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле -Phone- не может быть пустым")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Некорректный -Phone-")]
        public string Phone { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
