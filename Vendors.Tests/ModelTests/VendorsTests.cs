using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendors.Models;
using System;

namespace Vendors.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetNameAndDescription_ReturnsNameandDescription_NameDescription()
    {
      string name = "Ava's Cafe";
      string vendorDescription = "coffee shop";
      Vendor newVendor = new Vendor(name, vendorDescription);

      string resultName = newVendor.Name;
      string resultDesc = newVendor.VendorDescription;

      Assert.AreEqual(name, resultName);
      Assert.AreEqual(vendorDescription, resultDesc);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      string name = "Test Vendor";
      string vendorDescription = "Test Description";
      Vendor newVendor = new Vendor(name, vendorDescription);
    }

      [TestMethod]
      public void GetAll_ReturnsAllVendorObjects_VendorsList()
      {
        string name = "Ava's Cafe";
        string vendorDescription = "coffee shop";

        string name2 = "Lauretta Jeans";
        string vendorDescription2 = "Pie house";

        Vendor newVendor = new Vendor(name, vendorDescription);
        Vendor newVendor2 = new Vendor(name2, vendorDescription2);
        List<Vendor> newList = new List<Vendor> { newVendor, newVendor2 };

        List<Vendor> result = Vendor.GetAll();

        CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void Find_ReturnsCorrectVendor_Vendor()
      {
        string name = "Ava's Cafe";
        string vendorDescription = "coffee shop";

        string name2 = "Lauretta Jeans";
        string vendorDescription2 = "Pie house";

        Vendor newVendor = new Vendor(name, vendorDescription);
        Vendor newVendor2 = new Vendor(name2, vendorDescription2);

        Vendor result = Vendor.Find(2);

        Assert.AreEqual(newVendor2, result); 
      }

      public void AddOrder_PutsOrderWithVendor_OrderList()
     {
      string orderTitle = "weekly";
      string description = "pastries";
      int price = 50;
      string date = "1/1/2023";

      Order newOrder = new Order(orderTitle, description, price, date); 
      List<Order> newList = new List<Order> { newOrder };

      string name = "Ava's cafe";
      string vendorDescription = "coffee shop";
      Vendor newVendor = new Vendor(name, vendorDescription);
      newVendor.AddOrder(newOrder);

      List<Order> result = newVendor.Orders;

      CollectionAssert.AreEqual(newList, result);
      
     }

    }
  }  