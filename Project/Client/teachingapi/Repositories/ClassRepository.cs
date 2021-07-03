using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teachingapi.Models;

namespace teachingapi.Repositories
{
    public class ClassRepository : IClassRepository
    {
        protected readonly TeachingContext _dbContext;

        public ClassRepository(TeachingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Class GetClassById(int classId)
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

        public void Delete(int classId)
        {
            var classs = _dbContext.Classes.Find(classId);
            _dbContext.Classes.Remove(classs);
            Save();
        }

        public void Update(Class classs)
        {
            _dbContext.Entry(classs).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
