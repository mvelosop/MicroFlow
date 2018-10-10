using Domion.Abstractions;
using MicroFlow.Domain.Model;
using System.Threading.Tasks;

namespace MicroFlow.Domain.Repositories
{
	public interface IBudgetItemTypeRepository : IEntityRepository<BudgetItemType, int>, IEntityQuery<BudgetItemType>
	{
		Task<BudgetItemType> FindByNameAsync(string name);

		Task<BudgetItemType> FindDuplicateByNameAsync(BudgetItemType entity);
	}
}