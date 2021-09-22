﻿using Microsoft.EntityFrameworkCore;
using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.EF.Repositories
{
    public class StudentsRepository : IRepository<Student>
    {
        private readonly AcademyContext _context;

        public StudentsRepository(AcademyContext context)
        {
            _context = context;
        }

        public async Task Create(Student item)
        {
            await _context.Students.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _context.Students.FindAsync(id);
            _context.Students.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> Find(Func<Student, bool> predicate)
        {
            return await _context.Students
                                        .Where(predicate)
                                        .AsQueryable()
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.AsNoTracking()
            .Include(s => s.Group)
            .ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task Update(Student item)
        {
            var originalStudent = await _context.Students.FindAsync(item.Id);

            originalStudent.Age = item.Age;
            originalStudent.Email = item.Email;
            originalStudent.FirstName = item.FirstName;
            originalStudent.LastName = item.LastName;
            originalStudent.Group = item.Group;
            originalStudent.GroupId = item.GroupId;
            originalStudent.Phone = item.Phone;
            originalStudent.Type = item.Type;

            await _context.SaveChangesAsync();
        }
    }
}