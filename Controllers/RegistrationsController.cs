using RegistrationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private static List<Registration> registrations = new List<Registration>();

        [HttpGet]
        public ActionResult<IEnumerable<Registration>> GetRegistrations()
        {
            return Ok(registrations);
        }

        [HttpGet("{eventId}")]
        public ActionResult<IEnumerable<Registration>> GetRegistrationsForEvent(int eventId)
        {
            var eventRegistrations = registrations.Where(r => r.EventId == eventId).ToList();
            return Ok(eventRegistrations);
        }

        [HttpPost]
        public ActionResult<Registration> CreateRegistration(Registration registration)
        {
            registration.Id = registrations.Count + 1;
            registration.RegistrationDate = DateTime.Now;
            registrations.Add(registration);
            return CreatedAtAction(nameof(GetRegistrations), new { id = registration.Id }, registration);
        }
    }
}