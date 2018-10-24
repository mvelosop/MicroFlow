using MicroFlow.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFlow.Specs.TestHelpers
{
	public static class UpdateExtensions
	{
		public static BudgetItemType CopyValuesFrom(this BudgetItemType target, BudgetItemType source)
		{
			target.Name = source.Name;
			target.Order = source.Order;
			target.BudgetClass = source.BudgetClass;
			target.Notes = source.Notes;

			return target;
		}
	}
}
