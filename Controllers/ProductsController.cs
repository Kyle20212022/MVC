using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using MVC.Models;

namespace CoreMVCVUE.Controllers
{
    [Route("/{controller}")]
    public class ProductsController : Controller
    {
        private readonly DataDBContext _context;

        public ProductsController(DataDBContext context)
        {
            _context = context;
        }

        
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> List()
        {
            return Json(await _context.Products.ToListAsync());
        }

        
        public async Task<JsonResult> Create(product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Json("新增成功!");
        }       

        public async Task<JsonResult> Edit(product)
        {            
            _context.Update(product);
            await _context.SaveChangesAsync();
            return Json("修改成功!");
        }
                
        
        public async Task<JsonResult> Delete(string id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Json("刪除成功!");
        }

       
    }
}
