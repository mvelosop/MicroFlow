using MicroFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Scripts.App
{
	public class BudgetDbContextDesignTimeFactory : IDesignTimeDbContextFactory<BudgetDbContext>
	{
		public BudgetDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<BudgetDbContext>();

			builder.UseSqlServer(".");

			return new BudgetDbContext(builder.Options);
		}
	}
}