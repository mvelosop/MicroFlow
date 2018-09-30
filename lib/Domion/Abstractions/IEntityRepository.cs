using System.Threading.Tasks;

namespace Domion.Abstractions
{
	public interface IEntityRepository<TEntity, in TKey> where TEntity : class
	{
		void Delete(TEntity entity);

		Task<TEntity> FindByIdAsync(TKey id);

		void Insert(TEntity entity);

		Task<int> SaveChangesAsync();

		void Update(TEntity entity);
	}
}