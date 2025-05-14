using Microsoft.AspNetCore.Mvc;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Services.Studentservices;

namespace Missing_Middle_Student.API.Controllers.StudentComtroller
{
    public class LoginController : ControllerBase
    {
        private readonly IApplicantService _appicantService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var applicant = await _appicantService.LoginAsync(request);
            if (applicant == null)
            {
                return Unauthorized(new { message = "Invalid email/student number or password" });
            }

            return Ok(applicant);
        }
    }
}
