using Microsoft.Net.Http.Headers;
using TestMVC.Dtos;
using TestMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddHttpClient("TestApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://swcoretestapi.azurewebsites.net/");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");   
});
builder.Services.AddHttpClient("DevTestApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7013/");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});*/

builder.Services.AddHttpClient<ApiService<UserDto>>(
    client =>
    {
        client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    });
builder.Services.AddHttpClient<ApiService<EventDto>>(
    client =>
    {
        client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
