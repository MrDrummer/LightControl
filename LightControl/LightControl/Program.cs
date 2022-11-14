using LightControl.Hubs;
using LightControl.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ILightControl, LightControlService>();
builder.Services.AddSingleton<ISerialService, SerialService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseCors(policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowAnyOrigin();
});

app.UseStaticFiles();
app.UseRouting();

app.MapHub<ArduinoHub>("/lightcontrolhub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
