using Domion.Abstractions;
using Domion.Base;
using MicroFlow.Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroFlow.Domain.Services
{
	public interface IBudgetItemTypeServices
	{
		Task<OperationResult<BudgetItemType>> AddAsync(BudgetItemType model);

		Task<BudgetItemType> FindByIdAsync(int id);

		Task<BudgetItemType> FindByNameAsync(string name);

		Task<BudgetItemType> FindByNameAsync(string name, int excludingId);

		Task<List<BudgetItemType>> GetListAsync();

		Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec);

		Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec, CancellationToken cancellationToken);

		Task<OperationResult<BudgetItemType>> ModifyAsync(BudgetItemType model);

		Task<OperationResult> RemoveAsync(BudgetItemType model);
	}
}