using FluentValidation;
using MicroFlow.lib;

namespace MicroFlow.Lib.Validators
{
	public class ChangeCommandValidator<TKey> : AbstractValidator<IChangeCommand<TKey>>
	{
		public ChangeCommandValidator()
		{
			RuleFor(c => c.ConcurrencyToken).NotEmpty();
			RuleFor(c => c.Id).NotEmpty();
		}
	}
}