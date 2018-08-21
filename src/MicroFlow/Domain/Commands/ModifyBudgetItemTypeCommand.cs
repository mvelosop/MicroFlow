using MicroFlow.Data.Commands;
using MicroFlow.Domain.Model;
using MicroFlow.lib;
using System;

namespace MicroFlow.Domain.Commands
{
	public class ModifyBudgetItemTypeCommand : BudgetItemTypeData, IChangeCommand<int>
	{
		public ModifyBudgetItemTypeCommand(
			int id,
			byte[] concurrencyToken,
			BudgetClass budgetClass,
			string name,
			string notes)
			: base(budgetClass, name, notes)
		{
			Id = id;
			ConcurrencyToken = concurrencyToken ?? throw new ArgumentNullException(nameof(concurrencyToken));
		}

		public byte[] ConcurrencyToken { get; }

		public int Id { get; }
	}
}