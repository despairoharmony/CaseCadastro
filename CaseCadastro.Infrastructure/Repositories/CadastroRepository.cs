using CaseCadastro.API.Repositories;
using CaseCadastro.Domain.Interfaces;
using CaseCadastro.Domain.Models;

namespace CaseCadastro.Infrastructure.Repositories
{
    public class CadastroRepository : GenericRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(CadastroContext context)
            : base(context) { }
    }
}
