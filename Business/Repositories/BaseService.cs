using Business.Exceptions;
using Business.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
     private readonly IBaseRepository<T> _repository;   
        private readonly IUnitOfWork    _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
           await _repository.AddAsync(entity);
           await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
        /// <summary>
        /// Data for id not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<T> GetByIdAsync(int id)
        {
           var hasProduct= await _repository.GetByIdAsync(id);
            if (hasProduct==null)
            {
                throw new NotFoundException($"{typeof(T).Name} not found");
            }
            return hasProduct;
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();   
        }

        public void Update(T entity)
        {
            _repository.Update(entity); 
            _unitOfWork.Commit();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }

}
