namespace School.Core.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string NameLesson { get; set; }
        public string TopicLesson { get; set; }
        public string Comment { get; set; }

        public int CourseId { get; set; }
       
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}