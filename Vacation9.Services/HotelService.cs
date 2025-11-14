using Vacation9.Domains.Entities;
using Vacation9.Repositories.Interfaces;
using Vacation9.Services.Interfaces;

namespace Vacation9.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelDAO _hotelDao;

        public HotelService(IHotelDAO hotelDao)
        {
            _hotelDao = hotelDao;
        }
        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelDao.GetAllHotelsAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCountryAsync(CountryType country)
        {
            return await _hotelDao.GetHotelsByCountryAsync(country);
        }
    }
}
