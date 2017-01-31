using dica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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