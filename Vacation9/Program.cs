using Microsoft.EntityFrameworkCore;
using Vacation9.Domains.Data;
using Vacation9.Domains.Entities;
using Vacation9.Repositories;
using Vacation9.Repositories.Interfaces;
using Vacation9.Services;
using Vacation9.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryHotelDb"));

builder.Services.AddScoped<IHotelDAO, HotelDAO>();
builder.Services.AddScoped<IHotelService, HotelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
    if (!db.Hotels.Any())
    {
        db.Hotels.AddRange(
            new Hotel { Id = 1, NameHotel = "Hotel Europe", City = "Oostende", Country = CountryType.Coast, Score = 7.8, Stars = 4, Benefit = "Familiehotel bij uitstek", Photo="HotelEurope.jpg" },
            new Hotel { Id = 2, NameHotel = "Domein Westhoek", City = "Oostduinkerke", Country = CountryType.Coast, Score = 7.3, Stars = 3, Benefit = "Zwembad & wellness", Photo = "DomeinWesthoek_Oostduinkerke.jpg" },
            new Hotel { Id = 3, NameHotel = "Ibis De Haan", City = "De Haan", Country = CountryType.Coast, Score = 8.1, Stars = 4, Benefit = "Strand op 350m", Photo = "ibisDeHaan_DeHaan.jpg" },
            new Hotel { Id = 4, NameHotel = "C-Hotels Excelsior", City = "Middelkerke", Country = CountryType.Coast, Score = 8.5, Stars = 4, Benefit = "Zwembad & wellness", Photo = "C-HotelsExcelsior_Middelkerke.jpg" },
            new Hotel { Id = 5, NameHotel = "Hotel Le Val De Poix", City = "St-Hubert", Country = CountryType.Wallonia, Score = 8, Stars = 4, Benefit = "Zwembad & wellness", Photo = "HotelLeValDePoix_St-Hubert.jpg" },
            new Hotel { Id = 6, NameHotel = "Hotel Radisson Blu Balmoral", City = "Spa", Country = CountryType.Wallonia, Score = 6.5, Stars = 3, Benefit = "Zwembad & wellness", Photo = "HotelRadissonBluBalmoral_Spa.jpg" }
        );
        db.SaveChanges();
    }
}


app.Run();
