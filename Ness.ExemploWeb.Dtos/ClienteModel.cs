﻿using System;

namespace Ness.ExemploWeb.Dtos
{
    public class ClienteModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
    }
}