using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Core;
using WebApplication2.Core.Repositories;
using WebApplication2.Core.Services;
using WebApplication2.Core.Services.Communications;

namespace WebApplication2.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return new Response<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new Response<TEntity>($"خطا :  {ex.Message}");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Response<TEntity>> RemoveAsync(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);
                if (entity == null)
                    return new Response<TEntity>("یافت نشد!");

                _repository.Remove(entity);
                await _unitOfWork.CompleteAsync();
                return new Response<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new Response<TEntity>($"خطا :  {ex.Message}");
            }
        }

        public async Task<Response<TEntity>> UpdateAsync(int id, TEntity entity)
        {
            try
            {
                _repository.Update(entity);
                await _unitOfWork.CompleteAsync();

                return new Response<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new Response<TEntity>($"خطا :  {ex.Message}");
            }
        }
    }
}
