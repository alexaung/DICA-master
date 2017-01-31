using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dica.Repositories
{
    public static class DropDownListRepository
    {
        
        public static List<SelectListItem> GetRegions()
        {
            //var regions = PortPlannerRepository.GetRegion();
            //var items = new List<SelectListItem>();
            //regions.ForEach(r =>
            //{
            //    items.Add(new SelectListItem { Text = r, Value = r });
            //});
            var items = new List<SelectListItem>
            {
                new SelectListItem { Text = "Ayeyarwady", Value = "Ayeyarwady" },
                new SelectListItem { Text = "Bago", Value = "Bago" },
                new SelectListItem { Text = "Chin", Value = "Chin" },
                new SelectListItem { Text = "Kachin", Value = "Kachin" },
                new SelectListItem { Text = "Kayah", Value = "Kayah" },
                new SelectListItem { Text = "Kayin", Value = "Kayin" },
                new SelectListItem { Text = "Magway", Value = "Magway" },
                new SelectListItem { Text = "Mandalay", Value = "Mandalay" },
                new SelectListItem { Text = "Mon", Value = "Mon" },
                new SelectListItem { Text = "Rakhine", Value = "Rakhine" },
                new SelectListItem { Text = "Shan", Value = "Shan" },
                new SelectListItem { Text = "Sagaing", Value = "Sagaing" },
                new SelectListItem { Text = "Tanintharyi", Value = "Tanintharyi" },
                new SelectListItem { Text = "Yangon", Value = "Yangon" },
                new SelectListItem { Text = "Naypyidaw", Value = "Naypyidaw" }
            };
            return items;
        }        
    }
}