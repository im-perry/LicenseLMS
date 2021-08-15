using GroupsAPI.Models;
using System.Collections.Generic;

namespace groupsapi.Repositories
{
    public interface ISpecialisationRepository
    {
        Specialisation GetSpecialisationById(int specialisationId);
        IEnumerable<Specialisation> GetAll();
        void Add(Specialisation specialisation);
        void Delete(int specialisationId);
        void Update(Specialisation specialisation);
        void Save();
    }
}
