using System;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using activitiesapi.Repositories;
using ActivitiesAPI.Models;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult GetActivity([FromRoute] Guid id)
        {
            var activity = _activityRepository.GetActivityById(id);
            return new OkObjectResult(activity);
        }

        // PUT: Activities
        [HttpPut("{activity}")]
        public IActionResult PutActivity([FromBody] Activity activity)
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
        public IActionResult PostActivity([FromBody] Activity activity)
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
        public IActionResult DeleteActivity([FromRoute] Guid id)
        {
            _activityRepository.Delete(id);
            return new OkResult();
        }
    }
}
