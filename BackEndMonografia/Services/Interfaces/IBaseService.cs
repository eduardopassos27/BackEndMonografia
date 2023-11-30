namespace BackEndMonografia.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<bool> Update(T entity);
    }
}
