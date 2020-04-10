using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ness.ExemploWeb.Dados;
using Ness.ExemploWeb.Dominio.Entidades;
using Ness.ExemploWeb.Dominio.Servicos;

namespace Ness.ExemploWeb.Web
{
    public static class InicializacaoBancoDados
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            ContextoExemploNess contextoNess = serviceProvider.GetService(typeof(ContextoExemploNess)) as ContextoExemploNess;
            IServicoCriptografia servicoCriptografia = serviceProvider.GetService(typeof(IServicoCriptografia)) as IServicoCriptografia;

            if (contextoNess.Usuario.Any())
            {
                return;
            }

            var usuario = new Usuario()
            {
                Nome = "Administrator",
                Senha = servicoCriptografia.Gerar("123"),
                Login = "admin",
                Ativo = true,
                DataCriacao = DateTime.Now,
                CriadoPor = "Sistema",
                DataAlteracao = (DateTime?)null,
                AlteradoPor = null,
                UltimoLogin = (DateTime?)null
            };

            contextoNess.Usuario.Add(usuario);

            contextoNess.SaveChanges();

        }
    }
}
