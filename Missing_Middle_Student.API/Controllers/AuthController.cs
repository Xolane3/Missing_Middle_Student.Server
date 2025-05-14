using Microsoft.AspNetCore.Mvc;
using Missing_Middle_Student.API.DTOs;
using System;

namespace Missing_Middle_Student.API.Controllers
    [Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var staff = _context.Staffs.FirstOrDefault(s => s.Email == request.Email && s.Password == request.Password);

        if (staff == null)
            return Unauthorized(new { message = "Invalid credentials" });

        var response = new LoginResponse
        {
            Role = staff.Role,
            Surname = staff.Surname,
            Initails = staff.Initails
        };

        return Ok(response);
    }
}
}
