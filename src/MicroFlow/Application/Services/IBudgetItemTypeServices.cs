using Domion.Abstractions;
using Domion.Base;
using MicroFlow.Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroFlow.Application.Services
{
	public interface IBudgetItemTypeServices
	{
		Task<OperationResult<BudgetItemType>> AddAsync(BudgetItemType entity);

		Task<BudgetItemType> FindByIdAsync(int id);

		Task<BudgetItemType> FindByNameAsync(string name);

		Task<List<BudgetItemType>> GetListAsync();

		Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec);

		Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec, CancellationToken cancellationToken);

		Task<OperationResult<BudgetItemType>> UpdateAsync(BudgetItemType entity);

		Task<OperationResult> RemoveAsync(BudgetItemType entity);
	}
}