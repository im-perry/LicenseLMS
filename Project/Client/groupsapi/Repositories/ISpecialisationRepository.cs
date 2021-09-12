using GroupsAPI.Models;
using System;
using System.Collections.Generic;

namespace groupsapi.Repositories
{
    public interface ISpecialisationRepository
    {
        Specialisation GetSpecialisationById(Guid specialisationId);
        IEnumerable<Specialisation> GetAll();
        void Add(Specialisation specialisation);
        void Delete(Guid specialisationId);
        void Update(Specialisation specialisation);
        void Save();
    }
}
