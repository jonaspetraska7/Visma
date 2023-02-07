namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static int Age(this DateTime birthDate)
        {
            return (int)((DateTime.Now - birthDate).TotalDays / 365.242199);
        }
    }
}
