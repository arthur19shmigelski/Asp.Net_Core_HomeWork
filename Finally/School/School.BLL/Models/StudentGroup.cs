﻿using School.BLL.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.BLL.Models
{
    public class StudentGroup
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public DateTime? StartDate { get; set; }

        public GroupStatus Status { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}