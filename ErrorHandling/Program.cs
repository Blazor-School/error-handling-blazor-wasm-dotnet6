using ErrorHandling;
using ErrorHandling.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ExceptionRecorderService>();
builder.Services.AddHttpClient<BlazorSchoolHttpClientWrapper>((sp, httpClient) => httpClient.BaseAddress = new(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
