using System;

namespace Ness.ExemploWeb.Dtos
{
    public class UsuarioModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string SenhaAnterior { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public bool Ativo { get; set; }
        public string CriadoPor { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
