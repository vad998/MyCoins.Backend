namespace MyCoins.Domain
{
    public class Coin
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CoinType { get; set; }
        public Guid UserId { get; set; }
        public string? Description { get; set; }
    }
}
