using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartShop.Inventory.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void ClearCart_WhenExecuted_ClearsAllItem()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.AddItem(new CartItem(new Product()));
            cart.AddItem(new CartItem(new Product()));

            //Act
            cart.ClearCart();

            //Assert
            Assert.AreEqual(0, cart.CartItems.Count);
        }

        [TestMethod]
        public void DecreaseQuantityOfItem_IfProductWithIdExists_DrecreasesQuantityByOne()
        {
            //Arrange
            var productId = new Guid();
            var cart = new ShoppingCart();
            cart.AddItem(new CartItem(new Product() { ID = productId }, 5));
            cart.AddItem(new CartItem(new Product()));

            //Act
            cart.DecreaseQuantityOfItem(productId);

            //Assert
            Assert.AreEqual(4, cart.CartItems.Find(x => x.Product.ID == productId).Quantity);
        }

        [TestCategory("New Test"), TestMethod]
        public void TotalAmount_NoItem_TotalsZero()
        {
            //Arrange
            var expectedTotal = 0;
            var cart = new ShoppingCart();

            //Act
            var actualTotal = cart.TotalAmount;

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void IncreaseQuantityOfItem_IfProductWithIdExists_IncreasesQuantityByOne()
        {
            //Arrange
            var productId = new Guid();
            var cart = new ShoppingCart();
            cart.AddItem(new CartItem(new Product() { ID = productId }, 5));
            cart.AddItem(new CartItem(new Product()));

            //Act
            cart.IncreaseQuantityOfItem(productId);

            //Assert
            Assert.AreEqual(6, cart.CartItems.Find(x => x.Product.ID == productId).Quantity);
        }
    }
}
