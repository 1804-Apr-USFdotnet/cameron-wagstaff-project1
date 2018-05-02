using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ReviewSiteData.Base.Repo;

namespace ReviewSiteData.Persistence.Repo {

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected readonly DbContext Context;

        private DbSet<TEntity> _entities => Context.Set<TEntity>();

        public Repository(DbContext context) {
            Context = context;
        }

        public TEntity Get(int id) {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> Get() {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) {
            return _entities.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity) {
            _entities.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities) {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity) {
            _entities.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities) {
            _entities.RemoveRange(entities);
        }
    }

}