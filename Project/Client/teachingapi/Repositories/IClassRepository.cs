using System;
using System.Collections.Generic;
using TeachingAPI.Models;

namespace teachingapi.Repositories
{
    public interface IClassRepository
    {
        Class GetClassById(string classId);
        IEnumerable<Class> GetAll();
        void Add(Class classs);
        void Delete(string classId);
        void Update(Class classs);
        void Save();
    }
}
