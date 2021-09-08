﻿using System;
using System.Collections.Generic;

namespace School.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        abstract void Update(T item);
        void Delete(int id);
    }
}
