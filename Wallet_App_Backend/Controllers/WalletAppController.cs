using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WalletAppBackend.Data;
using WalletAppBackend.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wallet_App_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletAppController : ControllerBase
    {

        private readonly DataBaseContext _dbc;

        public WalletAppController(DataBaseContext dbContext)
        {
            _dbc = dbContext;
        }

        [HttpGet("GetAllData/")]
        public string GetAllData()
        {
            List<Users> users = _dbc.users.ToList();
            List<Transactions> transactions = _dbc.transactions.ToList();
            List<SeasonalPoints> points = _dbc.seasonalpoints.ToList();

            Data data = new Data(users, transactions, points);
            string json = JsonConvert.SerializeObject(data);
            return json;

        }

        [HttpGet("GetUser/{Id}")]
        public string GetUser([FromRoute] int Id)
        {
            Users user = _dbc.users.FirstOrDefault(w => w.id == Id);
            string json = JsonConvert.SerializeObject(user);
            return json;
        }

        [HttpGet("GetSeasonalPoints/{Id}")]
        public string GetSeasonalPoints([FromRoute] int Id)
        {
            SeasonalPoints sPoints = _dbc.seasonalpoints.FirstOrDefault(w => w.id == Id);
            string json = JsonConvert.SerializeObject(sPoints);
            return json;
        }

        [HttpGet("GetTransactions/{Id}")]
        public string GetTransactions([FromRoute] int Id)
        {
            Transactions transaction = _dbc.transactions.FirstOrDefault(w => w.id == Id);
            string json = JsonConvert.SerializeObject(transaction);
            return json;
        }


        [HttpGet("GetCardBalance/{Id}")]
        public string GetCardBalance([FromRoute] int Id)
        {
            Users user = _dbc.users.FirstOrDefault(w => w.id == Id);
            return user.balance.ToString();
        }

        [HttpGet("CountDailyPoints/")]
        public string CountDailyPoints()
        {
            PointCalculator pointCalculator = new PointCalculator();
            string sum = pointCalculator.CalculatePointsForDay();
            return sum;
        }


        [HttpGet("GetLatestTransactions/")]
        public string GetLatestTransactions()
        {
            List<Transactions> transactions = _dbc.transactions.OrderBy(t => t.date).Take(10).ToList();
            string json = JsonConvert.SerializeObject(transactions);
            return json;
        }
       

    }
}