using Ness.ExemploWeb.Dados.Repositorios;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ness.ExemploWeb.Aplicacao
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IRepositorioCliente repositorioCliente;
        private readonly IServicoCriptografia servicoCriptografia;

        public ServicoCliente(IRepositorioCliente repositorioCliente, IServicoCriptografia servicoCriptografia)
        {
            this.repositorioCliente = repositorioCliente ?? throw new ArgumentNullException(nameof(repositorioCliente));
            this.servicoCriptografia = servicoCriptografia ?? throw new ArgumentNullException(nameof(servicoCriptografia));
        }

        public void Atualizar(Cliente cliente)
        {
            ValidarCliente(cliente);
            VerificarLoginExistente(cliente);            
            repositorioCliente.Alterar(cliente);
        }

        private void VerificarLoginExistente(Cliente cliente)
        {
            var clienteBase = repositorioCliente.ObterPorCPF(cliente.CPF);
            if (clienteBase != null && cliente.Id != clienteBase.Id)
                throw new Exception("Paciente já existe na base de dados");
        }

        public void Inserir(Cliente cliente)
        {
            ValidarCliente(cliente);
            VerificarLoginExistente(cliente);
            repositorioCliente.Incluir(cliente);
        }

        public void Remover(Cliente cliente)
        {
            ValidarCliente(cliente);
            repositorioCliente.Excluir(cliente.Id);
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new NullReferenceException(nameof(cliente));
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            return repositorioCliente.ObterTodos();
        }

        public Cliente ObterPorId(long id)
        {
            return repositorioCliente.ObterPorId(id);
        }

       

    }
}
