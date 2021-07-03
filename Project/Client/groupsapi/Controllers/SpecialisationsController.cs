using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using groupsapi;
using groupsapi.Models;
using groupsapi.Repositories;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;

namespace groupsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpecialisationsController : ControllerBase
    {
        private readonly ISpecialisationRepository _specialisationRepository;

        public SpecialisationsController(ISpecialisationRepository specialisationRepository)
        {
            _specialisationRepository = specialisationRepository;
        }

        // GET: api/Specialisations
        [HttpGet]
        public IActionResult GetSpecialisations()
        {
            var specialisations = _specialisationRepository.GetAll();
            return new OkObjectResult(specialisations);
        }

        // GET: api/Specialisations/5
        [HttpGet("{id}")]
        public IActionResult GetSpecialisation(int id)
        {
            var specialisation = _specialisationRepository.GetSpecialisationById(id);
            return new OkObjectResult(specialisation);
        }

        // PUT: api/Specialisations/5
        [HttpPut]
        public IActionResult PutSpecialisation(Specialisation specialisation)
        {
            if (specialisation != null)
            {
                using (var scope = new TransactionScope())
                {
                    _specialisationRepository.Update(specialisation);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: api/Specialisations
        [HttpPost]
        public IActionResult PostSpecialisation(Specialisation specialisation)
        {
            using (var scope = new TransactionScope())
            {
                _specialisationRepository.Add(specialisation);
                scope.Complete();
                return CreatedAtAction(nameof(GetSpecialisation), new { id = specialisation.SpecialisationId }, specialisation);
            }
        }

        // DELETE: api/Specialisations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecialisation(int id)
        {
            _specialisationRepository.Delete(id);
            return new OkResult();
        }
    }
}
