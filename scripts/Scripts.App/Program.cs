using MicroFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Scripts.App
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Host for EF scripts");

			string connectionString =
				"Server=(localdb)\\MSSQLLocalDB; Database=MicroFlow.Scripts.App; Trusted_Connection=true; MultipleActiveResultSets=true;";

			var optionsBuilder = new DbContextOptionsBuilder<BudgetDbContext>();

			optionsBuilder.UseSqlServer(connectionString);

			Console.WriteLine($"Connection String: {connectionString}");
			Console.WriteLine("Creating database / applying migrations...");

			using (var dbContext = new BudgetDbContext(optionsBuilder.Options))
			{
				dbContext.Database.Migrate();
			}

			Console.WriteLine("Done!");
		}
	}
}