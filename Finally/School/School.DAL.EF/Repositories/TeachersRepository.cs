﻿using School.BLL.Models;
using School.DAL.EF.Contexts;

namespace School.DAL.EF.Repositories
{
    public class TeachersRepository : BaseRepository<Teacher>
    {
        private readonly AcademyContext _context;
        public TeachersRepository(AcademyContext context) : base(context)
        {
            _context = context;
        }

        public override void Update(Teacher item)
        {
            var originalTeacher = _context.Teachers.Find(item.Id);

            originalTeacher.Bio = item.Bio;
            originalTeacher.BirthDate = item.BirthDate;
            originalTeacher.Email = item.Email;
            originalTeacher.FirstName = item.FirstName;
            originalTeacher.LastName = item.LastName;
            originalTeacher.LinkToProfile = item.LinkToProfile;
            originalTeacher.Phone = item.Phone;

            _context.SaveChanges();
        }
    }
}