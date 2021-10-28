using School.Core.Models;

namespace School.Core.ShortModels
{
    public class LessonModel
    {
        public int Id { get; set; }
        public string NameLesson { get; set; }
        public string TopicLesson { get; set; }
        public string Comment { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
