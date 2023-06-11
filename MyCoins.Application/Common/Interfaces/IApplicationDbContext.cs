using Microsoft.EntityFrameworkCore;
using MyCoins.Domain;

namespace MyCoins.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
