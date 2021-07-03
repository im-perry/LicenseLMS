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
    public class ClassLessonsController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;

        public ClassLessonsController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        // GET: ClassLessons
        [HttpGet]
        public IActionResult GetClassLessons()
        {
            var lessons = _lessonRepository.GetAll();
            return new OkObjectResult(lessons);
        }

        // GET: ClassLessons/5
        [HttpGet("{id}")]
        public IActionResult GetClassLesson(int id)
        {
            var lesson = _lessonRepository.GetLessonById(id);
            return new OkObjectResult(lesson);
        }

        // PUT: ClassLessons/
        [HttpPut]
        public IActionResult PutClassLesson(ClassLesson lesson)
        {
            if (lesson != null)
            {
                using (var scope = new TransactionScope())
                {
                    _lessonRepository.Update(lesson);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: ClassLessons
        [HttpPost]
        public IActionResult PostClassLesson(ClassLesson lesson)
        {
            using (var scope = new TransactionScope())
            {
                _lessonRepository.Add(lesson);
                scope.Complete();
                return CreatedAtAction(nameof(GetClassLesson), new { id = lesson.LessonId }, lesson);
            }
        }

        // DELETE: ClassLessons/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClassLesson(int id)
        {
            _lessonRepository.Delete(id);
            return new OkResult();
        }
    }
}
