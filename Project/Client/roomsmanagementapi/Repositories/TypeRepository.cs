using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = RoomsAPI.Models.Type;

namespace roomsmanagementapi.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        protected readonly RoomsContext _dbContext;

        public TypeRepository(RoomsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Type GetTypeById(Guid typeId)
        {
            return _dbContext.Types.Find(typeId);
        }

        public IEnumerable<Type> GetAll()
        {
            return _dbContext.Types.ToList();
        }

        public void Add(Type room)
        {
            _dbContext.Add(room);
            Save();
        }

        public void Delete(Guid typeId)
        {
            var room = _dbContext.Types.Find(typeId);
            _dbContext.Types.Remove(room);
            Save();
        }

        public void Update(Type type)
        {
            _dbContext.Entry(type).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
