using System;
using BackEndAPI;
using Microsoft.AspNetCore.Components;

namespace SSCC_FrontEnd.Pages
{
    public partial class MyTrips
    {
        public ICollection<EventDto>? events { get; set; }
        protected string? ErrorMessage;
        public WeatherResponse? currentWeather { get; set; }

        [Inject]
        public BackEndAPI.swaggerClient _client { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public void NavigatetoEvent(Guid guid)
        {
            navigationManager.NavigateTo("Event/" + guid);
        }
        protected async override Task OnInitializedAsync()
        {
            try {
                events = await _client.UserAllAsync();

            }
            catch 
            {
                ErrorMessage = "User not logged in";
            }

        }
    }
}

