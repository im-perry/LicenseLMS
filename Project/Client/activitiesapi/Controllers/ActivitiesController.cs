﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using activitiesapi;
using activitiesapi.Models;
using Microsoft.AspNetCore.Authorization;
using activitiesapi.Repositories;
using System.Transactions;

namespace activitiesapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        // GET: Activities
        [HttpGet]
        public IActionResult GetActivities()
        {
            var activities = _activityRepository.GetAll();
            return new OkObjectResult(activities);
        }

        // GET: Activities/5
        [HttpGet("{id}")]
        public IActionResult GetActivity(Guid id)
        {
            var activity = _activityRepository.GetActivityById(id);
            return new OkObjectResult(activity);
        }

        // PUT: Activities
        [HttpPut]
        public IActionResult PutActivity(Activity activity)
        {
            if (activity != null)
            {
                using (var scope = new TransactionScope())
                {
                    _activityRepository.Update(activity);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // POST: Activities
        [HttpPost]
        public IActionResult PostActivity(Activity activity)
        {
            using (var scope = new TransactionScope())
            {
                _activityRepository.Add(activity);
                scope.Complete();
                return CreatedAtAction(nameof(GetActivity), new { id = activity.ActivityId }, activity);
            }
        }

        // DELETE: Activities/5
        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(Guid id)
        {
            _activityRepository.Delete(id);
            return new OkResult();
        }
    }
}