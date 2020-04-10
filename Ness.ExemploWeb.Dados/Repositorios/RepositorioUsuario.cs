using System.Linq;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Dados.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {

        public RepositorioUsuario(ContextoExemploNess ContextoExemploNess) : base(ContextoExemploNess)
        {
        }

        public Usuario ObterPorLogin(string login)
        {
            return Contexto.Set<Usuario>()
                        .Where(p => p.Login == login)
                        .SingleOrDefault();
                        
        }

    }
}
