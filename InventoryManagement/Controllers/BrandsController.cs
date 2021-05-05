using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    public class BrandsController : Controller
    {
        private readonly AppDbContext _db;

        public BrandsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var brands = _db.Brands;
            return View(brands);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Brand brand)
        {
            // save to db
            if (ModelState.IsValid)
            {
                await _db.Brands.AddAsync(brand);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        [HttpGet]
        [Route("{controller}/{id:int}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _db.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View("Brand", brand);
        }

        //[HttpDelete]
        //[Route("{M}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    // delete category
        //    var category = await _db.Categories.FindAsync(new { id = id });
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Categories.Remove(category);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPatch]
        //[Route("{id:int}")]
        //public async Task<IActionResult> UpdateCategory(int id, Category category)
        //{
        //    // update category
        //    if (ModelState.IsValid)
        //    {
        //        _db.Categories.Update(category);
        //        await _db.SaveChangesAsync();
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
