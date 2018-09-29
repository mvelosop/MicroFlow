using Domion.Abstractions;
using MicroFlow.Domain.Model;
using System.Threading.Tasks;

namespace MicroFlow.Domain.Repositories
{
	public interface IBudgetItemTypeRepository : IEntityRepository<BudgetItemType, int>, IEntityQuery<BudgetItemType>
	{
		void Delete(BudgetItemType entity);

		Task<BudgetItemType> FindByNameAsync(string name);

		Task<BudgetItemType> FindByNameAsync(string name, int excludeId);

		void Insert(BudgetItemType entity);

		Task<int> SaveChangesAsync();

		void Update(BudgetItemType entity);
	}
}