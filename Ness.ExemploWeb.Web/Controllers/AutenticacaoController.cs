using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using Ness.ExemploWeb.Dominio;
using Ness.ExemploWeb.Dominio.Repositorios;
using Ness.ExemploWeb.Dtos;

namespace Ness.ExemploWeb.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IServicoAutenticacao servicoAutenticacao;
        private readonly IUnitOfWork unitOfWork;
        public AutenticacaoController(IServicoAutenticacao servicoAutenticacao, IUnitOfWork unitOfWork)
        {
            this.servicoAutenticacao = servicoAutenticacao ?? throw new ArgumentNullException(nameof(servicoAutenticacao));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    if (servicoAutenticacao.Autenticar(model.Login, model.Senha))
                    {

                        await AutenticacaoCookie.Login(model, returnUrl, HttpContext);

                        unitOfWork.SaveChanges();

                        if (!string.IsNullOrWhiteSpace(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}