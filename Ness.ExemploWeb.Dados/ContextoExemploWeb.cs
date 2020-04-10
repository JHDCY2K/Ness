using System;
using Microsoft.EntityFrameworkCore;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dados
{
    public class ContextoExemploNess : DbContext
    {
        private readonly string _stringConexao;

		private DbContextOptions<ContextoExemploNess> options;

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public ContextoExemploNess(string stringConexao)
        {
            if (string.IsNullOrWhiteSpace(stringConexao))
                throw new ArgumentNullException(nameof(stringConexao));

            _stringConexao = stringConexao;
        }

		public ContextoExemploNess(DbContextOptions<ContextoExemploNess> options)
        {
            this.options = options;
        }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            #region ExemploWeb-metadado
            #endregion

            base.OnModelCreating(builder);
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_stringConexao);
        }
    }
}