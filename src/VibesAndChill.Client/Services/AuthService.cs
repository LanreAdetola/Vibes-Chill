using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using VibesAndChill.Shared.Models;

namespace VibesAndChill.Client.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);
        Task<bool> Register(RegisterDto registerDto);
        Task Logout();
        Task<bool> IsAuthenticated();
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(
            HttpClient httpClient,
            AuthenticationStateProvider authStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<bool> Login(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", new { username, password });
            
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                await _localStorage.SetItemAsync("authToken", token.Token);
                ((ApiAuthenticationStateProvider)_authStateProvider).MarkUserAsAuthenticated(token.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                return true;
            }
            
            return false;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerDto);
            return response.IsSuccessStatusCode;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrEmpty(token);
        }
    }
}
