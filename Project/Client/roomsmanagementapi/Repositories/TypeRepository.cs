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

        public Type GetTypeById(string typeId)
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

        public void Delete(string typeId)
        {
            var room = _dbContext.Types.Find(typeId);
            _dbContext.Types.Remove(room);
            Save();
        }

        public void Update(Type type)
        {
            var update = _dbContext.Types
                            .Where(update => update.TypeId.Equals(type.TypeId))
                            .SingleOrDefault();

            if (update != default(Type))
            {
                update.Name = type.Name;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
