using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Models
{
    public class Product: Resource
    {
        public string Name { get; set; }
        public string Imagee { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public int Users { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
