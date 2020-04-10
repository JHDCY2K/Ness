using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ness.ExemploWeb.Aplicacao;
using Ness.ExemploWeb.Dados;
using Ness.ExemploWeb.Dados.Repositorios;
using Ness.ExemploWeb.Dominio;
using Ness.ExemploWeb.Dominio.Repositorios;
using Ness.ExemploWeb.Dominio.Servicos;

namespace Ness.ExemploWeb.IoC
{
    public static class RegistrarDependencias
    {
        public static void Registrar(IServiceCollection servicos, IConfiguration configuracao)
        {
            #region ExemploWeb-metadado
            
			
            servicos.AddScoped<IUnitOfWork, UnitOfWork>();
            servicos.AddScoped<ContextoExemploNess>(contexto => new ContextoExemploNess(configuracao.GetConnectionString("DefaultConnection")));

            servicos.AddScoped<IServicoUsuario, ServicoUsuario>();
            servicos.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


            servicos.AddScoped<IRepositorioCliente, RepositorioCliente>();
            servicos.AddScoped<IServicoCliente, ServicoCliente>();

            servicos.AddScoped<IRepositorioAgenda, RepositorioAgenda>();
            servicos.AddScoped<IServicoAgenda, ServicoAgenda>();

            servicos.AddScoped<IServicoAutenticacao, ServicoAutenticacao>();
            servicos.AddScoped<IServicoCriptografia, ServicoCriptografia>();


            



            servicos.AddDbContext<ContextoExemploNess>(options =>
                                                       options.UseSqlServer(configuracao.GetConnectionString("DefaultConnection")));
            #endregion
        }
    }
}
