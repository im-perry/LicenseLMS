using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teachingapi;
using teachingapi.Models;
using teachingapi.Repositories;

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
        public IActionResult GetClass(int id)
        {
            var classs = _classRepository.GetClassById(id);
            return new OkObjectResult(classs);
        }

        // PUT: Classes/5
        [HttpPut]
        public IActionResult PutClass(Class classs)
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
        public IActionResult PostClass(Class classs)
        {
            using (var scope = new TransactionScope())
            {
                _classRepository.Add(classs);
                scope.Complete();
                return CreatedAtAction(nameof(GetClass), new { id = classs.ClassId }, classs);
            }
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            _classRepository.Delete(id);
            return new OkResult();
        }
    }
}
