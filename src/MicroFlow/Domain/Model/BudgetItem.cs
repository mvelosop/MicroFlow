using System.ComponentModel.DataAnnotations;

namespace MicroFlow.Domain.Model
{
	public class BudgetItem
	{
		public decimal Amount { get; set; }

		public byte[] RowVersion { get; set; }

		public int Id { get; set; }

		[MaxLength(250)]
		[Required]
		public string Name { get; set; }

		[MaxLength(1000)]
		public string Notes { get; set; }

		public int Order { get; set; }

		public BudgetItemType Type { get; set; }

		public int Type_Id { get; set; }
	}
}