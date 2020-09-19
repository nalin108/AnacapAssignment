using Anacap.Product.API.Models;
using Anacap.Product.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public ActionResult<Products> GetProducts()
        {
            var products = _productService.GetProducts();
            if (products == null)
                return NotFound();

            products.Href = Url.Link(nameof(GetProducts), null);
            return Ok(products);
        }
    }
}
