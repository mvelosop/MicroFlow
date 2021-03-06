﻿using MicroFlow.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroFlow.Infrastructure.Data.Configuration
{
	public class BudgetItemTypeConfiguration : IEntityTypeConfiguration<BudgetItemType>
	{
		public void Configure(EntityTypeBuilder<BudgetItemType> builder)
		{
			builder.ToTable("BudgetItemTypes", schema: "Budget");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.RowVersion)
				.IsRowVersion();

			builder.Property(t => t.Name)
				.HasMaxLength(250)
				.IsRequired();

			builder.Property(t => t.Notes)
				.HasMaxLength(1000);

			builder.Property(t => t.BudgetClass)
				.HasConversion<string>(new EnumToStringConverter<BudgetClass>())
				.HasMaxLength(10);
		}
	}
}