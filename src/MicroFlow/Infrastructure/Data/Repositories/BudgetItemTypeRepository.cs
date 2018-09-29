using Domion.Abstractions;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroFlow.Infrastructure.Data.Repositories
{
	public class BudgetItemTypeRepository : IBudgetItemTypeRepository
	{
		public void Delete(BudgetItemType entity)
		{
			throw new NotImplementedException();
		}

		public Task<BudgetItemType> FindByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<BudgetItemType> FindByNameAsync(string name)
		{
			throw new NotImplementedException();
		}

		public Task<BudgetItemType> FindByNameAsync(string name, int excludeId)
		{
			throw new NotImplementedException();
		}

		public Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec)
		{
			throw new NotImplementedException();
		}

		public Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public void Insert(BudgetItemType entity)
		{
			throw new NotImplementedException();
		}

		public Task<int> SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public void Update(BudgetItemType entity)
		{
			throw new NotImplementedException();
		}
	}
}
