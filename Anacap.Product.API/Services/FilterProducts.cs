using Anacap.Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Services
{
    public class FilterProducts
    {
        public static IEnumerable<ProductInfo> Apply(IEnumerable<ProductInfo> products, PageOptions pageOptions, SearchOptions searchOptions)
        {
            if (searchOptions != null)
            {
                if (searchOptions.Price.HasValue)
                    products = products.Where(x => x.Price == searchOptions.Price.Value);
                if (searchOptions.Rating.HasValue)
                    products = products.Where(x => x.Rating == searchOptions.Rating.Value);
                if (!string.IsNullOrEmpty(searchOptions.Type))
                    products = products.Where(x => x.Type == searchOptions.Type);
            }

            if (pageOptions != null
                && pageOptions.Top.HasValue
                && pageOptions.Page.HasValue
                && pageOptions.PageSize.HasValue
                && pageOptions.Top.Value <= pageOptions.PageSize.Value
               )
            {
                products = products.Skip((pageOptions.Page.Value-1) * pageOptions.PageSize.Value)
                                   .Take(pageOptions.Top.Value);
            }

            return products;
        }
    }
}
