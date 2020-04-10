using System.Linq;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dominio.Repositorios
{
    public interface IRepositorio<T> where T: Entidade, new()
    {
        void Incluir(T entidade);
        void Alterar(T entidade);
        void Excluir(long id);
        IQueryable<T> ObterTodos();
        T ObterPorId(long id);
    }
}