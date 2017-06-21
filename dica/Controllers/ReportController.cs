using dica.Helper;
using dica.Models;
using dica.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace dica.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult InvestmentByCountry(InvestmentByCountryViewModel model)
        {
            model.InvestmentByCountries = ReportRepository.GetInvestmentByCountry(model);
            model.Countries = model.InvestmentByCountries.Select(s => new Country { Name = s.Country }).Distinct().OrderBy(c => c.Name).ToList();
            model.Sectors = StatusRepository.GetStatusByGroup("Sector");

            //model.FromDate = DateTime.Now;
            //model.ToDate = DateTime.Now;
            return View(model);
        }

        public ActionResult InvestmentByCountryExport(InvestmentByCountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        model.InvestmentByCountries = ReportRepository.GetInvestmentByCountry(model);
                        model.Countries = model.InvestmentByCountries.Select(s => new Country { Name = s.Country }).Distinct().OrderBy(c => c.Name).ToList();
                        model.Sectors = StatusRepository.GetStatusByGroup("Sector");

                        var exporterService = new ExcelExportService();
                        var workbook = exporterService.ExportByCountry(model);

                        //Write the Workbook to a memory stream
                        workbook.Write(ms);

                        var fileName = "Foreign investment Chart (" + DateTime.Now.ToString("ddMMyyyy-HHmmss") + ")." + exporterService.Extension;
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                        //Return the result to the end user
                        return File(ms.ToArray(), exporterService.MIME);
                        //Suggested file name in the "Save as" dialog which will be displayed to the end user
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error in - ExportToExcel :" + ex.Message);
                    return View("InvestmentByCountryExport");
                }
            }
            return View("InvestmentByCountryExport");
        }

        public ActionResult InvestmentByRegion(InvestmentByRegionViewModel model)
        {
            model.InvestmentByRegions = ReportRepository.GetInvestmentByRegion(model);
            model.Regions = model.InvestmentByRegions.Select(s => s.Region).Distinct().OrderBy(r => r).ToList();
            model.Sectors = StatusRepository.GetStatusByGroup("Sector");

            //model.FromDate = DateTime.Now;
            //model.ToDate = DateTime.Now;
            return View(model);
        }

        public ActionResult InvestmentByRegionExport(InvestmentByRegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        model.InvestmentByRegions = ReportRepository.GetInvestmentByRegion(model);
                        model.Regions = model.InvestmentByRegions.Select(s => s.Region).Distinct().OrderBy(c => c).ToList();
                        model.Sectors = StatusRepository.GetStatusByGroup("Sector");

                        var exporterService = new ExcelExportService();
                        var workbook = exporterService.ExportByRegion(model);

                        //Write the Workbook to a memory stream
                        workbook.Write(ms);

                        var fileName = "Foreign investment Chart (" + DateTime.Now.ToString("ddMMyyyy-HHmmss") + ")." + exporterService.Extension;
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

                        //Return the result to the end user
                        return File(ms.ToArray(), exporterService.MIME);
                        //Suggested file name in the "Save as" dialog which will be displayed to the end user
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error in - ExportToExcel :" + ex.Message);
                    return View("InvestmentByCountryExport");
                }
            }
            return View("InvestmentByCountryExport");
        }
    }
}