using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeachingAPI.Models;

namespace teachingapi.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        protected readonly TeachingContext _dbContext;

        public LessonRepository(TeachingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ClassLesson GetLessonById(Guid lessonId)
        {
            return _dbContext.ClassLessons.Find(lessonId);
        }

        public IEnumerable<ClassLesson> GetAll()
        {
            return _dbContext.ClassLessons.ToList();
        }

        public void Add(ClassLesson lesson)
        {
            _dbContext.Add(lesson);
            Save();
        }

        public void Delete(Guid lessonId)
        {
            var lesson = _dbContext.ClassLessons.Find(lessonId);
            _dbContext.ClassLessons.Remove(lesson);
            Save();
        }

        public void Update(ClassLesson lesson)
        {
            _dbContext.Entry(lesson).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
