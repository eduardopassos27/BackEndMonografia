using BackEndMonografia.Configuration.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BackEndMonografia.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorId(int id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<int> Adicionar(TEntity entity);
        Task<bool> Atualizar(TEntity entity);
    }

    public interface IDbConector
    {
        IDbConnection Connection { get; }
    }

    public sealed class DbConector : IDbConector
    {
        private bool disposed;
        public IDbConnection Connection { get; }
        public IAppSettings appSettings { get; set; }


        public DbConector(IAppSettings appsettings)
        {
            this.appSettings = appsettings;
            try
            {
                var myString = appsettings.ConnectionString;
                Connection = new SqlConnection(myString);
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (this.Connection?.State == ConnectionState.Open)
                    Connection?.Dispose();
            }
            disposed = true;
        }

    }
}
