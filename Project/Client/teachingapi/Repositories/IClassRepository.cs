using System;
using System.Collections.Generic;
using TeachingAPI.Models;

namespace teachingapi.Repositories
{
    public interface IClassRepository
    {
        Class GetClassById(Guid classId);
        IEnumerable<Class> GetAll();
        void Add(Class classs);
        void Delete(Guid classId);
        void Update(Class classs);
        void Save();
    }
}
