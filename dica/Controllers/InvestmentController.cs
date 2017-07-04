using dica.Models;
using dica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace dica.Controllers
{
    [Authorize]
    public class InvestmentController : BaseController
    {
        //const int RecordsPerPage = 10;
        // GET: Investment
        //public ActionResult Index()
        //{
        //    InvestmentSearchViewModel model = new InvestmentSearchViewModel();
        //    List<InvestmentViewModel> investments = InvestmentRepository.GetInvestments();
        //    var pageIndex = model.Page ?? 1;
        //    model.SearchResults = investments.ToPagedList(pageIndex, RecordsPerPage);
        //    return View(model);
        //}

        public ActionResult Index(InvestmentSearchViewModel model)
        {
            //List<InvestmentViewModel> investments = InvestmentRepository.GetInvestments(model);
            //var pageIndex = model.Page ?? 1;
            model.SearchResults = InvestmentRepository.GetInvestments(model);
            return View(model);
        }

        // GET: Investment/Details/5
        public ActionResult Details(Guid id)
        {
            InvestmentViewModel investment = InvestmentRepository.GetInvestment(id);
            return View(investment);
        }

        // GET: Investment/Create
        public ActionResult Create()
        {
            var investment = new InvestmentViewModel();
            //investment.FinancialYearFrom = DateTime.Now.Year;
            //investment.FinancialYearTo = DateTime.Now.Year;
            investment.PermitDate = DateTime.Now;
            investment.CapitalDetails = new List<CapitalDetail>();
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Cash" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Machinery" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Land Rental" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Utilities & Infrastructure" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Building" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Raw Material" });

            investment.CapitalDetails = investment.CapitalDetails.OrderBy(cd => cd.Description).ToList();
            return View(investment);
        }

        // POST: Investment/Create
        [HttpPost]
        public ActionResult Create(InvestmentViewModel investment)
        {
            try
            {                
                InvestmentRepository.InsertInvestment(investment, User.Identity.Name);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //throw ex;
                return View(investment);
            }
        }

        // GET: Investment/Edit/5
        public ActionResult Edit(Guid id)
        {
            var investment = InvestmentRepository.GetInvestment(id);
            if (investment.CapitalDetails == null || investment.CapitalDetails.Count == 0)
            {
                investment.CapitalDetails = new List<CapitalDetail>();
                investment.CapitalDetails.Add(new CapitalDetail {Description = "Cash"});
                investment.CapitalDetails.Add(new CapitalDetail {Description = "Machinery"});
                investment.CapitalDetails.Add(new CapitalDetail {Description = "Land Rental"});
                investment.CapitalDetails.Add(new CapitalDetail {Description = "Utilities & Infrastructure"});
                investment.CapitalDetails.Add(new CapitalDetail {Description = "Building"});
                investment.CapitalDetails.Add(new CapitalDetail {Description = "Raw Material"});
            }
            investment.CapitalDetails = investment.CapitalDetails.OrderBy(cd => cd.Description).ToList();
            return View(investment);
        }

        // POST: Investment/Edit/5
        [HttpPost]
        public ActionResult Edit(InvestmentViewModel investment)
        {
            try
            {
                // TODO: Add update logic here
                InvestmentRepository.UpdateInvestment(investment,User.Identity.Name);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
                return View(investment);
            }
        }

        // GET: Investment/Delete/5
        public ActionResult Delete(Guid id)
        {
            var investment = InvestmentRepository.GetInvestment(id);
            return View(investment);
        }

        // POST: Investment/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, Investment investment)
        {
            try
            {
                // TODO: Add delete logic here
                InvestmentRepository.DeleteInvestment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult JointVenturePercentageList()
        {
            List<JointVenturePercentage> jointVenturePercentages = new List<JointVenturePercentage>();
            jointVenturePercentages.Add(new JointVenturePercentage {CompanyName = "AA", Country = "MM",Percentage = 10});
            jointVenturePercentages.Add(new JointVenturePercentage { CompanyName = "BB", Country = "MM", Percentage = 90 });
            return PartialView("JointVenturePercentageList", jointVenturePercentages);
        }

        public ActionResult GetCountries()
        {
            var countries = CountryRepository.GetCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCurrencies()
        {
            var currencies = StatusRepository.GetStatusByGroup("Currency");
            return Json(currencies, JsonRequestBehavior.AllowGet);
        }
    }
}
