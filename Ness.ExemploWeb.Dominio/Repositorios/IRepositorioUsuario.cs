using System.Linq;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dominio.Repositorios
{
    public interface IRepositorioUsuario: IRepositorio<Usuario>
    {
        Usuario ObterPorLogin(string login);
    }
}