using MediatR;

namespace MyCoins.Application.Entities.Transactions.Queries.GetTransationDetails
{
    public class GetTransationDetailsQuery : IRequest<TransationDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public class GetTransationDetailsQueryHandler : IRequestHandler<GetTransationDetailsQuery, TransationDetailsVm>
        {
            public GetTransationDetailsQueryHandler() { }

            public async Task<TransationDetailsVm> Handle(GetTransationDetailsQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}
