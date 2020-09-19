using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anacap.Product.API.Models;

namespace Anacap.Product.API.Services
{
    public class ProductService : IProductService
    {
        readonly Products _products;
        public ProductService(Products products)
        {
            _products = products;
        }
        public Products GetProducts(PageOptions pageOptions, SearchOptions searchOptions)
        {
            _products.Value= FilterProducts.Apply(_products.Value, pageOptions, searchOptions);
            return _products;
        }
    }
}
