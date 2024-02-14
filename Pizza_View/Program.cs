using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pizza_View;
using Pizza_View.Models;
using Pizza_View.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<ICrudService<Pizza>, PizzaFakeDbService>();
builder.Services.AddSingleton<ICrudService<Ingredient>, IngredientFakeDbService>();

await builder.Build().RunAsync();
