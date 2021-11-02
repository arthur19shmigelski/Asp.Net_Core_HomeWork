using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class TopicModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле -Название- не может быть пустым")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Длина поля -Название- должна быть 2-50")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле -Описание- не может быть пустым")]
        [StringLength(maximumLength: 1000, MinimumLength = 5, ErrorMessage = "Длина поля -Описание- должна быть 5-1000")]
        public string Description { get; set; }
    }
}