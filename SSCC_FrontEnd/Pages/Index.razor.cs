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
    public partial class Index
    {
        private string? searchTerm { get; set; }
        public IEnumerable<EventDto?>? events { get; set; }
        public WeatherResponse? currentWeather { get; set; }

        [Inject]
        public BackEndAPI.swaggerClient? _client { get; set; }
        [Inject]
        public NavigationManager? navigationManager { get; set; }
        public void NavigateToMyTrips()
        {
            navigationManager.NavigateTo("MyTrips");
        }
        public void NavigatetoEvent(Guid guid)
        {
            navigationManager.NavigateTo("Event/" + guid);
        }
        
        protected async override Task OnInitializedAsync()
        {
            events = await _client.EventAllAsync();
            //_client.AddAuth("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTmljayIsImp0aSI6ImFmMTRmODYwLThiNmQtNDNmMC04NGQ3LTZhMzdmNWExNWYzMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjcxMDM0NjE5LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDQxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzA0MSJ9.jWXtsMlFSPkJKlXnLzb8REHOL2iGkZseu-bG54WrXLg");
            
            //currentWeather = await _client.WeatherAsync(new Guid("c84d19d4-c647-44e5-9137-206142d6ea74"));
            //await _client.ExpressInterestAsync(new Guid("c84d19d4-c647-44e5-9137-206142d6ea74"));
        }
        private async void SearchForPlace()
        {
            Console.WriteLine(searchTerm);
            events = await _client.QueryAsync(searchTerm);
            StateHasChanged();

        }

    }
}

