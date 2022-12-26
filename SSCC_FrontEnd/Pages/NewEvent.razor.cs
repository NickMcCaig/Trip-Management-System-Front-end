using System;
using BackEndAPI;
using Microsoft.AspNetCore.Components;

namespace SSCC_FrontEnd.Pages
{
    public partial class NewEvent
    {
        private string? errorMessage { get; set; }
        [Inject]
        public BackEndAPI.swaggerClient? _client { get; set; }
        private NewEventDto newEvent = new NewEventDto() { StartDateTime = DateTime.Now, EndDateTime = DateTime.Now};
        private async void NewEventCreation()
        {
            try
            {
                 var createdEvent = await _client.EventAsync(newEvent);
                errorMessage = $"Event Created : {createdEvent.Id}";
              
            }
            catch
            {
                errorMessage = "Event Creation failed";
            }
            StateHasChanged();

        }
    }
}

