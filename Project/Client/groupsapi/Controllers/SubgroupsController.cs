using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using groupsapi.Repositories;
using System.Transactions;
using GroupsAPI.Models;

namespace groupsapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SubgroupsController : ControllerBase
    {
        private readonly ISubgroupRepository _subgroupRepository;

        public SubgroupsController(ISubgroupRepository subgroupRepository)
        {
            _subgroupRepository = subgroupRepository;
        }

        // GET: api/Subgroups
        [HttpGet]
        public IActionResult GetSubgroups()
        {
            var subgroups = _subgroupRepository.GetAll();
            return new OkObjectResult(subgroups);
        }

        // GET: api/Subgroups/5
        [HttpGet("{id}")]
        public IActionResult GetSubgroup(int id)
        {
            var subgroups = _subgroupRepository.GetSubgroupById(id);
            return new OkObjectResult(subgroups);
        }

        // PUT: api/Subgroups/5
        [HttpPut]
        public IActionResult PutSubgroup( Subgroup subgroup)
        {
            if (subgroup != null)
            {
                using (var scope = new TransactionScope())
                {
                    _subgroupRepository.Update(subgroup);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: api/Subgroups
        [HttpPost]
        public IActionResult PostSubgroup(Subgroup subgroup)
        {
            using (var scope = new TransactionScope())
            {
                _subgroupRepository.Add(subgroup);
                scope.Complete();
                return CreatedAtAction(nameof(GetSubgroup), new { id = subgroup.SubgroupId }, subgroup);
            }
        }

        // DELETE: api/Subgroups/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubgroup(int id)
        {
            _subgroupRepository.Delete(id);
            return new OkResult();
        }
    }
}
