using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EmtraccWeb.Data;
using EmtraccWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmtraccWeb.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _db;

    public AccountController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Comprobantes");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Clave universal (igual que la app de escritorio)
        if (model.Clave == "@Paradoja2026")
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, "ADMINISTRADOR"),
                new(ClaimTypes.Role, "SUPERADMIN")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("Index", "Comprobantes");
        }

        var hashedClave = ComputeSHA256(model.Clave);

        var usuario = await _db.Accesos
            .FirstOrDefaultAsync(a => a.Usuario == model.Usuario && a.Clave == hashedClave);

        if (usuario == null)
        {
            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View(model);
        }

        if (!string.Equals(usuario.Status, "ACTIVO", StringComparison.OrdinalIgnoreCase))
        {
            ModelState.AddModelError("", "Este usuario se encuentra INACTIVO. Contacte al administrador.");
            return View(model);
        }

        var claims2 = new List<Claim>
        {
            new(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"),
            new(ClaimTypes.Role, usuario.Tipo)
        };

        var identity2 = new ClaimsIdentity(claims2, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity2));

        return RedirectToAction("Index", "Comprobantes");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    private static string ComputeSHA256(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(inputBytes);
        var sb = new StringBuilder();
        foreach (var b in hashBytes)
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }
}
