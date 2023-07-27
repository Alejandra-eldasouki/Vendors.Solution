using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Vendors.Models;

namespace Vendors.Controllers
{
    public class VendorsController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> allVendors = Vendor.GetAll();
            return View(allVendors);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName, string vendorDescription)
        {
            Vendor newVendor = new Vendor(vendorName, vendorDescription);
            return RedirectToAction("Index");
        }

     [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderTitle, string description, int price, string date)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderTitle, description, price, date);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }
        [HttpGet("/vendors/{vendorId}")]
        public ActionResult Show(int vendorId)
        {
            Vendor foundVendor = Vendor.Find(vendorId);
            if (foundVendor == null)
            {
                return NotFound(); // or redirect to a custom error page
            }

            return View(foundVendor);
        }

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult CreateOrder(int vendorId, string orderTitle, string description, int price, string date)
        {
            Vendor foundVendor = Vendor.Find(vendorId);
            if (foundVendor == null)
            {
                return NotFound(); // or redirect to a custom error page
            }

            Order newOrder = new Order(orderTitle, description, price, date);
            foundVendor.AddOrder(newOrder);

            // After creating the order, redirect to the Show action of the Vendor with the vendorId.
            return RedirectToAction("Show", new { vendorId = foundVendor.Id });
        }
    }
}
