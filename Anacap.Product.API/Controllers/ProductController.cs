using Anacap.Product.API.Models;
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
        readonly Products _products;
        public ProductsController(Products products)
        {
            _products = products;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public ActionResult<Products> GetProducts()
        {
            if (_products == null)
                return NotFound();

            _products.Href = Url.Link(nameof(GetProducts), null);
            return Ok(_products);
        }
    }
}
