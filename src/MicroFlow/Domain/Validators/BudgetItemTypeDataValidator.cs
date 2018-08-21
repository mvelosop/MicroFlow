using FluentValidation;
using MicroFlow.Data.Commands;

namespace MicroFlow.Domain.Validators
{
	public class BudgetItemTypeDataValidator : AbstractValidator<BudgetItemTypeData>
	{
		public BudgetItemTypeDataValidator()
		{
			RuleFor(d => d.Name).NotEmpty();
		}
	}
}