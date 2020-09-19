using Anacap.Product.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anacap.Product.API.Services
{
    public interface IProductService
    {
        Products GetProducts();
    }
}
