using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _db;

        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _db.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            // save to db
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        [Route("{controller}/{Name}")]
        public async Task<IActionResult> GetCategory(string Name)
        {
            var categories = await _db.Categories.Where(c => c.Name == Name).ToListAsync();
            if (categories.Count != 1)
            {
                return NotFound();
            }
            return View("Category", categories[0]);
        }

        [HttpDelete]
        [Route("{M}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            // delete category
            var category = await _db.Categories.FindAsync(new { id = id });
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            // update category
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
