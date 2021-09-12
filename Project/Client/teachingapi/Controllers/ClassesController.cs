using System;
using System.Security.Claims;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teachingapi.Repositories;
using TeachingAPI.Models;

namespace teachingapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassesController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        // GET: Classes
        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = _classRepository.GetAll();
            return new OkObjectResult(classes);
        }

        // GET: Classes/5
        [HttpGet("{id}")]
        public IActionResult GetClass([FromRoute] Guid id)
        {
            var classs = _classRepository.GetClassById(id);
            return new OkObjectResult(classs);
        }

        // PUT: Classes/5
        [HttpPut("{classs}")]
        public IActionResult PutClass([FromBody] Class classs)
        {
            if (classs != null)
            {
                using (var scope = new TransactionScope())
                {
                    _classRepository.Update(classs);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: Classes
        [HttpPost]
        public IActionResult PostClass([FromBody] Class classs)
        {
            using (var scope = new TransactionScope())
            {
                _classRepository.Add(classs);
                classs.AuthorName = User.FindFirstValue(ClaimTypes.NameIdentifier);
                scope.Complete();
                return CreatedAtAction(nameof(GetClass), new { id = classs.ClassId }, classs);
            }
        }

        // DELETE: Classes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClass([FromRoute] Guid id)
        {
            _classRepository.Delete(id);
            return new OkResult();
        }
    }
}
