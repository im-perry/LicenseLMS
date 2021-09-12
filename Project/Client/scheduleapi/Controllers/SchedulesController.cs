using System;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scheduleapi.Repositories;
using ScheduleAPI.Models;

namespace scheduleapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // GET: Schedules
        [HttpGet]
        public IActionResult GetSchedules()
        {
            var schedules = _scheduleRepository.GetAll();
            return new OkObjectResult(schedules);
        }

        // GET: Schedules/5
        [HttpGet("{id}")]
        public IActionResult GetSchedule([FromRoute] Guid id)
        {
            var schedule = _scheduleRepository.GetScheduleById(id);
            return new OkObjectResult(schedule);
        }

        // PUT: Schedules/5
        [HttpPut("{schedule}")]
        public IActionResult PutSchedule([FromBody] Schedule schedule)
        {
            if (schedule != null)
                {
                    using (var scope = new TransactionScope())
                    {
                    _scheduleRepository.Update(schedule);
                        scope.Complete();
                        return new OkResult();
                    }
                }

            return new NoContentResult();
        }

        // POST: Schedules
        [HttpPost]
        public IActionResult PostSchedule([FromBody] Schedule schedule)
        {
            using (var scope = new TransactionScope())
            {
                _scheduleRepository.Add(schedule);
                scope.Complete();
                return CreatedAtAction(nameof(GetSchedule), new { id = schedule.ScheduleId }, schedule);
            }
        }

        // DELETE: Schedules/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule([FromRoute] Guid id)
        {
            _scheduleRepository.Delete(id);
            return new OkResult();
        }
    }
}
