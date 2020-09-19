using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ProductsController: ControllerBase
    {
        [HttpGet(Name = nameof(GetProducts))]
        public IActionResult GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
