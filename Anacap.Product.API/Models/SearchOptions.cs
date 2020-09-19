using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Models
{
    public class SearchOptions
    {
        public double? Price { get; set; }
        public double? Rating { get; set; }
        public string Type { get; set; }
    }
}
