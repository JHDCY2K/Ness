
using System;

namespace Ness.ExemploWeb.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime? UltimoLogin { get; set; }
    }
}
