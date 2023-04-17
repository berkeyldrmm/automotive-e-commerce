using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Otomativ_e_ticaret.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(UrunManager), new UrunManager(new EfUrun())));
builder.Services.Add(new ServiceDescriptor(typeof(SepetDTO), new SepetDTO()));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
