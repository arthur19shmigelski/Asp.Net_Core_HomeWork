using School.Core.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле -Название- не может быть пустым")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Длина для -Название- должна быть 2-50")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле -Описание- не может быть пустым")]
        [StringLength(maximumLength: 1000, MinimumLength = 2, ErrorMessage = "Длина для <Описание> должна быть 2-1000")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле -Программа курса- не может быть пустым")]
        [StringLength(maximumLength: 500, MinimumLength = 2, ErrorMessage = "Длина для -Программа курса- должна быть 2-500")]
        public string Program { get; set; }

        [Required(ErrorMessage = "Поле -Длительность курса- не может быть пустым")]
        public int DurationWeeks { get; set; }

        [Required(ErrorMessage = "Поле -Стоимость курса- не может быть пустым")]
        public double? Price { get; set; }

        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int RequestsCount { get; set; }
        public IEnumerable<StudentRequestModel> Requests { get; set; }
        public CourseLevel Level { get; set; }
    }
}