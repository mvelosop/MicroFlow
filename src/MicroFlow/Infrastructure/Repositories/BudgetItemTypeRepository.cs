using Domion.Infrastructure.Base;
using MicroFlow.Domain.Model;
using MicroFlow.Domain.Repositories;
using MicroFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MicroFlow.Infrastructure.Repositories
{
	public class BudgetItemTypeRepository : BaseRepository<BudgetItemType, int>, IBudgetItemTypeRepository
	{
		public BudgetItemTypeRepository(
			BudgetDbContext dbContext)
			: base(dbContext)
		{
		}

		public override void Delete(BudgetItemType entity)
		{
			SetOriginalRowVersion(entity);

			base.Delete(entity);
		}

		public async Task<BudgetItemType> FindByNameAsync(string name)
		{
			return await DbSet.SingleOrDefaultAsync(e => e.Name == name);
		}

		public async Task<BudgetItemType> FindDuplicateByNameAsync(BudgetItemType entity)
		{
			if (entity.Id == 0)
			{
				return await FindByNameAsync(entity.Name);
			}

			return await DbSet.SingleOrDefaultAsync(e => e.Name == entity.Name && e.Id != entity.Id);
		}

		public override void Update(BudgetItemType entity)
		{
			SetOriginalRowVersion(entity);

			base.Update(entity);
		}

		private void SetOriginalRowVersion(BudgetItemType entity)
		{
			GetEntry(entity).OriginalValues[nameof(BudgetItemType.RowVersion)] = entity.RowVersion;
		}
	}
}