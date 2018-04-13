using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.MockingKernel.Moq;
using Moq;
using Ninject.MockingKernel;
using System.Collections.Generic;

namespace SmartShop.Inventory.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ProductManagementServiceTests
    {
        MoqMockingKernel kernel;

        public ProductManagementServiceTests()
        {
            kernel = new MoqMockingKernel();
        }

        [TestMethod]
        public void AddProduct_WhenCategoryExists_SetsCategoryAndSavesInDatabase()
        {
            //Arrange
            string name = "Product 1";
            var productRepositoryMock = kernel.GetMock<IProductRepository>();
            var productCategoryRepositoryMock = kernel.GetMock<IProductCategoryRepository>();
            var productCategory = new ProductCategory() { Name = "Category 1" };
            
            productCategoryRepositoryMock.Setup(x => x.GetByID(It.IsAny<Object>(), It.IsAny<string>())).Returns(productCategory).Verifiable();
            productRepositoryMock.Setup(x => x.Insert(It.Is<Product>(y => y.Name == name && y.ProductCategory.Name == productCategory.Name))).Verifiable();

            kernel.GetMock<IProductManagementUnitOfWork>().Setup(x => x.ProductRepository).Returns(productRepositoryMock.Object);
            kernel.GetMock<IProductManagementUnitOfWork>().Setup(x => x.Save()).Verifiable();
            kernel.GetMock<IProductCategoryManagementUnitOfWork>().Setup(x => x.ProductCategoryRepository).Returns(productCategoryRepositoryMock.Object);
            var service = kernel.Get<ProductManagementService>();

            //Act
            service.AddProduct(name, null, 0, new Guid(), 0, 0, null, false, null, null);

            //Assert
            productRepositoryMock.VerifyAll();
            kernel.GetMock<IProductManagementUnitOfWork>().VerifyAll();
            productCategoryRepositoryMock.VerifyAll();
        }
    }
}
