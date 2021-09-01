using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using groupsapi.Repositories;
using System.Transactions;
using GroupsAPI.Models;
using System;

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

        // GET: Subgroups
        [HttpGet]
        public IActionResult GetSubgroups()
        {
            var subgroups = _subgroupRepository.GetAll();
            return new OkObjectResult(subgroups);
        }

        // GET: Subgroups/5
        [HttpGet("{id}")]
        public IActionResult GetSubgroup([FromRoute] string id)
        {
            var subgroups = _subgroupRepository.GetSubgroupById(id);
            return new OkObjectResult(subgroups);
        }

        // PUT: Subgroups
        [HttpPut("{subgroup}")]
        public IActionResult PutSubgroup([FromBody] Subgroup subgroup)
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

        // POST: Subgroups
        [HttpPost]
        public IActionResult PostSubgroup([FromBody] Subgroup subgroup)
        {
            using (var scope = new TransactionScope())
            {
                _subgroupRepository.Add(subgroup);
                scope.Complete();
                return CreatedAtAction(nameof(GetSubgroup), new { id = subgroup.SubgroupId }, subgroup);
            }
        }

        // DELETE: Subgroups/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubgroup([FromRoute] string id)
        {
            _subgroupRepository.Delete(id);
            return new OkResult();
        }
    }
}
