
namespace ParkingManagement.Constracts.Utils
{
    public static class CalculateTotalHour
    {
        public static double Calculate(string start, string end)
        {
            var startTime = DateTime.Parse(start);
            var endTime = DateTime.Parse(end);
            var totalHour = (endTime - startTime).TotalHours;
            return totalHour;
        }
    }
}
