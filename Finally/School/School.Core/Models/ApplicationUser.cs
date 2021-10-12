using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace School.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Teacher> Teacher { get; set; }
        public List<Student> Student { get; set; }
        public List<Manager> Manager { get; set; }
    }
}
