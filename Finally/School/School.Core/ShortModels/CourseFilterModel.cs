using School.Core.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace School.Core.ShortModels
{
    public class CourseFilterModel
    {
        public string TitleContains { get; set; }
        public string DescriptionContains { get; set; }
        public string ProgramContains { get; set; }
        public string TopicNameContains { get; set; }

        [Display(Name = "Price Should Be From")]
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public CourseLevel? Level { get; set; }
        public int? DurationWeeksFrom { get; set; }
        public int? DurationWeeksTo { get; set; }
    }
}