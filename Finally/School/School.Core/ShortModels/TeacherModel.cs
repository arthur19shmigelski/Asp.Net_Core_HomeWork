using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class TeacherModel : PersonModel
    {
        [Required(ErrorMessage = "Поле -LinkToProfile- не может быть пустым")]
        public string LinkToProfile { get; set; }
    }
}