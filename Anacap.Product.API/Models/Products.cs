using System;
using System.Collections.Generic;

namespace Anacap.Product.API.Models
{
    public class Products : Resource
    {
        public IEnumerable<ProductInfo> Value { get; set; }
    }

    public class ProductInfo
    {
        public string Name { get; set; }
        public string Imagee { get; set; }
        public string Type { get; set; }
        public double? Rating { get; set; }
        public double? Price { get; set; }
        public int? Users { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

}
