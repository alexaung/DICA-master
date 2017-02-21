using dica.Models;
using dica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dica.Controllers
{
    public class InvestmentController : BaseController
    {
        // GET: Investment
        public ActionResult Index()
        {
            List<InvestmentViewModel> investments = InvestmentRepository.GetInvestments();
            return View(investments);
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
            investment.CapitalDetails = new List<CapitalDetail>();
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Cash" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Machinery" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Land Rental" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Utilities & Infrastructure" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Building" });
            investment.CapitalDetails.Add(new CapitalDetail { Description = "Raw Material" });
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
            if(investment.CapitalDetails == null || investment.CapitalDetails.Count == 0)
            {
                investment.CapitalDetails = new List<CapitalDetail>();
                investment.CapitalDetails.Add(new CapitalDetail { Description = "Cash" });
                investment.CapitalDetails.Add(new CapitalDetail { Description = "Machinery" });
                investment.CapitalDetails.Add(new CapitalDetail { Description = "Land Rental" });
                investment.CapitalDetails.Add(new CapitalDetail { Description = "Utilities & Infrastructure" });
                investment.CapitalDetails.Add(new CapitalDetail { Description = "Building" });
                investment.CapitalDetails.Add(new CapitalDetail { Description = "Raw Material" });
            }
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
    }
}
