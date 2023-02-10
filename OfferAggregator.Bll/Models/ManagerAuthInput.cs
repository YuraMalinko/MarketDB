namespace OfferAggregator.Bll.Models
{
    public class ManagerAuthInput
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public ManagerAuthInput(string? login, string? password)
        {
            Login = login;
            Password = password;
        }
    }
}
