using Microsoft.AspNetCore.Mvc;
using Vendors.Models;
using System.Collections.Generic;

namespace Vendors.Controllers
{
    public class OrdersController : Controller
    {
        // Other actions in the OrdersController...

        [HttpGet("/vendors/{vendorId}/orders/new")]
        public ActionResult New(int vendorId)
        {
            Vendor vendor = Vendor.Find(vendorId);
            return View(vendor);
        }

        [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
        public ActionResult Show(int vendorId, int orderId)
        {
            Order order = Order.Find(orderId);
            Vendor vendor = Vendor.Find(vendorId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("order", order);
            model.Add("vendor", vendor);
            return View(model);
        }


[HttpPost("/vendors/{vendorId}/orders")]
public ActionResult CreateOrder(int vendorId, string orderTitle, string description, int price, string date)
{

    Vendor vendor = Vendor.Find(vendorId);
    if (vendor == null)
    {
        return NotFound();
    }

    // Convert the 'price' parameter to an int if needed (assuming the Order model uses int for Price)
    int convertedPrice = (int)price;

    Order newOrder = new Order(orderTitle, description, convertedPrice, date);

    // Add the new order to the vendor's list of orders
    vendor.AddOrder(newOrder);

    // Redirect to the vendor's details page after creating the order
    return RedirectToAction("Show", "Vendors", new { id = vendorId });
}
    }
}
