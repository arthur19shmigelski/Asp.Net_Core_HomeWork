using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.MVC.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field <Title> can't be empty")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Length for FirstName must be 2-50")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field <Description> can't be empty")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Length for FirstName must be 2-100")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field <Program> can't be empty")]
        [StringLength(maximumLength: 500, MinimumLength = 2, ErrorMessage = "Length for FirstName must be 2-500")]
        public string Program { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int RequestsCount { get; set; }
        public IEnumerable<StudentRequestModel> Requests { get; set; }
    }
}