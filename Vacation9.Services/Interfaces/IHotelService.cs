using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation9.Domains.Entities;

namespace Vacation9.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();

        Task<IEnumerable<Hotel>> GetHotelsByCountryAsync(CountryType country);
    }
}
