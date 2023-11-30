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

        public async Task<int> Add(T entity)
        {
           return await _baseRepo.Add(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var retorno =  await _baseRepo.GetAll();

            return retorno;
        }

        public async Task<T> GetById(int id)
        {
            return await _baseRepo.GetById(id);
        }

        public async Task<bool> Update(T entity)
        {
            return await _baseRepo.Update(entity);
        }
    }
}
