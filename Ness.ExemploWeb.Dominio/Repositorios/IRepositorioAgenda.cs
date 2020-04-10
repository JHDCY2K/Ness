using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;
using System;

namespace Ness.ExemploWeb.Dados.Repositorios
{
    public interface IRepositorioAgenda : IRepositorio<Agenda>
    {
        Agenda ValidarData(DateTime dataagenda);

        Agenda ObterAgendaPaciente(long idUsuario);

        Agenda ObterAgenda(long idUsuario);
    }
}