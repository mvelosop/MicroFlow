using MicroFlow.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroFlow.Infrastructure.Data.Configuration
{
	public class BudgetItemTypeConfiguration : IEntityTypeConfiguration<BudgetItemType>
	{
		public void Configure(EntityTypeBuilder<BudgetItemType> builder)
		{
			builder.ToTable("BudgetItemTypes", schema: "Budget");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.ConcurrencyToken)
				.IsRowVersion();
		}
	}
}