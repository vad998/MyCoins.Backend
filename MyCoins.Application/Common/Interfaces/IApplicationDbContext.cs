using Microsoft.EntityFrameworkCore;
using MyCoins.Domain;

namespace MyCoins.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Coin> Coins { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
