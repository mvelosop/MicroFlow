using MicroFlow.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFlow.Infrastructure.Data.Configuration
{
	public class BudgetItemConfiguration : IEntityTypeConfiguration<BudgetItem>
	{
		public void Configure(EntityTypeBuilder<BudgetItem> builder)
		{
			builder.ToTable("BudgetItems", schema: "Budget");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.RowVersion)
				.IsRowVersion();

			builder.HasOne(t => t.Type)
				.WithMany()
				.HasForeignKey(t => t.Type_Id)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasDiscriminator<string>("Discriminator");

			builder.Property<string>("Discriminator")
				.HasMaxLength(128);
		}
	}
}
