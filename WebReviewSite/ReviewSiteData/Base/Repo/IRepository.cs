using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReviewSiteData.Base.Repo {

    public interface IRepository<TEntity> where TEntity : class {

        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);

    }

}