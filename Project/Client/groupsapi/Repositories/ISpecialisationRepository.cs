using groupsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
