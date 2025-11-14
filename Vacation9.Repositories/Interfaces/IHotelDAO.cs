using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation9.Domains.Entities;

namespace Vacation9.Repositories.Interfaces
{
    public interface IHotelDAO
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();

        Task<IEnumerable<Hotel>> GetHotelsByCountryAsync(CountryType country);
    }
}
