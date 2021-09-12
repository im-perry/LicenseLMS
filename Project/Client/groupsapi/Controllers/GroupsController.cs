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
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // GET: Groups
        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = _groupRepository.GetAll();
            return new OkObjectResult(groups);
        }

        // GET: Groups/5
        [HttpGet("{id}")]
        public IActionResult GetGroup([FromRoute] Guid id)
        {
            var group = _groupRepository.GetGroupById(id);
            return new OkObjectResult(group);
        }

        // PUT: Groups
        [HttpPut("{group}")]
        public IActionResult PutGroup([FromBody] Group group)
        {
            if (group != null)
            {
                using (var scope = new TransactionScope())
                {
                    _groupRepository.Update(group);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: Groups
        [HttpPost]
        public IActionResult PostGroup([FromBody] Group group)
        {
            using (var scope = new TransactionScope())
            {
                _groupRepository.Add(group);
                scope.Complete();
                return CreatedAtAction(nameof(GetGroup), new { id = group.GroupId }, group);
            }
        }

        // DELETE: Groups/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGroup([FromRoute] Guid id)
        {
            _groupRepository.Delete(id);
            return new OkResult();
        }
    }
}
