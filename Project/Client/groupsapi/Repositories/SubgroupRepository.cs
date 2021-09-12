using GroupsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace groupsapi.Repositories
{
    public class SubgroupRepository : ISubgroupRepository
    {
        protected readonly GroupsContext _dbContext;

        public SubgroupRepository(GroupsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Subgroup GetSubgroupById(Guid activityId)
        {
            return _dbContext.Subgroups.Find(activityId);
        }

        public IEnumerable<Subgroup> GetAll()
        {
            return _dbContext.Subgroups.ToList();
        }

        public void Add(Subgroup subgroup)
        {
            _dbContext.Add(subgroup);
            Save();
        }

        public void Delete(Guid subgroupId)
        {
            var subgroup = _dbContext.Subgroups.Find(subgroupId);
            _dbContext.Subgroups.Remove(subgroup);
            Save();
        }

        public void Update(Subgroup subgroup)
        {
            var update = _dbContext.Subgroups
                            .Where(update => update.SubgroupId.Equals(subgroup.SubgroupId))
                            .SingleOrDefault();

            if (update != default(Subgroup))
            {
                update.Name = subgroup.Name;
                update.GroupName = subgroup.GroupName;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
