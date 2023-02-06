namespace OfferAggregator.Dal
{
    public class Options
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("SqlConnect")!;
    }
}