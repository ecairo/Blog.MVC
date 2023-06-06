using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : EntityBase
    {
        private readonly IDbSet<T> dbSet;
        private BlogEntities dataContext;

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected BlogEntities DbContext
        {
            get
            {
                return this.dataContext ?? (this.dataContext = DbFactory.Init());
            }
        }

        #region Implementation

        public virtual void Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion
    }
}
