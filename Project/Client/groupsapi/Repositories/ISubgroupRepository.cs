using groupsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace groupsapi.Repositories
{
    public interface ISubgroupRepository
    {
        Subgroup GetSubgroupById(int subgroupId);
        IEnumerable<Subgroup> GetAll();
        void Add(Subgroup subgroup);
        void Delete(int subgroupId);
        void Update(Subgroup subgroup);
        void Save();
    }
}
