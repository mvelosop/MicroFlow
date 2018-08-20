using System;

namespace MicroFlow.Domain.Model
{
	public class RecurringBudgetItem : BudgetItem
	{
		public DateTime BeginDate { get; set; }

		public DateTime? EndDate { get; set; }

		public int LapseCount { get; set; }

		public LapseUnit LapseUnit { get; set; }

		public int? OccurrenceCount { get; set; }

		public int OnDay { get; set; }

		public bool OnEndOfMonth { get; set; }

		public int OnMonth { get; set; }
	}
}