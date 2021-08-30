using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.MVC.Models
{
    public class TeacherModel : PersonModel
    {
        [Required(ErrorMessage = "Please, enter you link to profile")]
        public string LinkToProfile { get; set; }
    }
}
