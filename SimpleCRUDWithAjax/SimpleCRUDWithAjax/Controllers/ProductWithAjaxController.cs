using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUDWithAjax.EF;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleCRUDWithAjax.Controllers
{
    public class ProductWithAjaxController : Controller
    {
        private readonly SimpleCrudwithAjaxContext _context;

        public ProductWithAjaxController(SimpleCrudwithAjaxContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Products
        public async Task<JsonResult> GetProduct()
        {
            return Json(await _context.Products.ToListAsync());
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Product product, [FromForm] IFormFile Image)
        {
            if (Image == null || Image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            product.FilePath = await _ProcessFile(Image);

            _context.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "File uploaded successfully!", result = "OK" });
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> GetProductById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Json(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [FromForm] Product product, [FromForm] IFormFile Image)
        {
            if (Id != product.Id)
            {
                return NotFound();
            }

            if (Image != null && Image.Length != 0)
            {
                product.FilePath = await _ProcessFile(Image);
            }

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { message = "File updated successfully!", result = "OK" });
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return  Ok(new { message = "File deleted successfully!", result = "OK" });
        }

        private async Task<string> _ProcessFile(IFormFile Image)
        {
            string mainPath = "uploads";
            string staticPath = "wwwroot";

            var extention = Image.FileName.Split('.').Last();
            string fileName = Image.FileName.Split('.').First();

            string newFileName = fileName + DateTime.Now.ToString("ddmmyyyyhhmmff") + "." + extention;

            var filePath = Path.Combine(staticPath, mainPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }

            string filePathResult = Path.Combine(mainPath, newFileName);
            return filePathResult;
        }
    }
}