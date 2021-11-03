using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OneStreamWebBlazor.Client.Models;
using Newtonsoft.Json;

namespace OneStreamWebBlazor.Client
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;

        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync("User"))
            {
                var userInfo = await _storageService.GetItemAsync<LocalUserInfo>("User");
                Claim claimSI = new Claim("SI", JsonConvert.SerializeObject(userInfo.SessionInfo));
                Claim claimName = new Claim(ClaimTypes.Name, userInfo.FirstName);
                //Claim claimEmail = new Claim(ClaimTypes.Email, userInfo.Email);
                Claim claimAccessToken = new Claim("AccessToken", userInfo.AccessToken);
                Claim claimApplicationName = new Claim("ApplicationName", userInfo.ApplicationName);
                Claim claimBaseUrl = new Claim("BaseUrl", userInfo.BaseUrl);
                Claim claimId = new Claim(ClaimTypes.NameIdentifier, userInfo.Id);
                
                Claim claimDashboardProfiles = new Claim("DashboardProfiles", JsonConvert.SerializeObject(userInfo.DashboardProfiles));
                Claim claimCubeViewProfiles = new Claim("CubeViewProfiles", JsonConvert.SerializeObject(userInfo.CubeViewProfiles));

                
                var identity = new ClaimsIdentity(null, "BearerToken");
                identity.AddClaim(claimSI);
                identity.AddClaim(claimName);
                identity.AddClaim(claimAccessToken);
                identity.AddClaim(claimId);
                identity.AddClaim(claimApplicationName);
                identity.AddClaim(claimBaseUrl);
                identity.AddClaim(claimDashboardProfiles);
                identity.AddClaim(claimCubeViewProfiles);
                //identity.AddClaim(claimEmail);

                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
