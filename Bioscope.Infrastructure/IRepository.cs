using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bioscope.Infrastructure
{
  public interface IRepository<TEntity> where TEntity : class
  {
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Delete(Expression<Func<TEntity, bool>> where);
    Task<TEntity> GetById(int id);
    Task<TEntity> GetById(long id);
    Task<TEntity> GetById(string id);
    Task<TEntity> GetById(params object[] keyValues);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> where);
    Task<bool> GetAny();
    Task<bool> GetAny(Expression<Func<TEntity, bool>> where);
    IQueryable<TEntity> AsQueryable();
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where);
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
    string GetTableName();
  }
}