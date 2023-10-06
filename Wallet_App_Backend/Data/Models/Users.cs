namespace WalletAppBackend.Data.Models
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string passwordhash { get; set; }
        public string email { get; set; }
        public int balance { get; set; }

    }
    
}
