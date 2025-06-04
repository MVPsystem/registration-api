using RegistrationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private static List<Registration> registrations = new List<Registration>();

        private readonly HttpClient _httpClient = new HttpClient();

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
        public async Task<ActionResult<Registration>> CreateRegistration(Registration registration)
        {
            
            string eventApiUrl = $"https://strugglereventapi-bwbkc7eehkhubbfs.swedencentral-01.azurewebsites.net/api/events/{registration.EventId}/sell-ticket";

            var response = await _httpClient.PostAsync(eventApiUrl, null);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Unable to register: tickets might be sold out.");
            }

            registration.Id = registrations.Count + 1;
            registration.RegistrationDate = System.DateTime.Now;
            registrations.Add(registration);

            return CreatedAtAction(nameof(GetRegistrations), new { id = registration.Id }, registration);
        }
    }
}
