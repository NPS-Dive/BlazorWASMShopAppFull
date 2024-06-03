using BlazorWASM;
using BlazorWASM.Library.Cart.Contracts;
using BlazorWASM.Library.Cart.Services;
using BlazorWASM.Library.Products.Contracts;
using BlazorWASM.Library.Products.Services;
using BlazorWASM.Library.Storage.Contracts;
using BlazorWASM.Library.Storage.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICartService, CartService>();


await builder.Build().RunAsync();
