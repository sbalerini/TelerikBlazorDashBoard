using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;


namespace BlazorOE01
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            this._localStorage = localStorage;
        }
        public override async Task<AuthenticationState>  GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());
            string username = await _localStorage.GetItemAsStringAsync("username");
            if (!string.IsNullOrEmpty(username)) {
                var identity = new ClaimsIdentity(new[]
                {
                     new Claim(ClaimTypes.Name, username)

                 }, "test authentication type");

            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
