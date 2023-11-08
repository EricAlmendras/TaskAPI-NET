using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.Repository.Interfaces;

namespace TaskAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly ContextDB _contextDB;
        protected readonly DbSet<T> _entities;
        public Repository(ContextDB contextDB)
        {
            _contextDB = contextDB;
            _entities = contextDB.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            var entity = await _entities.ToListAsync();
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> Insert(T entity)
        {
            try
            {
                _entities.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _entities.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                T entity = await GetById(id);
                _entities.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
