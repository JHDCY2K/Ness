using Ness.ExemploWeb.Dados.Repositorios;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ness.ExemploWeb.Aplicacao
{
    public class ServicoAgenda : IServicoAgenda
    {
        private readonly IRepositorioAgenda repositorioAgenda;
        private readonly IServicoCriptografia servicoCriptografia;

        public ServicoAgenda(IRepositorioAgenda repositorioAgenda, IServicoCriptografia servicoCriptografia)
        {
            this.repositorioAgenda = repositorioAgenda ?? throw new ArgumentNullException(nameof(repositorioAgenda));
            this.servicoCriptografia = servicoCriptografia ?? throw new ArgumentNullException(nameof(servicoCriptografia));
        }

        public void Atualizar(Agenda agenda)
        {
            ValidarAgenda(agenda);
            repositorioAgenda.Alterar(agenda);
        }

        

        public void Inserir(Agenda agenda)
        {
            ValidarAgenda(agenda);
            repositorioAgenda.Incluir(agenda);
        }

        public void Remover(Agenda agenda)
        {
            ValidarAgenda(agenda);
            repositorioAgenda.Excluir(agenda.Id);
        }

        private void ValidarAgenda(Agenda agenda)
        {
            if (agenda == null)
                throw new NullReferenceException(nameof(agenda));
        }


        public IEnumerable<Agenda> ObterAgendaPaciente(long idCliente)
        {
            return repositorioAgenda.ObterTodos();
        }

        public Agenda ObterAgenda(long id)
        {
            return repositorioAgenda.ObterPorId(id);
        }

        public Agenda ObterPorId(long id)
        {
            return repositorioAgenda.ObterPorId(id);
        }

        public Agenda ValidarData(DateTime dataagenda)
        {
            var agenda = repositorioAgenda.ValidarData(dataagenda);
            if (agenda != null)
                throw new NullReferenceException();
            return agenda;
        }

    }
}
