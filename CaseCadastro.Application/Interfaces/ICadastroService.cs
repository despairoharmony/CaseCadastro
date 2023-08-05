using CaseCadastro.Domain.Models;

namespace CaseCadastro.Application.Interfaces
{
    public interface ICadastroService
    {
        Task<IEnumerable<Cadastro>> GetAll();
        Task<Cadastro> GetById(int id);
        Task<bool> InserirCadastro(Cadastro cliente);
        Task<bool> UpdateCadastro(Cadastro cliente);
        Task<bool> DeleteCadastro(int cadastroId);
    }
}
