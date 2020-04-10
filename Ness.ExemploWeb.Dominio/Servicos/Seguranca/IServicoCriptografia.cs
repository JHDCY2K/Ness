namespace Ness.ExemploWeb.Dominio.Servicos
{
    public interface IServicoCriptografia
    {
        string Gerar(string senha);
        bool Verificar(string hashSenha, string senha);
    }
}
