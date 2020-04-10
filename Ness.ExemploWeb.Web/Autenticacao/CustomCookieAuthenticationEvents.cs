using Ness.ExemploWeb.Dominio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ness.ExemploWeb.Web
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly IServicoUsuario servicoUsuario;

        public CustomCookieAuthenticationEvents(IServicoUsuario servicoUsuario)
        {
            this.servicoUsuario = servicoUsuario ?? throw new ArgumentNullException(nameof(servicoUsuario));
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;
            
            if (!servicoUsuario.UsuarioEstaAtivo(userPrincipal.Identity.Name))
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
