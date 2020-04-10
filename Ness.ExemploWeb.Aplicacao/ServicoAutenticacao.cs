using System;
using System.Security.Authentication;
using Ness.ExemploWeb.Dominio;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;
using Ness.ExemploWeb.Dominio.Servicos;

namespace Ness.ExemploWeb.Aplicacao
{
    public class ServicoAutenticacao : IServicoAutenticacao
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IServicoCriptografia servicoCriptografia;

        public ServicoAutenticacao(IRepositorioUsuario repositorioUsuario, IServicoCriptografia servicoCriptografia)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.servicoCriptografia = servicoCriptografia ?? throw new ArgumentNullException(nameof(servicoCriptografia));
        }

        public bool Autenticar(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            {
                LancarExcecaoAutenticacao();
            }

            Usuario usuario = repositorioUsuario.ObterPorLogin(login);
            if (usuario == null)
            {
                LancarExcecaoAutenticacao();
            }

            if (!servicoCriptografia.Verificar(usuario.Senha, senha))
            {
                LancarExcecaoAutenticacao();
            }

            usuario.UltimoLogin = DateTime.Now;

            repositorioUsuario.Alterar(usuario);

            return true;
        }

        private void LancarExcecaoAutenticacao()
        {
            throw new AuthenticationException("Usuário ou senha inválidos!");
        }
    }
}
