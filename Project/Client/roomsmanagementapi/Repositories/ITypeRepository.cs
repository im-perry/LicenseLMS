using System;
using System.Collections.Generic;
using Type = RoomsAPI.Models.Type;

namespace roomsmanagementapi.Repositories
{
    public interface ITypeRepository
    {
        Type GetTypeById(Guid typeId);
        IEnumerable<Type> GetAll();
        void Add(Type type);
        void Delete(Guid typeId);
        void Update(Type type);
        void Save();
    }
}
