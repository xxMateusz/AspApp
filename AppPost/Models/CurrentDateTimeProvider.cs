namespace AppPost.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
