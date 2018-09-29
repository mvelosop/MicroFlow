using MicroFlow.Domain.Model;
using MicroFlow.lib;
using System;

namespace MicroFlow.Domain.Commands
{
	public class ModifyBudgetItemTypeCommand : IChangeCommand<int>
	{
		public ModifyBudgetItemTypeCommand(
			int id,
			byte[] concurrencyToken,
			BudgetClass budgetClass,
			string name,
			string notes)
		{
			Id = id;
			ConcurrencyToken = concurrencyToken ?? throw new ArgumentNullException(nameof(concurrencyToken));
			BudgetClass = budgetClass;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Notes = notes;
		}

		public BudgetClass BudgetClass { get; }

		public byte[] ConcurrencyToken { get; }

		public int Id { get; }

		public string Name { get; }

		public string Notes { get; }
	}
}