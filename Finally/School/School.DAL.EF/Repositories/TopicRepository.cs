using School.BLL.Models;
using School.DAL.EF.Contexts;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL.EF.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        private readonly AcademyContext _context;

        public TopicRepository(AcademyContext context)
        {
            _context = context;
        }
        public void Create(Topic item)
        {
            _context.Topics.Add(item);
        }

        public void Delete(int id)
        {
            var item = _context.StudentGroups.Find(id);
            _context.StudentGroups.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Topic> Find(Func<Topic, bool> predicate)
        {
            return _context.Topics
                           .Where(predicate)
                           .AsQueryable()
                           .ToList();
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics.ToList();

        }

        public Topic GetById(int id)
        {
            return _context.Topics.Find(id);
        }

        public void Update(Topic item)
        {
            var originalTopic = _context.Topics.Find(item.Id);

            originalTopic.Description = item.Description;
            originalTopic.Parent = item.Parent;
            originalTopic.ParentId = item.ParentId;
            originalTopic.Title = item.Title;
            
            _context.SaveChanges();
        }
    }
}
