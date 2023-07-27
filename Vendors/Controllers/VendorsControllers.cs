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

        [HttpPost("/vendor/{vendorId}/orders")]
      public ActionResult Create(int vendorId,string orderTitle,string orderPrice, string orderDescription)
      {
        Dictionary<string,object> model = new Dictionary<string, object> ();
        Vendor foundVend = Vendor.Find(vendorId);
        Order newOrd = new Order(orderTitle,orderPrice,orderDescription);
        foundVend.AddOrder(newOrd);
        List<Order> selectedOrder = foundVend.Orders;
        
        model.Add("order",selectedOrder);
        model.Add("vendor",foundVend);
        return View("Show",model);
      }
        
    }
}
