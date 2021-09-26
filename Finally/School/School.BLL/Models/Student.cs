using School.BLL.Models.Enum;
using System;

namespace School.BLL.Models
{
    public class Student : Person
    {
        public StudentType Type { get; set; }

        public int? GroupId { get; set; }
        public StudentGroup Group { get; set; }
    }
}
