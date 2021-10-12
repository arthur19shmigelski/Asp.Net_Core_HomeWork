using System.Collections.Generic;

namespace School.Core.Models
{
    public class Teacher : Person
    {
        public string Bio { get; set; }
        public string LinkToProfile { get; set; }
        public List<Group> Groups = new List<Group>();
    }
}