using Domion.Abstractions;
using MicroFlow.Domain.Model;
using System.Threading.Tasks;

namespace MicroFlow.Domain.Services
{
	public interface IBudgetItemRepository : IEntityRepository<BudgetItem, int>, IEntityQuery<BudgetItem>
	{
		Task<BudgetItem> FindByNameAsync(string name);

		Task<BudgetItem> FindByNameAsync(string name, int excludeId);
	}
}