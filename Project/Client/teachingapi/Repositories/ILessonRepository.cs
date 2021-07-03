using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teachingapi.Models;

namespace teachingapi.Repositories
{
    public interface ILessonRepository
    {
        ClassLesson GetLessonById(int lessonId);
        IEnumerable<ClassLesson> GetAll();
        void Add(ClassLesson lesson);
        void Delete(int lessonId);
        void Update(ClassLesson lesson);
        void Save();
    }
}
