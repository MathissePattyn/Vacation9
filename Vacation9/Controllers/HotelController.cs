using Microsoft.AspNetCore.Mvc;
using Vacation9.Domains.Data;
using Vacation9.Domains.Entities;
using Vacation9.Services.Interfaces;
using Vacation9.ViewModels;

namespace Vacation9.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<IActionResult> Index(CountryType country)
        {
            try
            {
                var hotels = await _hotelService.GetHotelsByCountryAsync(country);
                if (hotels != null)
                {
                    List<HotelVM> HotelVMs = new List<HotelVM>();
                    foreach (var hotel in hotels)
                    {
                        var hotelVM = new HotelVM();
                        hotelVM.NameHotel = hotel.NameHotel;
                        hotelVM.Photo = hotel.Photo;
                        hotelVM.Stars = hotel.Stars;
                        hotelVM.Score = hotel.Score;
                        hotelVM.Benefit = hotel.Benefit;
                        hotelVM.City = hotel.City;
                        hotelVM.Country = hotel.Country;
                        HotelVMs.Add(hotelVM);
                    }
                    return View(HotelVMs);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Fout bij het ophalen van de hotels: " + ex.Message);
            }
            return View();
        }
    }
}
