using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendors.Models;
using System;

namespace Vendors.Tests
{
    public class VendorsTests
    {
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    }
}