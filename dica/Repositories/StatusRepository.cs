using dica.Models;
using System.Collections.Generic;
using System.Linq;

namespace dica.Repositories
{
    public class StatusRepository
    {
        public static List<Status> GetStatusByGroup(string groupName)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = from status in db.Statuses
                            select status;
                var statues = query.OrderBy(s=> s.Order).ToList();
                return statues;
            }
        }
    }
}