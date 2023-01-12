using System;
using BackEndAPI;
using Microsoft.AspNetCore.Components;
namespace SSCC_FrontEnd.Pages
{
    public partial class EditEvent
    {
        private ICollection<string>? errorMessages { get; set; }
        private EventDto? MyEvent { get; set; }
        private ICollection<string>? paricipents { get; set; }

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
        private async void DeleteEvent()
        {
            try
            {
                await _client.Event4Async(Id);
                errorMessages = new List<string> { "Event deleted." };
                StateHasChanged();
            }
            catch
            {
                errorMessages = new List<string> { "Event deletion failed. Does it exist?" };
                StateHasChanged();
            }
        }
        private async void UpdateEvent()
        {
               try
                {
                    await _client.Event3Async(Id, MyEvent);
                    errorMessages = new List<string> { "Event Updated." };
                }
                catch (ApiException<ValidationResult> ex)
                {

                    errorMessages = ex.Result.Errors.Select(i => i.ErrorMessage).ToList();
                }

            StateHasChanged();

        }


    }
}

