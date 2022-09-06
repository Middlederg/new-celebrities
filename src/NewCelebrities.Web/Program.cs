using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewCelebrities.Web;
using NewCelebrities.Web.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<GameCreator>();
builder.Services.AddScoped<OptionLister>();
builder.Services.AddScoped<GameOptionsService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();

var settings = new ApiSettings();
builder.Configuration.Bind("ApiSettings", settings);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings.BaseUrl) });

await builder.Build().RunAsync();
