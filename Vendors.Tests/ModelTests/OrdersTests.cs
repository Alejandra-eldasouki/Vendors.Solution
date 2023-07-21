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
        Order addOrder = new Order("weekly", "ciabatta", 50, "1/1/2023");
        Assert.AreEqual(typeof(Order), addOrder.GetType());
      }

      [TestMethod]
      public void GetOrder_ReturnsInstanceOfAnOrder_Order()
      {
        string orderTitle = "weekly";
        string description = "ciabatta";
        int price = 50;
        string date = "1/1/2023";

        Order newOrder = new Order(orderTitle, description, price, date);
        string resultTitle = newOrder.OrderTitle;
        string resultDescription = newOrder.Description;
        int resultPrice = newOrder.Price;
        string resultDate = newOrder.Date;

        Assert.AreEqual(orderTitle, resultTitle);
        Assert.AreEqual(description, resultDescription);
        Assert.AreEqual(price, resultPrice);
        Assert.AreEqual(date, resultDate);
      }

      [TestMethod]
      public void SetOrder_SetOrder_Order() 
      {
        string orderTitle = "daily";
        string description = "pastries";
        int price = 25;
        string date = "1/1/2023";

        Order newOrder = new Order(orderTitle, description, price, date);
        string resultTitleNew = newOrder.OrderTitle;
        string resultDescriptionNew = newOrder.Description;
        int resultPriceNew = newOrder.Price;
        string resultDateNew = newOrder.Date;

        Assert.AreEqual(orderTitle, resultTitleNew);
        Assert.AreEqual(description, resultDescriptionNew);
        Assert.AreEqual(price, resultPriceNew);
        Assert.AreEqual(date, resultDateNew);
      }

      [TestMethod]
      public void GetAll_ReturnsEmptyList_ItemList()
      {
        List<Order> newList = new List<Order> {};
        List<Order> result = Order.GetAll();
        CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void GetAll_ReturnsOrders_OrderList()
      {
        string orderTitle = "weekly";
        string description = "ciabatta";
        int price = 50;
        string date = "1/1/2023";

        string orderTitle2 = "daily";
        string description2 = "pastries";
        int price2 = 25;
        string date2 = "1/2/2023";

        Order newOrder = new Order(orderTitle, description, price, date);
        Order newOrder1 = new Order(orderTitle2, description2, price2, date2);
        List<Order> newList = new List<Order> {newOrder, newOrder1};

        List<Order> result = Order.GetAll();
        CollectionAssert.AreEqual(newList, result);
      }
    }
}