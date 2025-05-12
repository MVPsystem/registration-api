using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Models;

namespace RegistrationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private static List<Registration> _registrations = new();

        [HttpGet]
        public ActionResult<IEnumerable<Registration>> Get() => Ok(_registrations);

        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            registration.Id = _registrations.Count + 1;
            _registrations.Add(registration);
            return Ok(registration);
        }
    }
}
