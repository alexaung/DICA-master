using AutoMapper;
using dica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace dica.Repositories
{
    public class InvestmentRepository
    {
        static InvestmentRepository()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<InvestmentViewModel, Investment>();
                cfg.CreateMap<Investment, InvestmentViewModel>();
                }
            );
        }

        public static List<InvestmentViewModel> GetInvestments()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = from investment in db.Investments
                            select investment;
                var investments = query.ToList().Select(i => Mapper.Map<Investment, InvestmentViewModel>(i)).ToList();
                return investments;
            }
        }

        public static InvestmentViewModel GetInvestment(Guid uid)
        {
            using (var db = new ApplicationDbContext())
            {
                var investmentDto = (from investment in db.Investments
                            join investorAddress in db.Addresses on investment.InvestorAddressId equals investorAddress.UID
                            join organizationAddress in db.Addresses on investment.OrganizationAddressId equals organizationAddress.UID
                            join investmentPermittedAddress in db.Addresses on investment.InvestmentPermittedAddressId equals investmentPermittedAddress.UID
                            where investment.UID == uid
                            select new InvestmentViewModel {
                                UID = investment.UID,
                                InvestorName = investment.InvestorName,
                                Citizenship = investment.Citizenship,
                                InvestorAddress = investorAddress,
                                OrganizationName = investment.OrganizationName,
                                OrganizationAddress = organizationAddress,
                                IncorporationPlace = investment.IncorporationPlace,
                                BusinessType = investment.BusinessType,
                                InvestmentPermittedAddress = investmentPermittedAddress,
                                AmountofForeignCapital = investment.AmountofForeignCapital,
                                PeriodforForeignCapitalBroughtin = investment.PeriodforForeignCapitalBroughtin,
                                TotalAmountofCapitalInKyat = investment.TotalAmountofCapitalInKyat,
                                ConstructionPeriod = investment.ConstructionPeriod,
                                ValidityofInvestmentPermit = investment.ValidityofInvestmentPermit,
                                FormofInvestment = investment.FormofInvestment,
                                CompanyNameinMyanmar = investment.CompanyNameinMyanmar,
                                PermitNo = investment.PermitNo,
                                PermitDate = investment.PermitDate,
                                Sector = investment.Sector                              

                            }).FirstOrDefault();
                //var investmentDb = query.FirstOrDefault();
                //var investmentDto = Mapper.Map<Investment, InvestmentViewModel>(investmentDb);
                return investmentDto;
            }
        }

        public static void InsertInvestment(InvestmentViewModel investmentViewModel, string userName)
        {
            using (var db = new ApplicationDbContext())
            {
                var investorAddress = investmentViewModel.InvestorAddress;
                investorAddress.UID = Guid.NewGuid();

                var organizationAddress = investmentViewModel.OrganizationAddress;
                organizationAddress.UID = Guid.NewGuid();

                var investmentPermittedAddress = investmentViewModel.InvestmentPermittedAddress;
                investmentPermittedAddress.UID = Guid.NewGuid();

                var investment = Mapper.Map<InvestmentViewModel, Investment>(investmentViewModel);
                investment.UID = Guid.NewGuid();
                investment.CreatedBy = userName;
                investment.CreatedOn = DateTime.Now;
                investment.InvestorAddressId = investorAddress.UID;
                investment.OrganizationAddressId = organizationAddress.UID;
                investment.InvestmentPermittedAddressId = investmentPermittedAddress.UID;

                db.Addresses.Add(investorAddress);
                db.Addresses.Add(organizationAddress);
                db.Addresses.Add(investmentPermittedAddress);
                db.Investments.Add(investment);
                db.SaveChanges();
            }
        }

        public static void UpdateInvestment(InvestmentViewModel investmentViewModel, string userName)
        {
            using (var db = new ApplicationDbContext())
            {
                var investment = db.Investments.Where(i => i.UID == investmentViewModel.UID).FirstOrDefault();

                investment.InvestorName = investmentViewModel.InvestorName;
                investment.Citizenship = investmentViewModel.Citizenship;
                investment.InvestorAddressId = investmentViewModel.InvestorAddress.UID;
                investment.OrganizationName = investmentViewModel.OrganizationName;
                investment.OrganizationAddressId = investmentViewModel.OrganizationAddress.UID;
                investment.IncorporationPlace = investmentViewModel.IncorporationPlace;
                investment.BusinessType = investmentViewModel.BusinessType;
                investment.InvestmentPermittedAddressId = investmentViewModel.InvestmentPermittedAddress.UID;
                investment.AmountofForeignCapital = investmentViewModel.AmountofForeignCapital;
                investment.PeriodforForeignCapitalBroughtin = investmentViewModel.PeriodforForeignCapitalBroughtin;
                investment.TotalAmountofCapitalInKyat = investmentViewModel.TotalAmountofCapitalInKyat;
                investment.ConstructionPeriod = investmentViewModel.ConstructionPeriod;
                investment.ValidityofInvestmentPermit = investmentViewModel.ValidityofInvestmentPermit;
                investment.FormofInvestment = investmentViewModel.FormofInvestment;
                investment.CompanyNameinMyanmar = investmentViewModel.CompanyNameinMyanmar;
                investment.PermitNo = investmentViewModel.PermitNo;
                investment.PermitDate = investmentViewModel.PermitDate;
                investment.Sector = investmentViewModel.Sector;
                investment.ModifiedBy = userName;
                investment.ModifiedOn = DateTime.Now;

                db.Addresses.Attach(investmentViewModel.InvestorAddress);
                db.Entry(investmentViewModel.InvestorAddress).State = EntityState.Modified;

                db.Addresses.Attach(investmentViewModel.OrganizationAddress);
                db.Entry(investmentViewModel.OrganizationAddress).State = EntityState.Modified;

                db.Addresses.Attach(investmentViewModel.InvestmentPermittedAddress);
                db.Entry(investmentViewModel.InvestmentPermittedAddress).State = EntityState.Modified;

                db.Investments.Attach(investment);
                db.Entry(investment).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteInvestment(Guid uid)
        {
            using (var db = new ApplicationDbContext())
            {
                Investment investment = db.Investments.Find(uid);
                db.Investments.Remove(investment);
                db.SaveChanges();
            }
        }
    }
}