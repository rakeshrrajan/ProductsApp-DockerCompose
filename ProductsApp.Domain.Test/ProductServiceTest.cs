using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductsApp.Domain.Modal;
using ProductsApp.Domain.Repository;
using ProductsApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        
        [TestMethod]
        public void Constructor_ThrowsException_WhilePassingNullParams()
        {
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProductService(null));
        }

        [TestMethod]
        public async Task Test_SaveProducts_Success()
        {
            //Arrange
            var mockProductRepo = new Mock<IProductRepository>();
            var sut = new ProductService(mockProductRepo.Object);

            //Act 
            await sut.SaveProductAsync(GetProduct().ToList().First());

            //Assert
            mockProductRepo.Verify(x => x.SaveProductAsync(It.IsAny<Product>()), Times.Exactly(1));
        }

        [TestMethod]
        public async Task Test_GetProducts_Success()
        {
            //Arrange
            var mockProductRepo = new Mock<IProductRepository>();
            var sut = new ProductService(mockProductRepo.Object);
            mockProductRepo.Setup(x => x.GetProductsAsync()).Returns(Task.FromResult(GetProduct()));

            //Act 
            var result =await sut.GetProductsAsync();

            //Assert
            mockProductRepo.Verify(x => x.GetProductsAsync(), Times.Exactly(1));
            Assert.AreEqual(GetProduct().ToList().First().Price, result.ToList().First().Price);
            Assert.AreEqual(GetProduct().ToList().First().Description, result.ToList().First().Description);
            Assert.AreEqual(GetProduct().ToList().First().ProductName, result.ToList().First().ProductName);
        }

        private IEnumerable<Product> GetProduct()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                Description = "Product-1 Description",
                Price = 100,
                ProductName = "Product-1"
            });

            return products;
        }
    }
}
