using EStore.Data;
using EStore.Data.Services;
using EStore.Data.Static;
using EStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _service;

        public CompaniesController(ICompaniesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCompanies = await _service.GetAllAsync();
            return View(allCompanies);
        }

        //GET: Companies/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var CompanyDetails = await _service.GetByIdAsync(id);
            if (CompanyDetails == null) return View("NotFound");

            return View(CompanyDetails);
        }

        //GET: Companies/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CompanyName,CompanyLogoURL,CompanyURL,Description")]Company Company)
        {
            if (!ModelState.IsValid) {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        // Log or inspect the error message
                        System.Diagnostics.Debug.WriteLine($"{state.Key} - {error.ErrorMessage}");
                        System.Diagnostics.Debug.WriteLine($"teeeeeeeeeeeeeeeest");

                    }
                }
                return View(Company); }

            await _service.AddAsync(Company);
            return RedirectToAction("Index", "Admin");
        }

        //GET: Companies/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var CompanyDetails = await _service.GetByIdAsync(id);
            if (CompanyDetails == null) return View("NotFound");
            return View(CompanyDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,CompanyLogoURL,CompanyURL,Description")] Company Company)
        {
            if (!ModelState.IsValid) return View(Company);

            if(id == Company.Id)
            {
                await _service.UpdateAsync(id, Company);
                return RedirectToAction("Index", "Admin");
            }
            return View(Company);
        }

        //GET: Companies/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var CompanyDetails = await _service.GetByIdAsync(id);
            if (CompanyDetails == null) return View("NotFound");
            return View(CompanyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CompanyDetails = await _service.GetByIdAsync(id);
            if (CompanyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
