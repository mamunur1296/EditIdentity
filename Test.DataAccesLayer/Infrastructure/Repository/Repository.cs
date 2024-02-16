using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccesLayer.Infrastructure.IRepository;

namespace Test.DataAccesLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _country;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext country)
        {
            _country = country;
            _dbSet = _country.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet?.Remove(entity);
        }

        public void RemoveAll(IEnumerable<T> values)
        {
            _dbSet.RemoveRange(values);
        }
    }
}
