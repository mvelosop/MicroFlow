using Domion.Validation;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Errors = MicroFlow.Domain.Validators.BudgetItemTypeErrors;

namespace MicroFlow.Domain.Validators
{
	public class AddBudgetItemTypeValidator : AbstractValidator<BudgetItemType>
	{
		private readonly IBudgetItemTypeRepository _repository;

		public AddBudgetItemTypeValidator(IBudgetItemTypeRepository repository)
		{
			RuleFor(e => e.Name).NotEmpty().WithErrorMessage(Errors.NameRequired());
			RuleFor(e => e.Name).CustomAsync(BeUnique);

			_repository = repository;
		}

		protected async Task<bool> BeUnique(
			string name,
			CustomContext context,
			CancellationToken cancellationToken)
		{
			var duplicateByName = await _repository.FindByNameAsync(name);

			if (duplicateByName is null) return true;

			var error = Errors.NameExists(name);

			var failure = new ValidationFailure(nameof(BudgetItemType.Name), error.Message);

			failure.ErrorCode = error.Code;

			context.AddFailure(failure);

			return false;
		}
	}
}