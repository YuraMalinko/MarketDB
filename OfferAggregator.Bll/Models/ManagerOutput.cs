namespace OfferAggregator.Bll.Models
{
    public class OutsideManager
    {
        public int Id { get; set; }

        public string? Login { get; set; }

        public OutsideManager(int id, string? login)
        {
            Id=id;
            Login=login;
        }
    }
}
