using Domion.Abstractions;
using Domion.Base;
using FluentValidation.Results;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Repositories;
using MicroFlow.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroFlow.Application.Services
{
	public class BudgetItemTypeServices : IBudgetItemTypeServices
	{
		private readonly Lazy<SaveBudgetItemTypeValidator> _lazySaveValidator;
		private readonly IBudgetItemTypeRepository _repository;

		public BudgetItemTypeServices(
			IBudgetItemTypeRepository repository,
			Lazy<SaveBudgetItemTypeValidator> lazySaveValidator)
		{
			_repository = repository;
			_lazySaveValidator = lazySaveValidator;
		}

		public SaveBudgetItemTypeValidator SaveValidator => _lazySaveValidator.Value;

		public async Task<OperationResult<BudgetItemType>> AddAsync(BudgetItemType entity)
		{
			var result = await SaveValidator.ValidateAsync(entity);

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

		public async Task<OperationResult> RemoveAsync(BudgetItemType entity)
		{
			_repository.Delete(entity);

			await _repository.SaveChangesAsync();

			return SuccessfulOperation();
		}

		public async Task<OperationResult<BudgetItemType>> UpdateAsync(BudgetItemType entity)
		{
			var result = await SaveValidator.ValidateAsync(entity);

			if (!result.IsValid) return FailedOperation(result);

			_repository.Update(entity);

			await _repository.SaveChangesAsync();

			return SuccessfulOperation(entity);
		}

		private OperationResult<BudgetItemType> FailedOperation(ValidationResult result)
		{
			return new OperationResult<BudgetItemType>(result);
		}

		private OperationResult SuccessfulOperation()
		{
			return new OperationResult();
		}

		private OperationResult<BudgetItemType> SuccessfulOperation(BudgetItemType entity)
		{
			return new OperationResult<BudgetItemType>(new ValidationResult(), entity);
		}
	}
}