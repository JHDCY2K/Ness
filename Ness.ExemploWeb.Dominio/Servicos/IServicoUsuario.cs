using System.Collections.Generic;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dominio
{
    public interface IServicoUsuario
    {
        Usuario ObterPorId(long id);
        IEnumerable<Usuario> ObterUsuarios();
        void Atualizar(Usuario usuario, string alteradoPor, string senhaAnterior);
        void Remover(Usuario usuario);
        void Inserir(Usuario usuario, string criadoPor);
        bool UsuarioEstaAtivo(string login);
    }
}