using System;
using System.Collections.Generic;
using Ness.ExemploWeb.Dominio;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;
using Ness.ExemploWeb.Dominio.Servicos;

namespace Ness.ExemploWeb.Aplicacao
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IServicoCriptografia servicoCriptografia;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, IServicoCriptografia servicoCriptografia)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.servicoCriptografia = servicoCriptografia ?? throw new ArgumentNullException(nameof(servicoCriptografia));
        }
        public void Atualizar(Usuario usuario, string alteradoPor, string senhaAnterior)
        {
            ValidarUsuario(usuario);
            VerificarLoginExistente(usuario);

            usuario.DataAlteracao = DateTime.Now;
            usuario.AlteradoPor = alteradoPor;

            if (!string.IsNullOrWhiteSpace(usuario.Senha))
            {                
                usuario.Senha = servicoCriptografia.Gerar(usuario.Senha);
            }
            else
            {
                usuario.Senha = senhaAnterior;
            }

            repositorioUsuario.Alterar(usuario);
        }

        private void VerificarLoginExistente(Usuario usuario)
        {
            var usuarioBase = repositorioUsuario.ObterPorLogin(usuario.Login);
            if (usuarioBase != null && usuario.Id != usuarioBase.Id)
                throw new Exception("Login já existe na base de dados");
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new NullReferenceException(nameof(usuario));
        }

        public void Inserir(Usuario usuario, string criadoPor)
        {
            ValidarUsuario(usuario);
            VerificarLoginExistente(usuario);
            usuario.Senha = servicoCriptografia.Gerar(usuario.Senha);
            usuario.DataCriacao = DateTime.Now;
            usuario.CriadoPor = criadoPor;

            repositorioUsuario.Incluir(usuario);
        }

        public Usuario ObterPorId(long id)
        {
            return repositorioUsuario.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            return repositorioUsuario.ObterTodos();
        }

        public void Remover(Usuario usuario)
        {
            ValidarUsuario(usuario);
            repositorioUsuario.Excluir(usuario.Id);
        }

        public bool UsuarioEstaAtivo(string login)
        {
            var usuario = repositorioUsuario.ObterPorLogin(login);
            if (usuario == null)
                throw new NullReferenceException();

            return usuario.Ativo;
        }
    }
}
