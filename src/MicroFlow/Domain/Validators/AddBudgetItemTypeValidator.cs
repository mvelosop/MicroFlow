using FluentValidation;
using MicroFlow.Domain.Model;

namespace MicroFlow.Domain.Validators
{
	public class AddBudgetItemTypeValidator : AbstractValidator<BudgetItemType>
	{
		public AddBudgetItemTypeValidator()
		{
			RuleFor(d => d.Name).NotEmpty();
		}
	}
}