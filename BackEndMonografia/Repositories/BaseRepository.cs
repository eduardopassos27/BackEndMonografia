using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BackEndMonografia.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbConector _dbConector;

        public BaseRepository(IDbConector dbConector)
        {
            _dbConector = dbConector;
        }
        public async Task<int> Add(TEntity entity)
        {
            return await _dbConector.Connection.InsertAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbConector.Connection.GetAllAsync<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbConector.Connection.GetAsync<TEntity>(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            return await _dbConector.Connection.UpdateAsync(entity);
        }
    }
}
