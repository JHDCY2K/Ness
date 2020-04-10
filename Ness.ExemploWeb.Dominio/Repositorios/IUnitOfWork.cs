using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dominio.Repositorios
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}