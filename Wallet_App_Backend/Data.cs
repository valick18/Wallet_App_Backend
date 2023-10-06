using WalletAppBackend.Data.Models;

namespace Wallet_App_Backend
{
    public class Data
    {
        public Data(List<Users> users, List<Transactions> transactions, List<SeasonalPoints> points)
        {
            this.users = users;
            this.transactions = transactions;
            this.points = points;
        }

        public List<Users> users { get; set; }
        public List<Transactions> transactions { get; set; }
        public List<SeasonalPoints> points { get; set; }
    }
}
