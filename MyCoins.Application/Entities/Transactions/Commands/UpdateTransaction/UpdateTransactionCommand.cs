using MediatR;
using MyCoins.Domain.Entities;

namespace MyCoins.Application.Entities.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }

        protected Transaction BuildTransationEntity()
        {
            return new Transaction()
            {
                Id = Id,
                Amount = Amount,
                Description = Description,
                UserId = UserId,
                FromId = FromId,
                ToId = ToId
            };
        }

        public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
        {
            public UpdateTransactionCommandHandler() {}

            public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
