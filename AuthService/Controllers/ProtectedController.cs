using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

/// <summary>
/// Protected endpoints that demonstrate authorization.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public sealed class ProtectedController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "You are authenticated.",
            username = User.Identity?.Name,
            role = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminOnly()
    {
        return Ok(new
        {
            message = "Only admins can access this endpoint.",
            username = User.Identity?.Name
        });
    }
}
