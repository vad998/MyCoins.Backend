using MyCoins.Domain.Entities;
using MyCoins.Domain.Repositories.AbstractRepositories;

namespace MyCoins.Domain.Repositories.EntityRepositories
{
    public interface ITransationRepository : IBaseRepository<Transaction>
    {
        IQueryable<Transaction> Transactions { get; }
    }
}
