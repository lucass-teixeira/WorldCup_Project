using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WorldCupContext _context;
        public Repository(WorldCupContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;//Diz ao contexto que a entidade foi alterada
            _context.Set<T>().Update(entity);
        }
    }
}
