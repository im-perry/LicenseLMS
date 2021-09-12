using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using roomsmanagementapi.Repositories;
using System;
using System.Transactions;
using Type = RoomsAPI.Models.Type;

namespace roomsmanagementapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TypesController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;

        public TypesController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        // GET: Types
        [HttpGet]
        public IActionResult GetTypes()
        {
            var types = _typeRepository.GetAll();
            return new OkObjectResult(types);
        }

        // GET: Types/5
        [HttpGet("{id}")]
        public IActionResult GetRoom([FromRoute] Guid id)
        {
            var type = _typeRepository.GetTypeById(id);
            return new OkObjectResult(type);
        }

        // PUT: Types
        [HttpPut("{type}")]
        public IActionResult PutRoom([FromBody] Type type)
        {
            if (type != null)
            {
                using (var scope = new TransactionScope())
                {
                    _typeRepository.Update(type);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: Types
        [HttpPost]
        public IActionResult PostType([FromBody] Type type)
        {
            using (var scope = new TransactionScope())
            {
                _typeRepository.Add(type);
                scope.Complete();
                return CreatedAtAction(nameof(GetRoom), new { id = type.TypeId }, type);
            }
        }

        // DELETE: Types/5
        [HttpDelete("{id}")]
        public IActionResult DeleteType([FromRoute] Guid id)
        {
            _typeRepository.Delete(id);
            return new OkResult();
        }
    }
}
