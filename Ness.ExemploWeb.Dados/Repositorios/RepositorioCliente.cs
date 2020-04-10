using System.Linq;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Dados.Repositorios
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ContextoExemploNess contextoExemploWeb) : base(contextoExemploWeb)
        {
        }

        public Cliente ObterPorCPF(string cnpj)
        {
            return Contexto.Set<Cliente>()
                        .Where(p => p.CPF == cnpj)
                        .SingleOrDefault();

        }
    }
}
