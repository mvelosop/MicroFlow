using Domion.Validation;
using System.Runtime.CompilerServices;

namespace MicroFlow.Domain.Validators
{
	public static class BudgetItemTypeErrors
	{
		public static ErrorMessage NameExists(string name) => 
			new ErrorMessage($@"There's another budget item type named ""{name}""! Can't duplicate.");

		public static ErrorMessage NameRequired() => 
			new ErrorMessage("The name is required.");

	}
}