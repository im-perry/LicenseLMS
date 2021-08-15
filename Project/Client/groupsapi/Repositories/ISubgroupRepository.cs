using GroupsAPI.Models;
using System.Collections.Generic;

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
