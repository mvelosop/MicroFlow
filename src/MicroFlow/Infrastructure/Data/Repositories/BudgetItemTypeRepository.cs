using Domion.Infrastructure.Base;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Repositories;
using MicroFlow.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MicroFlow.Infrastructure.Data.Repositories
{
	public class BudgetItemTypeRepository : BaseRepository<BudgetItemType, int>, IBudgetItemTypeRepository
	{
		public BudgetItemTypeRepository(
			BudgetDbContext dbContext)
			: base(dbContext)
		{
		}

		public async Task<BudgetItemType> FindByNameAsync(string name)
		{
			return await DbSet.SingleOrDefaultAsync(e => e.Name == name);
		}
	}
}