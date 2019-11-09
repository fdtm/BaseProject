using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Core.Services.Communications;

namespace WebApplication2.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);

        Task<Response<TEntity>> AddAsync(TEntity entity);

        Task<Response<TEntity>> UpdateAsync(TEntity entity);

        Task<Response<TEntity>> RemoveAsync(int id);
    }
}
