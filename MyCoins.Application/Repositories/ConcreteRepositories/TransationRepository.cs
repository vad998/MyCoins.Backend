using MyCoins.Application.Common.Exceptions;
using MyCoins.Application.Common.Interfaces;
using MyCoins.Application.Repositories.Extensions;
using MyCoins.Domain.Entities;
using MyCoins.Domain.Repositories.EntityRepositories;
using System.Linq.Expressions;

namespace MyCoins.Application.Repositories.ConcreteRepositories
{
    public class TransationRepository : ITransationRepository
    {
        private readonly IApplicationDbContext _context;

        public TransationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Transaction> Transactions => _context.Transactions;

        public Transaction Add(Transaction entity)
            => _context.AddEntity(_context.Transactions, entity);

        public Task<Transaction> AddAsync(Transaction entity, CancellationToken cancellationToken = default)
            => _context.AddEntityAsync(_context.Transactions, entity, cancellationToken);

        public IEnumerable<Transaction> AddRange(IEnumerable<Transaction> entities)
            => _context.AddEntityRange(_context.Transactions, entities);

        public Task<IEnumerable<Transaction>> AddRangeAsync(IEnumerable<Transaction> entities, CancellationToken cancellationToken = default)
            => _context.AddEntityRangeAsync(_context.Transactions, entities, cancellationToken);

        public Transaction Delete(Transaction entity)
            => _context.DeleteEntity(_context.Transactions, entity);

        public Task<Transaction> DeleteAsync(Transaction entity, CancellationToken cancellationToken = default)
            => _context.DeleteEntityAsync(_context.Transactions, entity, cancellationToken);

        public IEnumerable<Transaction> DeleteRange(IEnumerable<Transaction> entities)
            => _context.DeleteEntityRange(_context.Transactions, entities);

        public Task<IEnumerable<Transaction>> DeleteRangeAsync(IEnumerable<Transaction> entities, CancellationToken cancellationToken = default)
            => _context.DeleteEntityRangeAsync(_context.Transactions, entities, cancellationToken);

        public IQueryable<Transaction> Filter(Expression<Func<Transaction, bool>> expression)
            => _context.FilterEntities(_context.Transactions, expression);

        public Task<IQueryable<Transaction>> FilterAsync(Expression<Func<Transaction, bool>> expression, CancellationToken cancellationToken = default)
            => _context.FilterEntitiesAsync(_context.Transactions, expression, cancellationToken);

        public Transaction Get(Expression<Func<Transaction, bool>> expression)
            => _context.GetEntity(_context.Transactions, expression);

        public Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression, CancellationToken cancellationToken = default)
            => _context.GetEntityAsync(_context.Transactions, expression, cancellationToken);

        public Transaction Update(Transaction entity)
            => _context.UpdateEntity(entity, PrepareInvoiceUpdate);

        public Task<Transaction> UpdateAsync(Transaction entity, CancellationToken cancellationToken = default)
            => _context.UpdateEntityAsync(entity, PrepareInvoiceUpdate, cancellationToken);

        private Transaction PrepareInvoiceUpdate(Transaction entity)
        {
            Transaction transationToUpdate = Get(c => c.Id == entity.Id) ?? throw new NotFoundException(nameof(Transaction), entity.Id);
            transationToUpdate.Amount = entity.Amount;
            transationToUpdate.Description = entity.Description;
            transationToUpdate.FromId = entity.FromId;
            transationToUpdate.ToId = entity.ToId;
            return transationToUpdate;
        }

        public IEnumerable<Transaction> UpdateRange(IEnumerable<Transaction> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> UpdateRangeAsync(IEnumerable<Transaction> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
