using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace OfferAggregator.UI
{
    public class Authentication : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;

        public Authentication(ISessionStorageService sessionStorageService) 
        {
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var login = await _sessionStorageService.GetItemAsync<string>("Login");
            var id = await _sessionStorageService.GetItemAsync<string>("Id");
            ClaimsIdentity identity;

            if (login != null && id !=null)
            {
                identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, login),
                        new Claim("ID", id),
                    }, "Custom Authentication");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void AuthenticateUser(string name, int id)
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, name),
            new Claim("ID", id.ToString()),
            }, "Custom Authentication");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(user)));
        }

        public void LogoutUser()
        {
            _sessionStorageService.RemoveItemAsync("Login");
            _sessionStorageService.RemoveItemAsync("Id");

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(user)));
        }
    }
}
