using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Infrastructure
{
    public  class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {

        protected readonly LanguageSchoolDbContext _context; //DbContext db;

        private DbSet<TEntity> dbSet
        {
            get { return _context.Set<TEntity>(); }
        }

        public Repository(LanguageSchoolDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(object Id)
        {
            var entity = GetById(Id);
            if (entity == null)
                throw new ArgumentException("no entity");
            dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            IEnumerable<TEntity> entities = dbSet.Where(expression).AsEnumerable();
            foreach (TEntity obj in entities)
                dbSet.Remove(obj);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public TEntity GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("no entity");
            dbSet.Update(entity);
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
