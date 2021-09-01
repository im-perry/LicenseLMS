using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeachingAPI.Models;

namespace teachingapi.Repositories
{
    public class ClassRepository : IClassRepository
    {
        protected readonly TeachingContext _dbContext;

        public ClassRepository(TeachingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Class GetClassById(string classId)
        {
            return _dbContext.Classes.Find(classId);
        }

        public IEnumerable<Class> GetAll()
        {
            return _dbContext.Classes.ToList();
        }

        public void Add(Class classs)
        {
            _dbContext.Add(classs);
            Save();
        }

        public void Delete(string classId)
        {
            var classs = _dbContext.Classes.Find(classId);
            _dbContext.Classes.Remove(classs);
            Save();
        }

        public void Update(Class classs)
        {
            var update = _dbContext.Classes
                            .Where(update => update.ClassId.Equals(classs.ClassId))
                            .SingleOrDefault();

            if (update != default(Class))
            {
                update.Name = classs.Name;
                update.ActivityName = classs.ActivityName;
                update.AuthorName = classs.AuthorName;
                update.Name = classs.Name;
                update.Description = classs.Description;
                update.Groups = classs.Groups;
                update.Subgroups = classs.Subgroups;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
