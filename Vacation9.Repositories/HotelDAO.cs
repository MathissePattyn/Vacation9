using Microsoft.EntityFrameworkCore;
using Vacation9.Domains.Data;
using Vacation9.Domains.Entities;
using Vacation9.Repositories.Interfaces;

namespace Vacation9.Repositories
{
    public class HotelDAO : IHotelDAO
    {
        private readonly HotelDbContext _db;

        public HotelDAO(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _db.Hotels.ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByCountryAsync(CountryType country)
        {
            return await _db.Hotels.Where(c => c.Country == country).ToListAsync();
        }
    }
}
