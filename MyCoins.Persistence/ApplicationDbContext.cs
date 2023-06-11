using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyCoins.Application.Common.Interfaces;
using MyCoins.Domain;
using System;
using System.Reflection;

namespace MyCoins.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
