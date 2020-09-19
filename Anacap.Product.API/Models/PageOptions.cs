using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Models
{
    public class PageOptions
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? Top { get; set; }
    }
}
