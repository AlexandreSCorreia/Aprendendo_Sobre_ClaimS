using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text.Json;
using WebApplication1.Models;

public class CustomAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        var profileInfoClaim = user.Claims.FirstOrDefault(c => c.Type == "profile_info");

        if (profileInfoClaim != null)
        {
            var profileInfo = JsonSerializer.Deserialize<ProfileInfo>(profileInfoClaim.Value);
            var menuOptions = profileInfo.MenuOptions.Select(m => m.Action).ToList();

            // Verificar se a rota atual está presente nas opções de menu do usuário
            if (!menuOptions.Contains(context.RouteData.Values["action"].ToString()))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}