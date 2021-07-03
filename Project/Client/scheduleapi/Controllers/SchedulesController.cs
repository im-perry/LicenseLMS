﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scheduleapi;
using scheduleapi.Models;
using scheduleapi.Repositories;

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
        public IActionResult GetSchedule(int id)
        {
            var schedule = _scheduleRepository.GetScheduleById(id);
            return new OkObjectResult(schedule);
        }

        // PUT: Schedules/5
        [HttpPut]
        public IActionResult PutSchedule(Schedule schedule)
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
        public IActionResult PostSchedule(Schedule schedule)
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
        public IActionResult DeleteSchedule(int id)
        {
            _scheduleRepository.Delete(id);
            return new OkResult();
        }
    }
}