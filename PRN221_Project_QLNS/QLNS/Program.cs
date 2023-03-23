using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using QLNS.Data;
using QLNS.Hubs;
using QLNS.MiddlewareExtensions;
using QLNS.SubscribeTableDependencies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddRazorPages();

//Chinh trang default khi chay project
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Login", "");
});

//hello

//Add db context
var connectionString = builder.Configuration.GetConnectionString("MyCnn");
builder.Services.AddDbContext<PRN221_Project_QLNSContext>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Singleton
);


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<NotificationHub>();
builder.Services.AddSingleton<SubscribeNotificationTableDependency>();

builder.Services.AddDistributedMemoryCache();

//add session middleware
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Use dependency injection
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

//use session
app.UseSession();

app.UseRouting();
app.MapHub<NotificationHub>("/notificationHub");

app.UseAuthorization();

app.MapRazorPages();
app.UseSqlTableDependency<SubscribeNotificationTableDependency>(connectionString);
app.Run();


