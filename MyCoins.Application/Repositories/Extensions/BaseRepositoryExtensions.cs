using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using MyCoins.Application.Common.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace MyCoins.Application.Repositories.Extensions
{
    public static class BaseRepositoryExtensions
    {
        public static T AddEntity<T>(this IApplicationDbContext context, DbSet<T> set, T entity) where T : class
        {
            EntityEntry<T> addedEntityEntry = set.Add(entity);
            context.SaveChanges();
            return addedEntityEntry.Entity;
        }

        public static async Task<T> AddEntityAsync<T>(this IApplicationDbContext context, DbSet<T> set, T entity, CancellationToken cancellationToken = default) where T : class
        {
            EntityEntry<T> addedEntityEntry = await set.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return addedEntityEntry.Entity;
        }

        public static IEnumerable<T> AddEntityRange<T>(this IApplicationDbContext context, DbSet<T> set, IEnumerable<T> entities) where T : class
        {
            List<T> addedEntities = new();
            using (TransactionScope additionScope = new())
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (T entity in entities)
                {
                    EntityEntry<T> addedEntityEntry = set.Add(entity);
                    addedEntities.Add(addedEntityEntry.Entity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                additionScope.Complete();
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
            context.ChangeTracker.Clear();
            return addedEntities;
        }

        public static async Task<IEnumerable<T>> AddEntityRangeAsync<T>(this IApplicationDbContext context, DbSet<T> set,
            IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            List<T> addedEntities = new();
            await Task.Run(() =>
            {
                using TransactionScope additionScope = new();
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (T entity in entities)
                {
                    EntityEntry<T> addedEntityEntry = set.Add(entity);
                    addedEntities.Add(addedEntityEntry.Entity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                additionScope.Complete();
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }, cancellationToken);
            return addedEntities;
        }

        public static T DeleteEntity<T>(this IApplicationDbContext context, DbSet<T> set, T entity) where T : class
        {
            EntityEntry<T> removedEntityEntry = set.Remove(entity);
            context.SaveChanges();
            return removedEntityEntry.Entity;
        }

        public async static Task<T> DeleteEntityAsync<T>(this IApplicationDbContext context, DbSet<T> set, T entity, CancellationToken cancellationToken = default) where T : class
        {
            EntityEntry<T> removedEntityEntry = set.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return removedEntityEntry.Entity;
        }

        public static IEnumerable<T> DeleteEntityRange<T>(this IApplicationDbContext context, DbSet<T> set, IEnumerable<T> entities) where T : class
        {
            context.ChangeTracker.Clear();
            List<T> removedEnitites = new();
            using (TransactionScope removalScope = new())
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (T entity in entities)
                {
                    EntityEntry<T> removedEntityEntry = set.Remove(entity);
                    removedEnitites.Add(removedEntityEntry.Entity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                removalScope.Complete();
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
            return removedEnitites;
        }

        public async static Task<IEnumerable<T>> DeleteEntityRangeAsync<T>(this IApplicationDbContext context, DbSet<T> set,
            IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            context.ChangeTracker.Clear();
            List<T> removedEnitites = new();
            await Task.Run(() =>
            {
                using TransactionScope removalScope = new();
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (T entity in entities)
                {
                    EntityEntry<T> removedEntityEntry = set.Remove(entity);
                    removedEnitites.Add(removedEntityEntry.Entity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                removalScope.Complete();
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }, cancellationToken);
            return removedEnitites;
        }

        public static IQueryable<T> FilterEntities<T>(this IApplicationDbContext context, DbSet<T> set, Expression<Func<T, bool>> expression) where T : class
            => set.Where(expression);

        public static async Task<IQueryable<T>> FilterEntitiesAsync<T>(this IApplicationDbContext context, DbSet<T> set,
            Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class
            => await Task.Run(() => set.Where(expression), cancellationToken);

        public static T GetEntity<T>(this IApplicationDbContext context, DbSet<T> set, Expression<Func<T, bool>> expression) where T : class 
            => set.FirstOrDefault(expression);
        public static async Task<T> GetEntityAsync<T>(this IApplicationDbContext context, DbSet<T> set,
            Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class
            => await set.FirstOrDefaultAsync(expression, cancellationToken);

        public static T UpdateEntity<T>(this IApplicationDbContext context, T entity, Func<T, T> PrepareEntityUpdateFunction) where T : class
        {
            T updatedEntity = PrepareEntityUpdateFunction(entity);
            context.SaveChanges();
            context.ChangeTracker.Clear();
            return updatedEntity;
        }

        public static async Task<T> UpdateEntityAsync<T>(this IApplicationDbContext context, T entity,
            Func<T, T> PrepareEntityUpdateFunction, CancellationToken cancellationToken = default) where T : class
        {
            T updatedEntity = PrepareEntityUpdateFunction(entity);
            await context.SaveChangesAsync(cancellationToken);
            context.ChangeTracker.Clear();
            return updatedEntity;
        }

        public static IEnumerable<T> UpdateEntityRange<T>(this IApplicationDbContext context, IEnumerable<T> entities,
            Func<T, T> PrepareEntityUpdateFunction) where T : class
        {
            List<T> updatedEntities = new();
            using (TransactionScope updateScope = new())
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (T entity in entities)
                {
                    T updatedEntity = PrepareEntityUpdateFunction(entity);
                    updatedEntities.Add(updatedEntity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                updateScope.Complete();
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
            return updatedEntities;
        }

        public static async Task<IEnumerable<T>> UpdateEntityRangeAsync<T>(this IApplicationDbContext context, IEnumerable<T> entities,
            Func<T, T> PrepareEntityUpdateFunction, CancellationToken cancellationToken = default) where T : class
        {
            List<T> updatedEntities = new();
            await Task.Run(() =>
            {
                using TransactionScope updateScope = new();
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (T entity in entities)
                {
                    T updatedEntity = PrepareEntityUpdateFunction(entity);
                    updatedEntities.Add(updatedEntity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                updateScope.Complete();
                context.ChangeTracker.AutoDetectChangesEnabled = true;
            }, cancellationToken);
            return updatedEntities;
        }
    }
}
