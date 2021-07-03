using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using groupsapi;
using groupsapi.Models;
using Microsoft.AspNetCore.Authorization;
using groupsapi.Repositories;
using System.Transactions;

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

        // GET: api/Groups
        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = _groupRepository.GetAll();
            return new OkObjectResult(groups);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public IActionResult GetGroup(int id)
        {
            var group = _groupRepository.GetGroupById(id);
            return new OkObjectResult(group);
        }

        // PUT: api/Groups/5
        [HttpPut]
        public IActionResult PutGroup(Group group)
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

        // POST: api/Groups
        [HttpPost]
        public IActionResult PostGroup(Group group)
        {
            using (var scope = new TransactionScope())
            {
                _groupRepository.Add(group);
                scope.Complete();
                return CreatedAtAction(nameof(GetGroup), new { id = group.GroupId }, group);
            }
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            _groupRepository.Delete(id);
            return new OkResult();
        }
    }
}
