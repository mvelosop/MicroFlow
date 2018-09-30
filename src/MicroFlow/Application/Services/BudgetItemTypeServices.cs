using Domion.Abstractions;
using Domion.Base;
using FluentValidation.Results;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Services;
using MicroFlow.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroFlow.Application.Services
{
	public class BudgetItemTypeServices : IBudgetItemTypeServices
	{
		private readonly BudgetDbContext _dbContext;

		public BudgetItemTypeServices(
			BudgetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<OperationResult<BudgetItemType>> AddAsync(BudgetItemType entity)
		{
			_dbContext.Add(entity);

			await _dbContext.SaveChangesAsync();

			return new OperationResult<BudgetItemType>(new ValidationResult(), entity);
		}

		public Task<BudgetItemType> FindByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<BudgetItemType> FindByNameAsync(string name)
		{
			return await _dbContext.BudgetItemTypes.SingleOrDefaultAsync(bi => bi.Name == name);
		}

		public Task<BudgetItemType> FindByNameAsync(string name, int excludingId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<BudgetItemType>> GetListAsync()
		{
			return await _dbContext.BudgetItemTypes.ToListAsync();
		}

		public Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec)
		{
			throw new NotImplementedException();
		}

		public Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public async Task<OperationResult<BudgetItemType>> ModifyAsync(BudgetItemType entity)
		{
			_dbContext.Update(entity);

			await _dbContext.SaveChangesAsync();

			return new OperationResult<BudgetItemType>(new ValidationResult(), entity);
		}

		public async Task<OperationResult> RemoveAsync(BudgetItemType entity)
		{
			_dbContext.Remove(entity);

			await _dbContext.SaveChangesAsync();

			return new OperationResult(new ValidationResult());
		}
	}
}