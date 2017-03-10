using AutoMapper;
using dica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PagedList;

namespace dica.Repositories
{
    public class InvestmentRepository
    {
        const int RecordsPerPage = 10;
        static InvestmentRepository()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<InvestmentViewModel, Investment>();
                cfg.CreateMap<Investment, InvestmentViewModel>();
                }
            );
        }

        public static IPagedList<InvestmentViewModel> GetInvestments(InvestmentSearchViewModel criteria)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = (from investment in db.Investments
                    join sector in db.Statuses on investment.Sector equals sector.Value
                             join investmentPermittedAddress in db.Addresses on investment.InvestmentPermittedAddressId equals investmentPermittedAddress.UID
                             join formofinvestment in db.Statuses on investment.FormofInvestment equals formofinvestment.Value
                             join investingCountry in db.Countries on investment.InvestingCountry equals investingCountry.ISO
                    select new InvestmentViewModel
                    {
                        UID = investment.UID,
                        TypeOfInvestmentValue = investment.TypeOfInvestment,
                        InvestorName = investment.InvestorName,
                        Citizenship = investment.Citizenship,
                        OrganizationName = investment.OrganizationName,
                        IncorporationPlace = investment.IncorporationPlace,
                        BusinessType = investment.BusinessType,
                        InvestmentPermittedAddress = investmentPermittedAddress,
                        AmountofForeignCapital = investment.AmountofForeignCapital,
                        PeriodforForeignCapitalBroughtin = investment.PeriodforForeignCapitalBroughtin,
                        PeriodforForeignCapitalBroughtinType = investment.PeriodforForeignCapitalBroughtinType,
                        TotalAmountofCapital = investment.TotalAmountofCapital,
                        CapitalCurrency = investment.CapitalCurrency,
                        ConstructionPeriod = investment.ConstructionPeriod,
                        ConstructionPeriodType = investment.ConstructionPeriodType,
                        ValidityofInvestmentPermit = investment.ValidityofInvestmentPermit,
                        ValidityofInvestmentPermitPeriodType = investment.ValidityofInvestmentPermitPeriodType,
                        FormofInvestment = formofinvestment.Name,
                        CompanyNameinMyanmar = investment.CompanyNameinMyanmar,
                        PermitNo = investment.PermitNo,
                        PermitDate = investment.PermitDate,
                        Sector = sector.Name,
                        InvestingCountry = investingCountry.Name,

                        SectorValue = sector.Value,
                        InvestingCountryValue = investingCountry.ISO,
                    });
                if (!string.IsNullOrEmpty(criteria.TypeOfInvestment))
                {
                    query = query.Where(i => i.TypeOfInvestment.Equals(criteria.TypeOfInvestment));
                }
                if (!string.IsNullOrEmpty(criteria.Sector))
                {
                    query = query.Where(i => i.SectorValue.Equals(criteria.Sector));
                }
                if (!string.IsNullOrEmpty(criteria.InvestingCountry))
                {
                    query = query.Where(i => i.InvestingCountryValue.Equals(criteria.InvestingCountry));
                }
                if (!string.IsNullOrEmpty(criteria.CompanyNameinMyanmar))
                {
                    query = query.Where(i => i.CompanyNameinMyanmar.Equals(criteria.CompanyNameinMyanmar));
                }
                if (!string.IsNullOrEmpty(criteria.InvestorName))
                {
                    query = query.Where(i => i.InvestorName.Equals(criteria.InvestorName));
                }

                var pageIndex = criteria.Page ?? 1;
                return query.OrderBy(i=> i.CompanyNameinMyanmar).ToPagedList(pageIndex, RecordsPerPage);
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
                                TypeOfInvestment = investment.TypeOfInvestment,
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
                                PeriodforForeignCapitalBroughtinType = investment.PeriodforForeignCapitalBroughtinType,
                                TotalAmountofCapital = investment.TotalAmountofCapital,
                                CapitalCurrency = investment.CapitalCurrency,
                                ConstructionPeriod = investment.ConstructionPeriod,
                                ConstructionPeriodType = investment.ConstructionPeriodType,
                                ValidityofInvestmentPermit = investment.ValidityofInvestmentPermit,
                                ValidityofInvestmentPermitPeriodType = investment.ValidityofInvestmentPermitPeriodType,
                                FormofInvestment = investment.FormofInvestment,
                                CompanyNameinMyanmar = investment.CompanyNameinMyanmar,
                                PermitNo = investment.PermitNo,
                                PermitDate = investment.PermitDate,
                                Sector = investment.Sector,
                                SectorCategory = investment.SectorCategory,
                                InvestingCountry = investment.InvestingCountry,
                                Landowner = investment.Landowner,
                                LandArea = investment.LandArea,
                                LandAreaUnit = investment.LandAreaUnit,
                                LeaseTerm = investment.LeaseTerm,
                                ExtendedLeaseTerm = investment.ExtendedLeaseTerm,
                                AnnualLeaseFee = investment.AnnualLeaseFee,
                                TotalNoofForeignEmployee = investment.TotalNoofForeignEmployee,
                                TotalNoofLocalEmployee = investment.TotalNoofLocalEmployee,
                                CorporateSocialResponsibility = investment.CorporateSocialResponsibility,
                                EnvironmentandSocialImpactAssessmentSelected = investment.EnvironmentandSocialImpactAssessment       

                            }).FirstOrDefault();

                if(!string.IsNullOrEmpty(investmentDto.EnvironmentandSocialImpactAssessmentSelected))
                    investmentDto.EnvironmentandSocialImpactAssessment = investmentDto.EnvironmentandSocialImpactAssessmentSelected.Split(',');

                var jointVenturePercentages = db.JointVenturePercentages.Where(jv => jv.InvestmentId == investmentDto.UID).OrderBy(jv=>jv.Percentage).ToList();
                if (jointVenturePercentages != null && jointVenturePercentages.Count > 0)
                {
                    investmentDto.JointVenturePercentages = new List<JointVenturePercentage>();
                    investmentDto.JointVenturePercentages.AddRange(jointVenturePercentages);
                }

                var taxes = db.Taxes.Where(tax=> tax.InvestmentId == investmentDto.UID).OrderBy(tax=>tax.Amount).ToList();
                if(taxes != null && taxes.Count > 0)
                {
                    investmentDto.Taxes = new List<Tax>();
                    investmentDto.Taxes.AddRange(taxes);
                }

                var capitalDetails = db.CapitalDetails.Where(jv => jv.InvestmentId == investmentDto.UID).ToList();
                if (capitalDetails != null && capitalDetails.Count > 0)
                {
                    investmentDto.CapitalDetails = new List<CapitalDetail>();
                    investmentDto.CapitalDetails.AddRange(capitalDetails);
                }

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
                investment.EnvironmentandSocialImpactAssessment = string.Join(",", investmentViewModel.EnvironmentandSocialImpactAssessment); 

                db.Addresses.Add(investorAddress);
                db.Addresses.Add(organizationAddress);
                db.Addresses.Add(investmentPermittedAddress);
                db.Investments.Add(investment);

                if (investmentViewModel.FormofInvestment.Equals("JV"))
                {
                    if(investmentViewModel.JointVenturePercentages != null && investmentViewModel.JointVenturePercentages.Count > 0)
                    {
                        foreach(JointVenturePercentage jv in investmentViewModel.JointVenturePercentages)
                        {
                            if (!string.IsNullOrEmpty(jv.CompanyName))
                            {
                                jv.UID = Guid.NewGuid();
                                jv.InvestmentId = investment.UID;
                                db.JointVenturePercentages.Add(jv);
                            }
                        }
                    }
                }

                if (investmentViewModel.Taxes != null && investmentViewModel.Taxes.Count > 0)
                {
                    foreach (Tax tax in investmentViewModel.Taxes)
                    {
                        tax.UID = Guid.NewGuid();
                        tax.InvestmentId = investment.UID;
                        db.Taxes.Add(tax);
                    }
                }

                if (investmentViewModel.CapitalDetails != null && investmentViewModel.CapitalDetails.Count > 0)
                {
                    foreach (CapitalDetail cd in investmentViewModel.CapitalDetails)
                    {                        
                        cd.UID = Guid.NewGuid();
                        cd.InvestmentId = investment.UID;
                        db.CapitalDetails.Add(cd);                        
                    }
                }
                db.SaveChanges();
            }
        }

        public static void UpdateInvestment(InvestmentViewModel investmentViewModel, string userName)
        {
            using (var db = new ApplicationDbContext())
            {
                var investment = db.Investments.FirstOrDefault(i => i.UID == investmentViewModel.UID);

                investment.TypeOfInvestment = investmentViewModel.TypeOfInvestment;
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
                investment.PeriodforForeignCapitalBroughtinType = investmentViewModel.PeriodforForeignCapitalBroughtinType;
                investment.TotalAmountofCapital = investmentViewModel.TotalAmountofCapital;
                investment.CapitalCurrency = investmentViewModel.CapitalCurrency;
                investment.ConstructionPeriod = investmentViewModel.ConstructionPeriod;
                investment.ConstructionPeriodType = investmentViewModel.ConstructionPeriodType;
                investment.ValidityofInvestmentPermit = investmentViewModel.ValidityofInvestmentPermit;
                investment.ValidityofInvestmentPermitPeriodType = investmentViewModel.ValidityofInvestmentPermitPeriodType;
                investment.FormofInvestment = investmentViewModel.FormofInvestment;
                investment.CompanyNameinMyanmar = investmentViewModel.CompanyNameinMyanmar;
                investment.PermitNo = investmentViewModel.PermitNo;
                investment.PermitDate = investmentViewModel.PermitDate;
                investment.Sector = investmentViewModel.Sector;
                investment.SectorCategory = investmentViewModel.SectorCategory;
                investment.InvestingCountry = investmentViewModel.InvestingCountry;
                investment.Landowner = investmentViewModel.Landowner;
                investment.LandArea = investmentViewModel.LandArea;
                investment.LandAreaUnit = investmentViewModel.LandAreaUnit;
                investment.LeaseTerm = investmentViewModel.LeaseTerm;
                investment.ExtendedLeaseTerm = investmentViewModel.ExtendedLeaseTerm;
                investment.AnnualLeaseFee = investmentViewModel.AnnualLeaseFee;
                investment.TotalNoofForeignEmployee = investmentViewModel.TotalNoofForeignEmployee;
                investment.TotalNoofLocalEmployee = investmentViewModel.TotalNoofLocalEmployee;
                investment.CorporateSocialResponsibility = investmentViewModel.CorporateSocialResponsibility;
                investment.EnvironmentandSocialImpactAssessment = string.Join(",", investmentViewModel.EnvironmentandSocialImpactAssessment); 
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
                
                db.JointVenturePercentages.RemoveRange(db.JointVenturePercentages.Where(x => x.InvestmentId == investment.UID));
                if (investmentViewModel.FormofInvestment.Equals("JV"))
                {
                    if (investmentViewModel.JointVenturePercentages != null && investmentViewModel.JointVenturePercentages.Count > 0)
                    {
                        foreach (JointVenturePercentage jv in investmentViewModel.JointVenturePercentages)
                        {
                            if (!string.IsNullOrEmpty(jv.CompanyName))
                            {
                                jv.UID = Guid.NewGuid();
                                jv.InvestmentId = investment.UID;
                                db.JointVenturePercentages.Add(jv);
                            }
                        }
                    }
                }

                db.Taxes.RemoveRange(db.Taxes.Where(x => x.InvestmentId == investment.UID));
                if (investmentViewModel.Taxes != null && investmentViewModel.Taxes.Count > 0)
                {
                    foreach (Tax tax in investmentViewModel.Taxes)
                    {
                        tax.UID = Guid.NewGuid();
                        tax.InvestmentId = investment.UID;
                        db.Taxes.Add(tax);
                    }
                }

                db.CapitalDetails.RemoveRange(db.CapitalDetails.Where(x => x.InvestmentId == investment.UID));
                if (investmentViewModel.CapitalDetails != null && investmentViewModel.CapitalDetails.Count > 0)
                {
                    foreach (CapitalDetail cd in investmentViewModel.CapitalDetails)
                    {                        
                        cd.UID = Guid.NewGuid();
                        cd.InvestmentId = investment.UID;
                        db.CapitalDetails.Add(cd);                        
                    }
                }

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