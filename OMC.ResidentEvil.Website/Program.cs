using Microsoft.Extensions.Options;
using OMC.ResidentEvil.BackEnd.Classes;
using OMC.ResidentEvil.BackEnd.Services;
using OMC.ResidentEvil.Website.Components;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();

// Register ApiSettings
builder.Services.Configure<ApiSettings>(
        builder.Configuration.GetSection("ApiSettings")
        );

// Get Url from ApiSettings
builder.Services.AddHttpClient("MyApi", (sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(settings.TimeoutSeconds);
});

// Register HttpService
builder.Services.AddScoped<HttpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
