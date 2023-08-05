using CaseCadastro.Domain.Interfaces;
using CaseCadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseCadastro.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CadastroContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(CadastroContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            IQueryable<T> result = dbSet;
            var keyName = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return await result.Where(p => EF.Property<T>(p, keyName).Equals(id)).FirstAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Insert(T obj)
        {
            await dbSet.AddAsync(obj);
        }

        public virtual async Task Update(T obj)
        {
            dbSet.Update(obj);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            dbSet.Remove(entity);
        }
    }
}
