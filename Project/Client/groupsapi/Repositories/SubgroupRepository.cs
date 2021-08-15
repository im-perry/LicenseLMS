using GroupsAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public Subgroup GetSubgroupById(int activityId)
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

        public void Delete(int subgroupId)
        {
            var subgroup = _dbContext.Subgroups.Find(subgroupId);
            _dbContext.Subgroups.Remove(subgroup);
            Save();
        }

        public void Update(Subgroup subgroup)
        {
            _dbContext.Entry(subgroup).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
