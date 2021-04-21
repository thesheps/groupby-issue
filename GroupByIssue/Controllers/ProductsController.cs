using GroupByIssue.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GroupByIssue.Controllers
{
    public class ProductsController : ODataController
    {
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(Products.All);
        }
    }
}
