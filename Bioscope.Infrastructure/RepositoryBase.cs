using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bioscope.Infrastructure
{
  public abstract class RepositoryBase<TContext, TEntity> : IRepository<TEntity>
    where TContext : DbContext
  where TEntity : class
  {
    #region Properties & Fields
    private TContext _dataContext;
    private readonly DbSet<TEntity> _dbSet;
    protected IDbFactory<TContext> DbFactory { get; }
    protected TContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());
    #endregion

    #region Implementation
    protected RepositoryBase(IDbFactory<TContext> dbFactory)
    {
      DbFactory = dbFactory;
      _dbSet = DbContext.Set<TEntity>();
    }
    public virtual void Add(TEntity entity) => _dbSet.Attach(entity);
    public virtual void AddRange(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);
    public virtual void Update(TEntity entity)
    {
      _dbSet.Attach(entity);
      _dataContext.Entry(entity).State = EntityState.Modified;
    }
    public virtual void Delete(TEntity entity)
    {
      _dbSet.Attach(entity);
      _dataContext.Entry(entity).State = EntityState.Deleted;
    }
    public virtual async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);
    public virtual async Task<TEntity> GetById(long id) => await _dbSet.FindAsync(id);
    public virtual async Task<TEntity> GetById(string id) => await _dbSet.FindAsync(id);
    public virtual async Task<TEntity> GetById(params object[] keyValues) => await _dbSet.FindAsync(keyValues);
    public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> where) => await _dbSet.Where(where).FirstOrDefaultAsync();
    public virtual async Task<bool> GetAny() => await _dbSet.CountAsync() > 0;
    public virtual async Task<bool> GetAny(Expression<Func<TEntity, bool>> where) => await _dbSet.AnyAsync(where);
    public virtual async Task<IEnumerable<TEntity>> GetAll() => await _dbSet.ToListAsync();
    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where) => await _dbSet.Where(where).ToListAsync();
    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
    {
      //IQueryable<T> query = _dbSet;
      //foreach (var item in includes)
      //{
      //    query = query.Include(item);
      //}
      var query = includes.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_dbSet, (current, item) => current.Include(item));
      return await query.AsNoTracking().Where(where).ToListAsync();
    }
    public virtual void Delete(Expression<Func<TEntity, bool>> where)
    {
      var objects = _dbSet.Where(where).AsEnumerable();
      foreach (var obj in objects)
      {
        _dbSet.Remove(obj);
      }
    }
    public virtual IQueryable<TEntity> AsQueryable() => _dbSet.AsNoTracking().AsQueryable();

    public string GetTableName()
    {
      return typeof(TEntity).Name;
    }

    #endregion
  }
}