namespace MicroFlow.Domain.Model
{
	public class BudgetItemType
	{
		public BudgetClass BudgetClass { get; set; }

		public byte[] ConcurrencyToken { get; set; }

		public int Id { get; set; }

		public string Name { get; set; }

		public string Notes { get; set; }

		public int Order { get; set; }
	}
}