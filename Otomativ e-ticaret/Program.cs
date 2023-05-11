using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.Sepet;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Otomativ_e_ticaret.Controllers;
using Otomativ_e_ticaret.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<IUrunService>(obj => new UrunManager(new EfUrun()));
builder.Services.AddSingleton<IHakkimizdaService>(obj => new HakkimizdaManager(new EfHakkimizda()));
builder.Services.AddSingleton<IMesajService>(obj => new MesajManager(new EfMesaj()));
builder.Services.AddSingleton<IAdminService>(obj => new AdminManager(new EfAdmin()));
builder.Services.AddSingleton<IKategoriService>(obj => new KategoriManager(new EfKategori()));
builder.Services.AddSingleton<IMarkaService>(obj => new MarkaManager(new EfMarka()));
builder.Services.AddSingleton<ISiparisDetayService>(obj => new SiparisDetayManager(new EfSiparisDetay()));
builder.Services.Add(new ServiceDescriptor(typeof(SepetDTO), new SepetDTO()));
builder.Services.AddSingleton<ISiparisService>(obj=>new SiparisManager(new EfSiparis(),new UrunManager(new EfUrun())));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "adminLogIn",
    pattern: "admin",
    defaults: new { controller = "Admin", action = "LogIn" }
);

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "admin/{controller=Home}/{action=Index}/{id?}",
//    defaults: new { controller = "LogIn", action = "Index" }
//);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

