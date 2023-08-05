
namespace CaseCadastro.Domain.Interfaces
{
    public interface IUnityWork : IDisposable
    {
        ICadastroRepository Cadastro
        {
            get;
        }

        int Salvar();
    }
}
