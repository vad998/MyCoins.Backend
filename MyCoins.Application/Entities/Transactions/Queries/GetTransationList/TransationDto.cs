namespace MyCoins.Application.Entities.Transactions.Queries.GetTransationList
{
    public class TransationDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Description { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }
    }
}
