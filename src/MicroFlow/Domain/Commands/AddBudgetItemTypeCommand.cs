using MicroFlow.Data.Commands;
using MicroFlow.Domain.Model;

namespace MicroFlow.Domain.Commands
{
	public class AddBudgetItemTypeCommand : BudgetItemTypeData
	{
		public AddBudgetItemTypeCommand(
			BudgetClass budgetClass,
			string name,
			string notes)
			: base (budgetClass, name, notes)

		{
		}
	}
}