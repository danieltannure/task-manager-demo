using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TaskManager.UI.Components;

var builder = WebApplication.CreateBuilder(args);


var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];


builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});



builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
