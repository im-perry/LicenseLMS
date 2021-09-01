using GroupsAPI.Models;
using System;
using System.Collections.Generic;

namespace groupsapi.Repositories
{
    public interface IGroupRepository
    {
        Group GetGroupById(string groupId);
        IEnumerable<Group> GetAll();
        void Add(Group group);
        void Delete(string groupId);
        void Update(Group group);
        void Save();
    }
}
