using GroupsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace groupsapi.Repositories
{
    public class SpecialisationRepository : ISpecialisationRepository
    {
        protected readonly GroupsContext _dbContext;
        public SpecialisationRepository(GroupsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Specialisation GetSpecialisationById(Guid specialisationId)
        {
            return _dbContext.Specialisations.Find(specialisationId);
        }

        public IEnumerable<Specialisation> GetAll()
        {
            return _dbContext.Specialisations.ToList();
        }

        public void Add(Specialisation specialisation)
        {
            _dbContext.Add(specialisation);
            Save();
        }

        public void Delete(Guid specialisationId)
        {
            var specialisation = _dbContext.Specialisations.Find(specialisationId);
            _dbContext.Specialisations.Remove(specialisation);
            Save();
        }

        public void Update(Specialisation specialisation)
        {
            var update = _dbContext.Specialisations
                            .Where(update => update.SpecialisationId.Equals(specialisation.SpecialisationId))
                            .SingleOrDefault();

            if (update != default(Specialisation))
            {
                update.Name = specialisation.Name;
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
