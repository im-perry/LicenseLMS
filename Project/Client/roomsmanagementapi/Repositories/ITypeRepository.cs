using System;
using System.Collections.Generic;
using Type = RoomsAPI.Models.Type;

namespace roomsmanagementapi.Repositories
{
    public interface ITypeRepository
    {
        Type GetTypeById(string typeId);
        IEnumerable<Type> GetAll();
        void Add(Type type);
        void Delete(string typeId);
        void Update(Type type);
        void Save();
    }
}
