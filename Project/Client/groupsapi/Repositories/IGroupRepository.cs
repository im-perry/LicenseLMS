using GroupsAPI.Models;
using System;
using System.Collections.Generic;

namespace groupsapi.Repositories
{
    public interface IGroupRepository
    {
        Group GetGroupById(Guid groupId);
        IEnumerable<Group> GetAll();
        void Add(Group group);
        void Delete(Guid groupId);
        void Update(Group group);
        void Save();
    }
}
