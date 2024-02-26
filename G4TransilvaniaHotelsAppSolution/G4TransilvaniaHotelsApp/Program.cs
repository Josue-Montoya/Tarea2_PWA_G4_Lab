using FluentValidation;
using G4TransilvaniaHotelsApp.Data;
using G4TransilvaniaHotelsApp.Models;
using G4TransilvaniaHotelsApp.Repositories;
using G4TransilvaniaHotelsApp.RepositoriesClient;
using G4TransilvaniaHotelsApp.Validations;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<SqlDataAccess>();
builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

//Validaciones
builder.Services.AddScoped<IValidator<HotelsModel>, Hotels>();
builder.Services.AddScoped<IValidator<RoomModel>, Room>();
builder.Services.AddScoped<IValidator<ClientModel>, Client>();
builder.Services.AddScoped<IValidator<ReservationModel>, ReservationValidator>();

//trd
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");


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
