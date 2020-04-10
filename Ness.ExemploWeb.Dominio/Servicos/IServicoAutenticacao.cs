namespace Ness.ExemploWeb.Dominio
{
    public interface IServicoAutenticacao
    {
        bool Autenticar(string login, string senha);
    }
}
