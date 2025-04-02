using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TaskManager.UI.Components;
using TaskManager.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar o AppState como um singleton
builder.Services.AddSingleton<AppState>();

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

// Redireciona para o client da API
builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});



// Inclui o framework Blazor
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
