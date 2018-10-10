using Domion.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domion.Infrastructure.Base
{
	public abstract class BaseRepository<TEntity, TKey> : IEntityRepository<TEntity, TKey>, IEntityQuery<TEntity> where TEntity : class
	{
		private readonly DbContext _dbContext;

		public BaseRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

		public virtual void Delete(TEntity entity)
		{
			_dbContext.Remove(entity);
		}

		public virtual void DeleteRange(params TEntity[] entities)
		{
			_dbContext.RemoveRange(entities);
		}

		public virtual Task<TEntity> FindByIdAsync(TKey id)
		{
			return _dbContext.FindAsync<TEntity>(id);
		}

		public virtual Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
		}

		public virtual Task<List<TEntity>> GetListAsync(IQuerySpec<TEntity> querySpec, CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}

		public virtual void Insert(TEntity entity)
		{
			_dbContext.Add(entity);
		}

		public virtual async Task InsertAsync(TEntity entity)
		{
			await _dbContext.AddAsync(entity);
		}

		public virtual void InsertRange(params TEntity[] entities)
		{
			_dbContext.AddRange(entities);
		}

		public virtual Task<int> SaveChangesAsync()
		{
			return _dbContext.SaveChangesAsync();
		}

		public virtual void Update(TEntity entity)
		{
			_dbContext.Update(entity);
		}

		public virtual void UpdateRange(params TEntity[] entities)
		{
			_dbContext.UpdateRange(entities);
		}
	}
}