using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMode { get; set; }
        public List<Product> Items { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public Order MyOrders { get; set; }
        public List<OrderDetail> ProductOrders { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }
        public Order OrderNumber { get; set; }
        public Product ProductNumber { get; set; }
        public DateTime PlacedDate { get; set; }
    }
}