using System.Security.Claims;
using AuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AuthService.Controllers;

/// <summary>
/// Authentication endpoints for obtaining JWT tokens.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public sealed class AuthController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    public AuthController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    /// <summary>
    /// Authenticates user and returns a JWT token.
    /// Sample users: admin/Admin@123, user/User@123, staff/Staff@123
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Username) || string.IsNullOrWhiteSpace(request?.Password))
        {
            return BadRequest(new { error = "Username and password are required." });
        }

        var token = _authenticationService.Authenticate(request.Username, request.Password, out var expiresUtc);
        if (token is null)
        {
            return Unauthorized(new { error = "Invalid credentials. Try admin/Admin@123, user/User@123 or staff/Staff@123." });
        }

        return Ok(new
        {
            token,
            expiresUtc,
            type = "Bearer"
        });
    }

    /// <summary>
    /// Returns current user data from token claims.
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUser()
    {
        var displayName = User.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value ?? string.Empty;
        var role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;

        return Ok(new
        {
            username = User.Identity?.Name,
            displayName = displayName,
            role = role
        });
    }
}

public sealed class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
