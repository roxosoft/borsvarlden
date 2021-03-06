﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using borsvarlden.Models;

namespace borsvarlden.Controllers
{
    using ViewModels;
    public class CompaniesController : Controller
    {
        private IFinwireCompaniesService _finwireCompaniesService;
        private IFinwireNewsService _finwireNewsService;

        public CompaniesController(IFinwireCompaniesService finwireCompaniesService, IFinwireNewsService finwireNewsService)
        {
            _finwireCompaniesService = finwireCompaniesService;
            _finwireNewsService = finwireNewsService;
        }

        [Route("CompaniesList/{letter}")]
        [Route("Foretag/{letter}")]
        public async Task<IActionResult> CompaniesList(string letter)
            => View(new CompaniesListViewModel
            {
                CompaniesList = await _finwireCompaniesService.GetListCompaniesByLetter(letter),
                CompanyInFocus = await _finwireCompaniesService.GetCompanyInFocus(),
                Letter = letter
            });
     

        [Route("Foretagsinfo/id/{id}")]
        public async Task<IActionResult> CompanyInfo(int id)
        {
            var company = await _finwireCompaniesService.GetFinwireCompany(id);
            var res = await _finwireNewsService.GetFinwireNewWithCompany(id);
            return View(new Tuple<FinwireCompany, List<FinwireNew>>(company, res));
        }

        [Route("Foretagsinfo/{slug}")]
        public async Task<IActionResult> CompanyInfo(string slug)
        {
            var company = await _finwireCompaniesService.GetFinwireCompany(slug);
            var res = await _finwireNewsService.GetFinwireNewWithCompany(company.Id);
            return View(new Tuple<FinwireCompany, List<FinwireNew>>(company, res));
        }
    }
}