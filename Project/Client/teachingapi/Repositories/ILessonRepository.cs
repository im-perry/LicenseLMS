using System;
using System.Collections.Generic;
using TeachingAPI.Models;

namespace teachingapi.Repositories
{
    public interface ILessonRepository
    {
        ClassLesson GetLessonById(string lessonId);
        IEnumerable<ClassLesson> GetAll();
        void Add(ClassLesson lesson);
        void Delete(string lessonId);
        void Update(ClassLesson lesson);
        void Save();
    }
}
