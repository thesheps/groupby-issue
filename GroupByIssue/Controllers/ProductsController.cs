using GroupByIssue.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GroupByIssue.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Products);
        }
    }
}
