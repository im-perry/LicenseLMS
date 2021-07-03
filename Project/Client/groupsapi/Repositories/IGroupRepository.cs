using groupsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace groupsapi.Repositories
{
    public interface IGroupRepository
    {
        Group GetGroupById(int groupId);
        IEnumerable<Group> GetAll();
        void Add(Group group);
        void Delete(int groupId);
        void Update(Group group);
        void Save();
    }
}
