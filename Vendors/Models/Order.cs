using System.Collections.Generic;
using System;

namespace Vendors.Models
{

    public class Order
    {
     public string OrderTitle { get; set; }
     public string Description { get; set; }
     public int Price { get; set; }
     public string Date { get; set; }
     public int Id { get; set; }

     private static List<Order> _instances = new List<Order> {};
        private string orderPrice;
        private string orderDescription;

        public Order(string orderTitle, string description, int price, string date)
    {
        OrderTitle = orderTitle;
        Description = description;
        Price = price;
        Date = date;
        _instances.Add(this);
        Id = _instances.Count;
    }

       public Order(string orderTitle, string orderPrice, string orderDescription)
{
    OrderTitle = orderTitle;
    this.orderPrice = orderPrice;
    this.orderDescription = orderDescription;
    _instances.Add(this); 
}

        public static List<Order> GetAll()
  {
    return _instances;
  }

  public static void ClearAll()
  {
    _instances.Clear();
  }

  public static Order Find(int searchId)
  {
    return _instances[searchId-1];
  }

  }
    }
