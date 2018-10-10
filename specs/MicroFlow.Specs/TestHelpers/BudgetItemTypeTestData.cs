using MicroFlow.Domain.Model;

namespace MicroFlow.Specs.TestHelpers
{
	public class BudgetItemTypeTestData : BudgetItemType
	{
		public string FindByName { get; set; }

		public string ValidationErrors { get; set; }
	}
}