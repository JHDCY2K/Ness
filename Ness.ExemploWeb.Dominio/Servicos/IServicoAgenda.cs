using Ness.ExemploWeb.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Ness.ExemploWeb.Dominio.Servicos
{
    public interface IServicoAgenda
    {
        Agenda ValidarData(DateTime dataagenda);
        IEnumerable<Agenda> ObterAgendaPaciente(long idcliente);

        Agenda ObterAgenda(long idcliente);

        void Atualizar(Agenda agenda);
        void Remover(Agenda agenda);
        void Inserir(Agenda agenda);
    }
}
