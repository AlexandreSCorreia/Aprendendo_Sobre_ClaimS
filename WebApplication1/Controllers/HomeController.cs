using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbConnection _connection;

        public HomeController(ILogger<HomeController> logger, IDbConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        [Authorize]
        public IActionResult Index()
        {
            var profileInfoClaim = User.FindFirst("profile_info");
            if (profileInfoClaim != null)
            {
                var profileInfo = JsonSerializer.Deserialize<ProfileInfo>(profileInfoClaim.Value);
                ViewData["Type"] = profileInfo.Type;
                ViewData["MenuOptions"] = profileInfo.MenuOptions;
            }
           // Teste Dapper
           // IEnumerable<Usuario> usuarios = _connection.Query<Usuario>("SELECT * FROM usuario");
           // Console.WriteLine(usuarios);
            return View();
        }

        [Authorize(Policy = "EmployeeOnly")]
        [CustomAuthorization]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Secret()
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
