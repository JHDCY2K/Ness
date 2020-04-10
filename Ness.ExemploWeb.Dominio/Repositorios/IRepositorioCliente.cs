using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Dados.Repositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente ObterPorCPF(string cnpj);
    }
}