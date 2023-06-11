using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoins.Domain;

namespace MyCoins.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);
            builder.HasIndex(transaction => transaction.Id).IsUnique();
            builder.Property(transaction => transaction.Description).HasMaxLength(256);
        }
    }
}
