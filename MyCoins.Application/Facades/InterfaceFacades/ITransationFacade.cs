using MyCoins.Application.Entities.Transactions.Queries.GetTransationDetails;
using MyCoins.Application.Entities.Transactions.Queries.GetTransationList;
using MyCoins.Domain.Entities;

namespace MyCoins.Application.Facades.InterfaceFacades
{
    public interface ITransationFacade
    {
        Task<TransationDetailsVm> GetTransationDetails(Guid transationId, CancellationToken cancellationToken = default);
        Task<TransationListVm> GetTransationList(CancellationToken cancellationToken = default);
        Task<Guid> CreateTransation(Transaction transaction, CancellationToken cancellationToken = default);
        Task DeleteTransation(Guid transationId, CancellationToken cancellationToken = default);
        Task UpdateTransation(Transaction transation, CancellationToken cancellationToken = default);
    }
}
