using HotelReservasapp.DataAccess;
using HotelReservasapp.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataAccess(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

//Borrar
app.MapGet("/diagnostico/base-datos", async (
    HotelReservationDbContext context) =>
{
    var conectado = await context.Database.CanConnectAsync();

    return conectado
        ? Results.Ok(new { mensaje = "Conexión correcta con SGRHotel." })
        : Results.Problem("No se pudo conectar con la base de datos.");
});
//================
app.Run();
