using AdvAsmPlanning.Client;
using AdvAsmPlanning.Client.Helper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Read API base URL from configuration
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("Configuration Missing: API URL Not Found.");

// Register HttpClient with HttpClientFactory
builder.Services.AddHttpClient("ASMClient", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.DefaultRequestHeaders.Add("User-Agent", "ASM");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<HttpHelper>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
