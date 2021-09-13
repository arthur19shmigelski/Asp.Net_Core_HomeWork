﻿using School.DAL.Interfaces;
using System.Collections.Generic;

namespace School.BLL.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Models.Student> _repository;

        public StudentService(IRepository<Models.Student> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Models.Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Models.Student GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Models.Student student)
        {
            _repository.Create(student);
        }

        public void Update(Models.Student student)
        {
            _repository.Update(student);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}