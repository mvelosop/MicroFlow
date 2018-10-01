using Domion.Abstractions;
using Domion.Base;
using FluentValidation.Results;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Repositories;
using MicroFlow.Domain.Services;
using MicroFlow.Domain.Validators;
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
		private readonly IBudgetItemTypeRepository _repository;
		private readonly AddBudgetItemTypeValidator _validator;

		public BudgetItemTypeServices(
			IBudgetItemTypeRepository dbContext,
			AddBudgetItemTypeValidator validator)
		{
			_repository = dbContext;
			_validator = validator;
		}

		public async Task<OperationResult<BudgetItemType>> AddAsync(BudgetItemType entity)
		{
			var result = await _validator.ValidateAsync(entity);

			if (!result.IsValid) return FailedOperation(result);

			_repository.Insert(entity);

			await _repository.SaveChangesAsync();

			return SuccessfulOperation(entity);
		}

		public Task<BudgetItemType> FindByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<BudgetItemType> FindByNameAsync(string name)
		{
			return await _repository.FindByNameAsync(name);
		}

		public Task<BudgetItemType> FindByNameAsync(string name, int excludingId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<BudgetItemType>> GetListAsync()
		{
			return await _repository.GetListAsync();
		}

		public Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec)
		{
			throw new NotImplementedException();
		}

		public Task<List<BudgetItemType>> GetListAsync(IQuerySpec<BudgetItemType> querySpec, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public async Task<OperationResult<BudgetItemType>> UpdateAsync(BudgetItemType entity)
		{
			_repository.Update(entity);

			await _repository.SaveChangesAsync();

			return SuccessfulOperation(entity);
		}

		public async Task<OperationResult> RemoveAsync(BudgetItemType entity)
		{
			_repository.Delete(entity);

			await _repository.SaveChangesAsync();

			return SuccessfulOperation();
		}

		private OperationResult SuccessfulOperation()
		{
			return new OperationResult();
		}

		private OperationResult<BudgetItemType> FailedOperation(ValidationResult result)
		{
			return new OperationResult<BudgetItemType>(result);
		}

		private OperationResult<BudgetItemType> SuccessfulOperation(BudgetItemType entity)
		{
			return new OperationResult<BudgetItemType>(new ValidationResult(), entity);
		}
	}
}