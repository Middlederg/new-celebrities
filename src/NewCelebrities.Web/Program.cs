using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewCelebrities.Web;
using NewCelebrities.Web.Services;
using Blazored.LocalStorage;
using System.Globalization;
using NewCelebrities.Web.Translations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddLocalization();
builder.Services.AddScoped<LanguageSelector>();
builder.Services.AddScoped<GameCreator>();
builder.Services.AddScoped<GameOptionsService>();
builder.Services.AddScoped<OptionLister>();
builder.Services.AddScoped<RoundTranslator>();
builder.Services.AddScoped<PointsInRoundTranslator>();

var settings = new ApiSettings();
builder.Configuration.Bind("ApiSettings", settings);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings.BaseUrl) });

var host = builder.Build();

var languageSelector = host.Services.GetRequiredService<LanguageSelector>();
var currentCulture = await languageSelector.GetCurrentCulture();
Console.WriteLine(currentCulture);
if (currentCulture is null)
{
    await languageSelector.SetCurrentCulture("en-US");
}
else
{
    CultureInfo.DefaultThreadCurrentCulture = currentCulture;
    CultureInfo.DefaultThreadCurrentUICulture = currentCulture;
}

await host.RunAsync();