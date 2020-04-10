using System;
using System.Security.Cryptography;
using System.Text;

namespace Ness.ExemploWeb.Dominio.Servicos
{
    public class ServicoCriptografia : IServicoCriptografia
    {
        public string Gerar(string senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public bool Verificar(string hashSenha, string senha)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return (0 == comparer.Compare(Gerar(senha), hashSenha));            
        }
    }
}
