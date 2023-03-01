namespace OfferAggregator.Bll.Models
{
    public class ManagerAuthInputModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public ManagerAuthInputModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
