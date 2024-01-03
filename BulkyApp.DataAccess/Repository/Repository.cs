using BulkyApp.DataAccess.Data;
using BulkyApp.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyApp.DataAccess.Repository
{
    public class Repository<T> : RepositoryInterface<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext _db) 
        {
            _dbContext = _db;
            this.dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() 
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public T Get (Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            return query.Where(filter).FirstOrDefault();
        }

        public void Create(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
