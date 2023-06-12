using MyCoins.Application.Entities.Transactions.Queries.GetTransationDetails;
using MyCoins.Application.Entities.Transactions.Queries.GetTransationList;
using MyCoins.Application.Facades.InterfaceFacades;
using MyCoins.Domain.Entities;

namespace MyCoins.Application.Facades.ConcreteFasades
{
    public class TransationFacade : ITransationFacade
    {
        public Task<Guid> CreateTransation(Transaction transaction, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTransation(Guid transationId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TransationDetailsVm> GetTransationDetails(Guid transationId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TransationListVm> GetTransationList(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTransation(Transaction transation, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
