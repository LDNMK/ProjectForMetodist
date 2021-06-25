using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Fait.DAL.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity: class
    {
        protected readonly FAITContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(FAITContext context)
        {
            dbContext = context;
            dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            dbSet.Add(item);
        }

        public void AddRange(ICollection<TEntity> items)
        {
            dbSet.AddRange(items);
        }

        public void Update(TEntity item)
        {
            dbSet.Update(item);
        }

        public virtual TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public ICollection<TEntity> Find(
            Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, TEntity>> orderby = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = query.OrderBy(orderby);
            }

            return query.ToList();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }
}
