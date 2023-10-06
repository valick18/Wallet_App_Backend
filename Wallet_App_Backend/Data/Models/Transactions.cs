namespace WalletAppBackend.Data.Models
{
    public class Transactions
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public string transactionname { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

    }
}
