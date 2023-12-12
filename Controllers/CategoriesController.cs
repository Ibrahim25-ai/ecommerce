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
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCategories = await _service.GetAllAsync();
            return View(allCategories);
        }

        //GET: Categories/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");

            return View(CategoryDetails);
        }

        //GET: Categories/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CategoryName,Description")]Category Category)
        {
            if (!ModelState.IsValid) return View(Category);

            await _service.AddAsync(Category);
            return RedirectToAction("Index", "Admin");
        }

        //GET: Categories/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");
            return View(CategoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,Description")] Category Category)
        {
            if (!ModelState.IsValid) return View(Category);

            if(id == Category.Id)
            {
                await _service.UpdateAsync(id, Category);
                return RedirectToAction("Index", "Admin");
            }
            return View(Category);
        }

        //GET: Categories/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");
            return View(CategoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CategoryDetails = await _service.GetByIdAsync(id);
            if (CategoryDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
