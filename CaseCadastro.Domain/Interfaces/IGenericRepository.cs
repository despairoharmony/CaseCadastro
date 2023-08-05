namespace CaseCadastro.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int id);
    }
}
