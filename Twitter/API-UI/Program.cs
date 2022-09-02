using Infrastructure;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// add HttpClient
builder.Services.AddHttpClient<TwitterClient>(options => {
    options.BaseAddress = new Uri("https://api.twitter.com/2/");
    options.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "AAAAAAAAAAAAAAAAAAAAAIpiggEAAAAAJyMUB7iTBt%2BS1k8o1wo9AydXs%2FI%3Dw9XPjKYT7XOBxKQnCsg2t85KcdjuS5FBwpAd1Jj39PT37VUuUX");
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
