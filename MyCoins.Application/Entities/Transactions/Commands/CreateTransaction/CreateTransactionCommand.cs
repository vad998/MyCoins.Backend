using MediatR;
using MyCoins.Domain.Entities;

namespace MyCoins.Application.Entities.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        protected Transaction BuildTransationEntity()
        {
            return new Transaction()
            {
                Id = Guid.NewGuid(),
                Amount = Amount,
                CreationDate = DateTime.UtcNow,
                Description = Description,
                UserId = UserId,
                FromId = FromId,
                ToId = ToId
            };
        }

        public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
        {
            public CreateTransactionCommandHandler() {}

            public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
