using System.ComponentModel.DataAnnotations;

namespace MicroFlow.Domain.Model
{
	public class BudgetItemType
	{
		public BudgetClass BudgetClass { get; set; }

		public byte[] ConcurrencyToken { get; set; }

		public int Id { get; set; }

		[MaxLength(250)]
		[Required]
		public string Name { get; set; }

		[MaxLength(1000)]
		public string Notes { get; set; }

		public int Order { get; set; }
	}
}