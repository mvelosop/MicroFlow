using System.Threading.Tasks;

namespace Domion.Abstractions
{
    public interface IEntityRepository<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(TKey id);
    }
}