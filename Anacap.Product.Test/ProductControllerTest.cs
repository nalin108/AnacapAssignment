using System;
using System.Collections.Generic;
using System.Linq;
using Anacap.Product.API.Controllers;
using Anacap.Product.API.Models;
using Anacap.Product.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Anacap.Product.Test
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void ProductGet_ReturnsProducts()
        {
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.GetProducts(null, null))
                .Returns(getMockProducts());
            var controller = new ProductsController(mockProductService.Object);

            var result = controller.GetProducts(null, null);
            Assert.Equals(1, result.Value.Value.Count());
        }

        Products getMockProducts()
        {
            return new Products()
            {
                Value = new List<ProductInfo>()
                {
                    new ProductInfo(){ Name = "Test"}
                }
            };
        }
    }
}
