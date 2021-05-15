using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _db;

        public OrdersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _db.Orders;
            return View(orders);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            // save to db
            if (ModelState.IsValid)
            {
                await _db.Orders.AddAsync(order);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpGet]
        [Route("{controller}/{id:int}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View("Order", order);
        }

        [HttpDelete]
        [Route("{controller}/{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            // delete products
            var order = await _db.Orders.FindAsync(new { id = id });
            if (order == null)
            {
                return NotFound();
            }
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Order order)
        {
            // update Product
            if (ModelState.IsValid)
            {
                _db.Orders.Update(order);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
