using System;
using BackEndAPI;
using Microsoft.AspNetCore.Components;

namespace SSCC_FrontEnd.Pages
{
    public partial class NewEvent
    {
       
        private ICollection<string>? errorMessages { get; set; }
        [Inject]
        public BackEndAPI.swaggerClient? _client { get; set; }
        private NewEventDto newEvent = new NewEventDto() { StartDateTime = DateTime.Now, EndDateTime = DateTime.Now, Title = "", Location = "", LocationDesc= ""};
        private async void NewEventCreation()
        {
            try
            {
                 var createdEvent = await _client.EventAsync(newEvent);
                errorMessages =  new List<string> { $"Event Created : {createdEvent.Id}" };
              
            }
            catch (ApiException<ValidationResult> ex)
            {

                errorMessages = ex.Result.Errors.Select(i => i.ErrorMessage).ToList();
                StateHasChanged();
            }
            StateHasChanged();

        }
    }
}

