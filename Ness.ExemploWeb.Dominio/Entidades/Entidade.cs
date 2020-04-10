using System;
using System.Collections.Generic;
using System.Text;

namespace Ness.ExemploWeb.Dominio.Entidades
{
    public class Entidade
    {
        public long Id { get; set; }
        public string CriadoPor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
