using School.Core.Models.Enum;
using System;

namespace School.Core.Models
{
    public class Student : Person
    {
        public StudentType Type { get; set; }

        public int? GroupId { get; set; }
        public StudentGroup Group { get; set; }
    }
}
