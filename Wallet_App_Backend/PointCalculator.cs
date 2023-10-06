using WalletAppBackend.Data.Models;

namespace Wallet_App_Backend
{
    public class PointCalculator
    {

        public string CalculatePointsForDay() {
            DateTime currentDate = DateTime.Now; 
            DateTime startOfSeason = new DateTime(currentDate.Year, GetStartMonth(currentDate.Month), 1);
            int daysInSeason = (int)(currentDate - startOfSeason).TotalDays;
            int points = CalculatePoints(daysInSeason);
            return FormatPoints(points);
        }

        public int GetStartMonth(int currentMonth)
        {
            if (currentMonth >= 9 && currentMonth <= 11)
                return 9; // Весна
            else if (currentMonth >= 12 || currentMonth <= 2)
                return 12; // Зима
            else
                return 3; // Інші пори року
        }

        public int CalculatePoints(int daysInSeason)
        {
            if (daysInSeason == 0)
                return 2; // Перший день пори року

            if (daysInSeason == 1)
                return 3; // Другий день пори року

            int previousDayPoints = CalculatePoints(daysInSeason - 1);
            int dayBeforePreviousPoints = CalculatePoints(daysInSeason - 2);

            // Розраховуємо кількість поінтів на основі 60% попереднього дня та 100% дня перед тим
            int points = (int)Math.Round((0.6 * previousDayPoints + 1.0 * dayBeforePreviousPoints));

            return points;
        }


        private string FormatPoints(int points)
        {
            if (points >= 1000)
            {
                return (points / 1000) + "K";
            }
            else
            {
                return points.ToString();
            }
        }

    }
}