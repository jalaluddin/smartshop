using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.MockingKernel.Moq;
using Moq;
using Ninject.MockingKernel;

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
            //kernel.GetMock<IProductManagementUnitOfWork>().Setup(x => x.ProductRepository).Returns();
            var service = kernel.Get<ProductManagementService>();

            //Act

            //Assert
        }
    }
}
