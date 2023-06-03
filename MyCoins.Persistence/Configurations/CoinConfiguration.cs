﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoins.Domain;

namespace MyCoins.Persistence.Configurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(coin => coin.Id);
            builder.HasIndex(coin => coin.Id).IsUnique();
            builder.Property(coin => coin.Description).HasMaxLength(256);
        }
    }
}
