using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BackEndAPI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
namespace SSCC_FrontEnd.Pages
{
    public partial class Login
    {
        private string? username;
       
        private string? password;
        private string? email;
        private string? errorMessage;
        [Inject]
        public BackEndAPI.swaggerClient _client { get; set; }
        protected async void LoginAsync()
        {
            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
            {
                try
                {
                    var authresp = await _client.LoginAsync(new LoginModel() { Password = password, Username = username });
                    _client.AddAuth(authresp.Token);
                    errorMessage = "Login worked";
                }
                catch (ApiException)
                {
                      errorMessage = "Login failed";      
                }
                // email = authresp\
                StateHasChanged();

            }
        }
        protected async void RegisterAsync()
        {
            try
            {
                await _client.RegisterAsync(new RegisterModel() { Email = email, Password = password, Username = username });
                errorMessage = "User Registered";
            }
            catch (ApiException ex)
            {
                errorMessage = "Registration failed" + ex.Response;
            }
            // email = authresp\
            StateHasChanged();
        }
    }
}

