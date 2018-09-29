using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domion.Abstractions

{
	public interface IEntityQuery<TEntity> where TEntity : class
	{
		Task<List<TEntity>> GetListAsync(IQuerySpec<TEntity> querySpec);

		Task<List<TEntity>> GetListAsync(IQuerySpec<TEntity> querySpec, CancellationToken cancellationToken);
	}
}