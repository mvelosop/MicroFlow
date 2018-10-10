using MicroFlow.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroFlow.Infrastructure.Data.Configuration
{
	public class BudgetDbContext : DbContext
	{
		public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
			: base(options)
		{
		}

		public DbSet<BudgetItem> BudgetItems { get; set; }

		public DbSet<BudgetItemType> BudgetItemTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BudgetItemTypeConfiguration());
			modelBuilder.ApplyConfiguration(new BudgetItemConfiguration());
		}
	}
}