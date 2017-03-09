﻿using AutoMapper;
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
                var query = (from investment in db.Investments
                    join sector in db.Statuses on investment.Sector equals sector.Value
                             join investmentPermittedAddress in db.Addresses on investment.InvestmentPermittedAddressId equals investmentPermittedAddress.UID
                             join formofinvestment in db.Statuses on investment.FormofInvestment equals formofinvestment.Value
                             join investingCountry in db.Countries on investment.InvestingCountry equals investingCountry.ISO
                             where sector.Group == "Sector"
                    select new InvestmentViewModel
                    {
                        UID = investment.UID,
                        InvestorName = investment.InvestorName,
                        Citizenship = investment.Citizenship,
                        OrganizationName = investment.OrganizationName,
                        IncorporationPlace = investment.IncorporationPlace,
                        BusinessType = investment.BusinessType,
                        InvestmentPermittedAddress = investmentPermittedAddress,
                        AmountofForeignCapital = investment.AmountofForeignCapital,
                        PeriodforForeignCapitalBroughtin = investment.PeriodforForeignCapitalBroughtin,
                        TotalAmountofCapital = investment.TotalAmountofCapital,
                        CapitalCurrency = investment.CapitalCurrency,
                        ConstructionPeriod = investment.ConstructionPeriod,
                        ValidityofInvestmentPermit = investment.ValidityofInvestmentPermit,
                        FormofInvestment = formofinvestment.Name,
                        CompanyNameinMyanmar = investment.CompanyNameinMyanmar,
                        PermitNo = investment.PermitNo,
                        PermitDate = investment.PermitDate,
                        Sector = sector.Name,
                        InvestingCountry = investingCountry.Name
                    });

                var investmentViewModels = query.ToList();
                
                return investmentViewModels;
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
                                TotalAmountofCapital = investment.TotalAmountofCapital,
                                CapitalCurrency = investment.CapitalCurrency,
                                ConstructionPeriod = investment.ConstructionPeriod,
                                ValidityofInvestmentPermit = investment.ValidityofInvestmentPermit,
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
                                TotalNoofLocalEmployee = investment.TotalNoofLocalEmployee        

                            }).FirstOrDefault();

                var jointVenturePercentages = db.JointVenturePercentages.Where(jv => jv.InvestmentId == investmentDto.UID).OrderBy(jv=>jv.Percentage).ToList();
                if (jointVenturePercentages != null && jointVenturePercentages.Count > 0)
                {
                    investmentDto.JointVenturePercentages = new List<JointVenturePercentage>();
                    investmentDto.JointVenturePercentages.AddRange(jointVenturePercentages);
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
                investment.TotalAmountofCapital = investmentViewModel.TotalAmountofCapital;
                investment.CapitalCurrency = investment.CapitalCurrency;
                investment.ConstructionPeriod = investmentViewModel.ConstructionPeriod;
                investment.ValidityofInvestmentPermit = investmentViewModel.ValidityofInvestmentPermit;
                investment.FormofInvestment = investmentViewModel.FormofInvestment;
                investment.CompanyNameinMyanmar = investmentViewModel.CompanyNameinMyanmar;
                investment.PermitNo = investmentViewModel.PermitNo;
                investment.PermitDate = investmentViewModel.PermitDate;
                investment.Sector = investmentViewModel.Sector;
                investment.SectorCategory = investmentViewModel.SectorCategory;
                investment.InvestingCountry = investment.InvestingCountry;
                investment.Landowner = investment.Landowner;
                investment.LandArea = investment.LandArea;
                investment.LandAreaUnit = investment.LandAreaUnit;
                investment.LeaseTerm = investment.LeaseTerm;
                investment.ExtendedLeaseTerm = investment.ExtendedLeaseTerm;
                investment.AnnualLeaseFee = investment.AnnualLeaseFee;
                investment.TotalNoofForeignEmployee = investment.TotalNoofForeignEmployee;
                investment.TotalNoofLocalEmployee = investment.TotalNoofLocalEmployee;
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