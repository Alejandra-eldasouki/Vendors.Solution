using Microsoft.AspNetCore.Mvc;
using Vendors.Models;

namespace Vendors.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/vendors/{id}/orders")]
        public ActionResult VendorOrders(int id)
        {
            Vendor selectedVendor = Vendor.Find(id);
            if (selectedVendor == null)
            {
                return NotFound();
            }

            // Get the orders for the selected vendor
            var vendorOrders = selectedVendor.Orders;

            // Pass the vendor and their orders to the view
            ViewData["Vendor"] = selectedVendor;
            ViewData["Orders"] = vendorOrders;

            return View();
        }
    }
}
