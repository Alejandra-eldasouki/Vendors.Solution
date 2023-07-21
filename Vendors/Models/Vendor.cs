using System.Collections.Generic;

namespace Vendors.Models 
{
    public class Vendor
    {
     private static List<Vendor> _instance = new List<Vendor> {};
     public string Name { get; set; }
     public string VendorDescription { get; set; }
     public int Id { get; set; }

     public List<Order> Orders { get; set; }

     public Vendor(string name, string vendorDescription)
     {
        Name = name;
        VendorDescription = vendorDescription;
        _instance.Add(this);
        Id = _instance.Count;
        Orders = new List<Order>{};
     }
    }
}