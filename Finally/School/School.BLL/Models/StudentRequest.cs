using School.BLL.Models.Enum;
using System;

namespace School.BLL.Models
{
    public class StudentRequest
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        public int CourseId { get; set; }
        public Course Course { get; set; }
       
        public string Comments { get; set; }
        public DateTime ReadyToStartDate { get; set; }
        public RequestStatus Status { get; set; }
    }
}
