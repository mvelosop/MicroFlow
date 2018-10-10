using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domion.Abstractions
{
	public interface IEntityRepository<TEntity, in TKey> where TEntity : class
	{
		void Delete(TEntity entity);

		void DeleteRange(params TEntity[] entities);

		Task<TEntity> FindByIdAsync(TKey id);

		void Insert(TEntity entity);

		Task InsertAsync(TEntity entity);

		void InsertRange(params TEntity[] entities);

		Task<int> SaveChangesAsync();

		void Update(TEntity entity);

		void UpdateRange(params TEntity[] entities);
	}
}