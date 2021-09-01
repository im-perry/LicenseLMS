using Microsoft.AspNetCore.Mvc;
using groupsapi.Repositories;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using GroupsAPI.Models;
using System;

namespace groupsapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SpecialisationsController : ControllerBase
    {
        private readonly ISpecialisationRepository _specialisationRepository;

        public SpecialisationsController(ISpecialisationRepository specialisationRepository)
        {
            _specialisationRepository = specialisationRepository;
        }

        // GET: Specialisations
        [HttpGet]
        public IActionResult GetSpecialisations()
        {
            var specialisations = _specialisationRepository.GetAll();
            return new OkObjectResult(specialisations);
        }

        // GET: Specialisations/5
        [HttpGet("{id}")]
        public IActionResult GetSpecialisation([FromRoute] string id)
        {
            var specialisation = _specialisationRepository.GetSpecialisationById(id);
            return new OkObjectResult(specialisation);
        }

        // PUT: Specialisations/5
        [HttpPut("{specialisation}")]
        public IActionResult PutSpecialisation([FromBody] Specialisation specialisation)
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

        // POST: Specialisations
        [HttpPost]
        public IActionResult PostSpecialisation([FromBody] Specialisation specialisation)
        {
            using (var scope = new TransactionScope())
            {
                _specialisationRepository.Add(specialisation);
                scope.Complete();
                return CreatedAtAction(nameof(GetSpecialisation), new { id = specialisation.SpecialisationId }, specialisation);
            }
        }

        // DELETE: Specialisations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecialisation([FromRoute] string id)
        {
            _specialisationRepository.Delete(id);
            return new OkResult();
        }
    }
}
