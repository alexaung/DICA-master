using dica.Models;
using dica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dica.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult InvestmentByCountry(InvestmentByCountryViewModel model)
        {
            model.InvestmentByCountries = ReportRepository.GetInvestmentByCountry(model);
            model.Countries = model.InvestmentByCountries.Select(s => new Country { Name = s.Country }).Distinct().OrderBy(c=> c.Name).ToList();
            model.Sectors = StatusRepository.GetStatusByGroup("Sector");

            //model.FromDate = DateTime.Now;
            //model.ToDate = DateTime.Now;
            return View(model);
        }
    }
}