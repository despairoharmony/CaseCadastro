using CaseCadastro.Domain.Interfaces;
using CaseCadastro.Domain.Models;

namespace CaseCadastro.Infrastructure.Repositories
{
    public class UnityWork : IUnityWork
    {
        private readonly CadastroContext _context;

        public UnityWork(CadastroContext context)
        {
            this._context = context;
            Cadastro = new CadastroRepository(this._context);
        }

        public ICadastroRepository Cadastro 
        { 
            get; private set;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Salvar()
        {
            return _context.SaveChanges();
        }
    }
}
