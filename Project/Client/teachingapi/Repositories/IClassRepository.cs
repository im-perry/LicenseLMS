using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teachingapi.Models;

namespace teachingapi.Repositories
{
    public interface IClassRepository
    {
        Class GetClassById(int classId);
        IEnumerable<Class> GetAll();
        void Add(Class classs);
        void Delete(int classId);
        void Update(Class classs);
        void Save();
    }
}
