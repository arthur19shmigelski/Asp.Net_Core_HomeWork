using System.Collections.Generic;

namespace School.BLL.Models
{
    public class Teacher : Person
    {
        public string Bio { get; set; }
        public string LinkToProfile { get; set; }
        public List<StudentGroup> Groups = new List<StudentGroup>();
    }
}