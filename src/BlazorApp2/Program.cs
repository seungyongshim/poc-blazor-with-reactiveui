using BlazorApp2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proto;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var system = new ActorSystem();
var context = system.Root;
var props = Props.FromProducer(() => new CounterActor());
var pid = context.SpawnNamed(props, "CounterActor");

builder.Services.AddSingleton(context);

await builder.Build().RunAsync();
