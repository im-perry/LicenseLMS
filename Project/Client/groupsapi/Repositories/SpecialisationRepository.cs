using groupsapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace groupsapi.Repositories
{
    public class SpecialisationRepository : ISpecialisationRepository
    {
        protected readonly GroupsContext _dbContext;
        public SpecialisationRepository(GroupsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Specialisation GetSpecialisationById(int specialisationId)
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

        public void Delete(int specialisationId)
        {
            var specialisation = _dbContext.Specialisations.Find(specialisationId);
            _dbContext.Specialisations.Remove(specialisation);
            Save();
        }

        public void Update(Specialisation specialisation)
        {
            _dbContext.Entry(specialisation).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
