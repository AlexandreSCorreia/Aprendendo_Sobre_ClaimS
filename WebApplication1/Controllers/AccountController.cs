using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly List<Menus> menus = new List<Menus> {
            new Menus { Id = 1, Nome = "Home", Action="Index", Controller="Home"},
            new Menus { Id = 2, Nome = "Privacy", Action="Privacy", Controller="Home"},
            new Menus { Id = 3, Nome = "Secret", Action="Secret", Controller="Home"},
            new Menus { Id = 4, Nome = "Logout", Action="Logout", Controller="Account"}
        };

        private readonly List<Perfils> perfis = new List<Perfils> {
            new Perfils { Id = 1, Nome = "Administrator"},
            new Perfils { Id = 2, Nome = "Visit"}
        };

        private readonly List<Permissao> permissoes = new List<Permissao> {
            new Permissao { Id = 1, Descricao = "Autorizado"},
            new Permissao { Id = 2, Descricao = "Não-Autorizado"}
        };

        private readonly List<PerfilMenus> perfilMenus = new List<PerfilMenus> {
            new PerfilMenus { Id = 1, Perfis_Id = 1, PerfilMenus_Id = 1, Permissao_Id = 1},
            new PerfilMenus { Id = 2, Perfis_Id = 1, PerfilMenus_Id = 2, Permissao_Id = 2},
            new PerfilMenus { Id = 3, Perfis_Id = 1, PerfilMenus_Id = 3, Permissao_Id = 1},
            new PerfilMenus { Id = 4, Perfis_Id = 1, PerfilMenus_Id = 4, Permissao_Id = 1},
            new PerfilMenus { Id = 5, Perfis_Id = 2, PerfilMenus_Id = 1, Permissao_Id = 2},
            new PerfilMenus { Id = 6, Perfis_Id = 2, PerfilMenus_Id = 2, Permissao_Id = 2},
            new PerfilMenus { Id = 7, Perfis_Id = 2, PerfilMenus_Id = 3, Permissao_Id = 1},
            new PerfilMenus { Id = 8, Perfis_Id = 2, PerfilMenus_Id = 4, Permissao_Id = 2},
        };

        private readonly List<Usuario> usuarios = new List<Usuario> {
            new Usuario { Id = 1, Nome = "user1", Email = "usuario1@example.com", Senha = "123456", IdPerfil = 1 },
            new Usuario { Id = 2, Nome = "user2", Email = "usuario2@example.com", Senha = "123456", IdPerfil = 2 }
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Verifica se as credenciais são válidas

            var userEncontrado = usuarios.Where(u => u.Nome.ToUpper() == username.ToUpper() && u.Senha == password).FirstOrDefault();
            if (userEncontrado != null)
            {
                var perfilEncontrado = perfis.Where(p => p.Id == userEncontrado.IdPerfil).FirstOrDefault();

                List<Menus> query = (from pm in perfilMenus
                            join p in perfis on pm.Perfis_Id equals p.Id
                            join m in menus on pm.PerfilMenus_Id equals m.Id
                            join ps in permissoes on pm.Permissao_Id equals ps.Id
                            where p.Id == perfilEncontrado.Id && ps.Id == 1
                            select m).ToList();

                // Cria as Claims para o usuário autenticado
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userEncontrado.Id.ToString()),
                    new Claim(ClaimTypes.Name, userEncontrado.Nome),
                    new Claim(ClaimTypes.Role, perfilEncontrado.Nome),
                    new Claim("profile_info", JsonSerializer.Serialize(new ProfileInfo
                    {
                        Type = perfilEncontrado.Nome,
                        MenuOptions = query
                    }))
                };

                // Cria o objeto de identidade a partir das Claims
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Cria o objeto de principal a partir do objeto de identidade
                var principal = new ClaimsPrincipal(identity);

                // Autentica o usuário
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AcessoNegado()
        {
            var profileInfoClaim = User.FindFirst("profile_info");
            if (profileInfoClaim != null)
            {
                var profileInfo = JsonSerializer.Deserialize<ProfileInfo>(profileInfoClaim.Value);
                ViewData["Type"] = profileInfo.Type;
                ViewData["MenuOptions"] = profileInfo.MenuOptions;
            }

            return View();
        }
    }
}
