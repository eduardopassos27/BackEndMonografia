namespace BackEndMonografia.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> ObterPorId(int id);
        Task<IEnumerable<T>> ObterTodos();
        Task<int> Adicionar(T entity);
        Task<bool> Atualizar(T entity);
    }
}
