using Ness.ExemploWeb.Dominio.Entidades;
using System.Collections.Generic;

namespace Ness.ExemploWeb.Dominio.Servicos
{
    public interface IServicoCliente
    {
        Cliente ObterPorId(long id);
        IEnumerable<Cliente> ObterClientes();

        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
        void Inserir(Cliente cliente);
    }
}
