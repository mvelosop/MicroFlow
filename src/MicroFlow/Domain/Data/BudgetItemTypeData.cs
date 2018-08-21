using MicroFlow.Domain.Model;
using System;

namespace MicroFlow.Data.Commands
{
	public class BudgetItemTypeData
	{
		public BudgetItemTypeData(
			BudgetClass budgetClass,
			string name,
			string notes)
		{
			BudgetClass = budgetClass;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Notes = notes;
		}

		public BudgetClass BudgetClass { get; }

		public string Name { get; }

		public string Notes { get; }
	}
}