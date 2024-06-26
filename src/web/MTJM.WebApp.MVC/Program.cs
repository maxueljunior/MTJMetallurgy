using Microsoft.AspNetCore.Authentication.Cookies;
using MTJM.WebApp.MVC.Handler;
using MTJM.WebApp.MVC.Helpers;
using MTJM.WebApp.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IClaimsHelpers, ClaimsHelpers>();

builder.Services.AddTransient<IRequestApiService, RequestApiService>();
builder.Services.AddTransient<CustomHttpClientHandler>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.Cookie.Name = "MTJMCookie";
    });

builder.Services.AddHttpClient("ApiClient")
    .ConfigureHttpClient((provider, c) =>
    {
        c.BaseAddress = new Uri("https://localhost:7009/api/");
    })
    .AddHttpMessageHandler<CustomHttpClientHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
