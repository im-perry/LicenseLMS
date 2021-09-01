using GroupsAPI.Models;
using System;
using System.Collections.Generic;

namespace groupsapi.Repositories
{
    public interface ISubgroupRepository
    {
        Subgroup GetSubgroupById(string subgroupId);
        IEnumerable<Subgroup> GetAll();
        void Add(Subgroup subgroup);
        void Delete(string subgroupId);
        void Update(Subgroup subgroup);
        void Save();
    }
}
