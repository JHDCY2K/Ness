using System.Linq;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Repositorios;

namespace Ness.ExemploWeb.Dados.Repositorios
{
    public class RepositorioAgenda : Repositorio<Agenda>, IRepositorioAgenda
    {
        public RepositorioAgenda(ContextoExemploNess contextoExemploWeb) : base(contextoExemploWeb)
        {
        }

        public Agenda ValidarData(System.DateTime dataagenda)
        {
            return Contexto.Set<Agenda>()
                        .Where(p => p.DataAgenda == dataagenda)
                        .SingleOrDefault();

        }

        public Agenda ObterAgendaPaciente(long idCliente)
        {
            return Contexto.Set<Agenda>()
                        .Where(p => p.IdCliente == idCliente)
                        .SingleOrDefault();

        }

        public Agenda ObterAgenda(long idUsuario)
        {
            throw new System.NotImplementedException();
        }
    }
}
