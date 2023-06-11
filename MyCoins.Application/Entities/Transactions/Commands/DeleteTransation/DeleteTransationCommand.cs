using MediatR;

namespace MyCoins.Application.Entities.Transactions.Commands.DeleteTransation
{
    public class DeleteTransationCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public class DeleteTransationCommandHandler : IRequestHandler<DeleteTransationCommand>
        {
            public DeleteTransationCommandHandler() {}

            public async Task Handle(DeleteTransationCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
}
