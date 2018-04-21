using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidotti.Domain.Entities;

namespace Vidotti.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        // private readonly Customer _customer = new Customer("Gustavo", "Vidotti", null, "gustavo.vidotti@gmail.com", new User("gustavovidotti", "gustavovidotti"));

        // [TestMethod]
        // [TestCategory("Order - New Order")]
        // public void GivenAnOutOfStockProductItShouldReturnAnError()
        // {
        //     var mouse = new Product("Mouse", 299, "mouse.jpg", 0);

        //     var order = new Order(_customer, 8, 10);
        //     order.AddItem(new OrderItem(mouse, 2));

        //     Assert.IsFalse(order.IsValid);
        // }

        // [TestMethod]
        // [TestCategory("Order - New Order")]
        // public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        // {
        //     var mouse = new Product("Mouse", 299, "mouse.jpg", 20);

        //     var order = new Order(_customer, 8, 10);
        //     order.AddItem(new OrderItem(mouse, 2));

        //     Assert.IsTrue(mouse.QuantityOnHand == 18);
        // }

        // [TestMethod]
        // [TestCategory("Order - New Order")]
        // public void GivenAValidOrderTheTotalShouldBe310()
        // {
        //     var mouse = new Product("Mouse", 300, "mouse.jpg", 20);

        //     var order = new Order(_customer, 12, 2);
        //     order.AddItem(new OrderItem(mouse, 1));

        //     Assert.IsTrue(order.Total() == 310);
        // }
    }
}