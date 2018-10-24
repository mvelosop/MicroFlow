using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroFlow.Domain.Model
{
	public class BudgetItemType
	{
		//[Column(TypeName = "nvarchar(10)")]
		public BudgetClass BudgetClass { get; set; }

		public byte[] RowVersion { get; set; }

		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Notes { get; set; }

		public int Order { get; set; }
	}
}