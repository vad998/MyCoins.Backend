using MediatR;

namespace MyCoins.Application.Entities.Transactions.Queries.GetTransationList
{
    public class GetTransationListQuery : IRequest<TransationListVm>
    {
        public Guid UserId { get; set; }

        public class GetTransationListQueryHandler : IRequestHandler<GetTransationListQuery, TransationListVm>
        {
            public Task<TransationListVm> Handle(GetTransationListQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
