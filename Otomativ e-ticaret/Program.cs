using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Otomativ_e_ticaret.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddFluentValidation();
//builder.Services.AddControllersWithViews().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<UrunDTO>());
builder.Services.Add(new ServiceDescriptor(typeof(UrunManager), new UrunManager(new EfUrun())));
//builder.Services.AddSingleton(new ServiceDescriptor(typeof(ISiparisDal), new SiparisManager(new EfSiparis())));
builder.Services.Add(new ServiceDescriptor(typeof(SepetDTO), new SepetDTO()));
//builder.Services.AddSingleton<ISiparisDal,EfSiparis>();

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

