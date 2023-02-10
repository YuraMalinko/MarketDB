namespace OfferAggregator.Bll.Models
{
    public class CurrentManager
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public CurrentManager(int id, string? login, string? password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}
