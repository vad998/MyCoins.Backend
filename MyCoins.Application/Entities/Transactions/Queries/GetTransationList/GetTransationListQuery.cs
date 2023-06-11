using MediatR;

namespace MyCoins.Application.Entities.Transactions.Queries.GetTransationList
{
    public class GetTransationListQuery : IRequest<TransationListVm>
    {
        public class GetTransationListQueryHandler : IRequestHandler<GetTransationListQuery, TransationListVm>
        {
            public Task<TransationListVm> Handle(GetTransationListQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
