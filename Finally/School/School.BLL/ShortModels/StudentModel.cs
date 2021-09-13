using School.BLL.Models.Enum;

namespace School.BLL.ShortModels
{
    public class StudentModel : PersonModel
    {
        public int? GroupId { get; set; }
        public StudentGroupModel Group { get; set; }
        public StudentType Type { get; set; }

    }
}
