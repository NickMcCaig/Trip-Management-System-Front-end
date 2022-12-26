using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SSCC_FrontEnd;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient("WebAPI");
builder.Services.AddScoped<BackEndAPI.swaggerClient>(sp => new BackEndAPI.swaggerClient(
    //"https://localhost:7211/",
    "https://nicksscc.azurewebsites.net/",
    new HttpClient()
    ));
await builder.Build().RunAsync();

