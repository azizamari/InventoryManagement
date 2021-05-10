using AutoMapper;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    public class ProductsController: Controller
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _db.Products;
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto product)
        {
            // save to db
            if (ModelState.IsValid)
            {
                var productToSave = _mapper.Map<Product>(product);
                await _db.Products.AddAsync(productToSave);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        [Route("{controller}/{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Brand", product);
        }

        [HttpDelete]
        [Route("{controller}/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // delete products
            var product = await _db.Products.FindAsync(new { id = id });
            if (product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            // update Product
            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
