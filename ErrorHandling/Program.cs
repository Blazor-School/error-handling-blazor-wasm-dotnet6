using ErrorHandling;
using ErrorHandling.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ExceptionRecorderService>();
builder.Services.AddHttpClient<BlazorSchoolHttpClientWrapper>((sp, httpClient) => httpClient.BaseAddress = new(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped<ExceptionRecorderService2>();
builder.Services.AddHttpClient("Blazor School HttpClient with middleware", httpClient => httpClient.BaseAddress = new(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BlazorSchoolHttpClientMiddleware>();
builder.Services.AddTransient<BlazorSchoolHttpClientMiddleware>();

await builder.Build().RunAsync();
