using MicroFlow.Domain.Model;
using System;

namespace MicroFlow.Data.Commands
{
	public class BudgetItemTypeData
	{
		public BudgetClass BudgetClass { get; set; }

		public string Name { get; set; }

		public string Notes { get; set; }
	}
}