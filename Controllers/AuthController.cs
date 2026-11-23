using System.Security.Claims;
using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_6.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("login/discord")]
    public IActionResult LoginDiscord() =>
        Challenge(new AuthenticationProperties { RedirectUri = "/api/auth/me" }, DiscordAuthenticationDefaults.AuthenticationScheme);

    [HttpGet("login/google")]
    public IActionResult LoginGoogle() =>
        Challenge(new AuthenticationProperties { RedirectUri = "/api/auth/me" }, GoogleDefaults.AuthenticationScheme);

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        return Ok(new
        {
            autenticado = User.Identity?.IsAuthenticated ?? false,
            proveedor = User.Identity?.AuthenticationType,
            idExterno = User.FindFirstValue(ClaimTypes.NameIdentifier),
            nombre = User.FindFirstValue(ClaimTypes.Name),
            correo = User.FindFirstValue(ClaimTypes.Email)
        });
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { mensaje = "Sesión cerrada correctamente" });
    }
}