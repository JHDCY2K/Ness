using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Omu.ValueInjecter;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio;
using Ness.ExemploWeb.Dtos;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Web.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {

        private readonly IServicoUsuario servicoUsuario;
        private readonly IUnitOfWork unitOfWork;

        public UsuarioController(IServicoUsuario servicoUsuario, IUnitOfWork unitOfWork)
        {
            this.servicoUsuario = servicoUsuario ?? throw new ArgumentNullException(nameof(servicoUsuario));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            var usuarios = servicoUsuario.ObterUsuarios();
            List<UsuarioModel> usuariosModel = TransformarUsuariosEmModel(usuarios);
            return View(usuariosModel);
        }

        private static List<UsuarioModel> TransformarUsuariosEmModel(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
            foreach (var usuario in usuarios)
            {
                UsuarioModel usuarioModel = TransformarUsuarioEmModel(usuario);
                usuariosModel.Add(usuarioModel);
            }

            return usuariosModel;
        }

        private static UsuarioModel TransformarUsuarioEmModel(Usuario usuario)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarioModel.InjectFrom(usuario);
            return usuarioModel;
        }

        // GET: Usuarios/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = servicoUsuario.ObterPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            UsuarioModel usuarioModel = TransformarUsuarioEmModel(usuario);

            return View(usuarioModel);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Login,Senha,Ativo,UltimoLogin,Id,CriadoPor,DataCriacao,AlteradoPor,DataAlteracao")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario.InjectFrom(usuarioModel);
                    servicoUsuario.Inserir(usuario, User.Identity.Name);
                    unitOfWork.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(usuarioModel);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = servicoUsuario.ObterPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            UsuarioModel usuarioModel = TransformarUsuarioEmModel(usuario);
            usuarioModel.SenhaAnterior = usuario.Senha;
            return View(usuarioModel);
        }

        // POST: Usuarios/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Nome,Login,Senha,Ativo,UltimoLogin,Id,CriadoPor,DataCriacao,AlteradoPor,DataAlteracao,SenhaAnterior")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = servicoUsuario.ObterPorId(usuarioModel.Id);
                    usuario.InjectFrom(usuarioModel);

                    servicoUsuario.Atualizar(usuario, User.Identity.Name, usuarioModel.SenhaAnterior);
                    unitOfWork.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(usuarioModel);
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = servicoUsuario.ObterPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            UsuarioModel usuarioModel = TransformarUsuarioEmModel(usuario);

            return View(usuarioModel);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var usuario = servicoUsuario.ObterPorId(id);
            servicoUsuario.Remover(usuario);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
