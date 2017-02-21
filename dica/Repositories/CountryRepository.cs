using dica.Models;
using System.Collections.Generic;
using System.Linq;

namespace dica.Repositories
{
    public static class CountryRepository
    {
        public static List<Country> GetCountries()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = from country in db.Countries
                            select country;
                var contries = query.OrderBy(c=> c.Name).ToList();
                return contries;
            }
        }
    }
}