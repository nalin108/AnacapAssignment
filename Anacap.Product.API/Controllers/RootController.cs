using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController: ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response =  new
            {
                href = Url.Link(nameof(GetRoot), null),
                products = Url.Link(nameof(ProductsController.GetProducts), null)
            };

            return Ok(response);
        }
    }
}
