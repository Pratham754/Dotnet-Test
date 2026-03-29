using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Services;

/// <summary>
/// Creates JWT tokens for valid users.
/// </summary>
public sealed class AuthenticationService
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserService _userService;

    public AuthenticationService(IOptions<JwtOptions> jwtOptions, UserService userService)
    {
        _jwtOptions = jwtOptions.Value;
        _userService = userService;
    }

    public string? Authenticate(string username, string password, out DateTime expiresUtc)
    {
        expiresUtc = DateTime.UtcNow.AddMinutes(60);
        var user = _userService.ValidateCredentials(username, password);
        if (user is null)
        {
            return null;
        }

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.UniqueName, user.DisplayName),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: expiresUtc,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
