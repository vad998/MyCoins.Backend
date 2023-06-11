namespace MyCoins.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }
    }
}
