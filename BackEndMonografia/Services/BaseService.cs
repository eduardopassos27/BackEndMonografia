using BackEndMonografia.Repositories;
using BackEndMonografia.Services.Interfaces;
using static Dapper.SqlMapper;

namespace BackEndMonografia.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepo;

        public BaseService(IBaseRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<int> Adicionar(T entity)
        {
           return await _baseRepo.Adicionar(entity);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            var retorno =  await _baseRepo.ObterTodos();

            return retorno;
        }

        public async Task<T> ObterPorId(int id)
        {
            return await _baseRepo.ObterPorId(id);
        }

        public async Task<bool> Atualizar(T entity)
        {
            return await _baseRepo.Atualizar(entity);
        }
    }
}
