using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendors.Models;
using System;

namespace Vendors.Tests 
{
    [TestClass]
    public class OrderTests : IDisposable
    {
      
      public void Dispose()
      {
        Order.ClearAll();
      }

      [TestMethod]
      public void OrderConstructor_CreatesInstancOfOrder_Order()
      {
        Order addOrder = new Order("weekly", "ciabatta", 50, "5/7/2022");
        Assert.AreEqual(typeof(Order), addOrder.GetType());
      }
    }
}