using System;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Dados
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoExemploNess _contexto;

        public UnitOfWork(ContextoExemploNess contexto)
        {
            if (contexto == null)
                throw new ArgumentNullException(nameof(contexto));

            _contexto = contexto;
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }
    }
}