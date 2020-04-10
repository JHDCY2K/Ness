using System;
using System.Linq;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Dados.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade, new()
    {
        protected readonly ContextoExemploNess Contexto;

        public Repositorio(ContextoExemploNess contexto)
        {
            if (contexto == null)
                throw new ArgumentNullException(nameof(contexto));

            Contexto = contexto;
        }

        public void Alterar(T entidade)
        {
            Contexto.Set<T>().Update(entidade);
        }

        public void Excluir(long id)
        {
            Contexto.Set<T>().Remove(ObterPorId(id));
        }

        public void Incluir(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
        }

        public T ObterPorId(long id)
        {
            return Contexto.Set<T>().Find(id);
        }

        public IQueryable<T> ObterTodos()
        {
            return Contexto.Set<T>();
        }
    }
}
