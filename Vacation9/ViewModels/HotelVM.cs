using Vacation9.Domains.Entities;

namespace Vacation9.ViewModels
{
    public class HotelVM
    {
        public string? NameHotel { get; set; }
        public int Stars { get; set; }
        public double Score { get; set; }
        public string? Benefit { get; set; }
        public string? Photo { get; set; }
        public string? City { get; set; }
        public CountryType Country { get; set; }
    }
}
