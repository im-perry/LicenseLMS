﻿using groupsapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace groupsapi.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        protected readonly GroupsContext _dbContext;

        public GroupRepository(GroupsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Group GetGroupById(int groupId)
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

        public void Delete(int groupId)
        {
            var group = _dbContext.Groups.Find(groupId);
            _dbContext.Groups.Remove(group);
            Save();
        }

        public void Update(Group group)
        {
            _dbContext.Entry(group).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}