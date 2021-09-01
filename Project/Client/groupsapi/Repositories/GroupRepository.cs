using GroupsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace groupsapi.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        protected readonly GroupsContext _dbContext;

        public GroupRepository(GroupsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Group GetGroupById(string groupId)
        {
            return _dbContext.Groups.Find(groupId);
        }

        public IEnumerable<Group> GetAll()
        {
            return _dbContext.Groups.ToList();
        }

        public void Add(Group group)
        {
            _dbContext.Add(group);
            Save();
        }

        public void Delete(string groupId)
        {
            var group = _dbContext.Groups.Find(groupId);
            _dbContext.Groups.Remove(group);
            Save();
        }

        public void Update(Group group)
        {
            var update = _dbContext.Groups
                            .Where(update => update.GroupId.Equals(group.GroupId))
                            .SingleOrDefault();

            if (update != default(Group))
            {
                update.Name = group.Name;
                update.Year = group.Year;
                update.TutorName = group.TutorName;
                update.SpecialisationName = group.SpecialisationName;
                update.Subgroups = group.Subgroups;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
