using System;
using BackEndAPI;
using Microsoft.AspNetCore.Components;
namespace SSCC_FrontEnd.Pages
{
    public partial class Event
    {
        private string errorMessage { get; set; }
        private EventDto? MyEvent { get; set; }
        private ICollection<string>?  paricipents { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public Guid Id { get; set; }
        private WeatherDayDTO? weatherForEvent { get; set; }

        [Inject]
        public BackEndAPI.swaggerClient? _client { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                MyEvent = await _client.Event2Async(Id);
                paricipents = await _client.ParticipantsAsync(Id);
                weatherForEvent = await _client.Weather2Async(Id, MyEvent.StartDateTime);

            }
            catch
            {

            }

         }
        protected async Task DeleteEvent()
        {
            try
            {
                await _client.Event4Async(Id);
                navigationManager.NavigateTo("");

            }
            catch
            {
                errorMessage = "User not signed in ";
                StateHasChanged();
            }
        }
        protected async Task RegisterInterest()
        {
            try {
                await _client.ExpressInterestAsync(Id);
                paricipents = await _client.ParticipantsAsync(Id);
            }
            catch (ApiException ex)
            {
                errorMessage = "User not signed in.";
                StateHasChanged();
            }
        }
        protected async Task RevokeInterest()
        {
            try
            {
                await _client.RevokeInterestAsync(Id);
                paricipents = await _client.ParticipantsAsync(Id);

            }
            catch (ApiException ex)
            {
                errorMessage = "User not signed in.";
                StateHasChanged();

            }
        }
        public void NavigateToEditEvent()
        {
            navigationManager.NavigateTo($"Event/{Id}/Edit");
        }



    }
}

