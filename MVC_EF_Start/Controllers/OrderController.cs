using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF_Start.Controllers
{
    public class OrderController : Controller
    {
        public ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            Order ExampleOrder0 = new Order { OrderStatus = "Open", PaymentMode = "Credit Card" };
            Order ExampleOrder1 = new Order { OrderStatus = "Closed", PaymentMode = "Debit Card" };
            Order ExampleOrder2 = new Order { OrderStatus = "Open", PaymentMode = "Apple Pay" };

            Product Product0 = new Product
            {
                ProductName = "Apple",
                ProductDescription = "Fruit",
                ProductPrice = 3,
                ProductQuantity = 8,
                MyOrders = ExampleOrder0
            };

            Product Product1 = new Product
            {
                ProductName = "Onion",
                ProductDescription = "Vegetable",
                ProductPrice = 1,
                ProductQuantity = 12,
                MyOrders = ExampleOrder1
            };
            Product Product2 = new Product
            {
                ProductName = "Tomato",
                ProductDescription = "Vegetable",
                ProductPrice = 1,
                ProductQuantity = 20,
                MyOrders = ExampleOrder1
            };

            Product Product3 = new Product
            {
                ProductName = "Apple",
                ProductDescription = "Fruit",
                ProductPrice = 3,
                ProductQuantity = 10,
                MyOrders = ExampleOrder2
            };
            Product Product4 = new Product
            {
                ProductName = "Carrots",
                ProductDescription = "Vegetable",
                ProductPrice = 2,
                ProductQuantity = 5,
                MyOrders = ExampleOrder2
            };

            OrderDetail OrderDetailsSample0 = new OrderDetail
            {
                OrderNumber = ExampleOrder0,
                ProductNumber = Product0,
                PlacedDate = new DateTime(2021, 02, 25, 10, 30, 50)
            };

            OrderDetail OrderDetailsSample1 = new OrderDetail
            {
                OrderNumber = ExampleOrder1,
                ProductNumber = Product1,
                PlacedDate = new DateTime(2021, 03, 15, 08, 24, 11)
            };
            OrderDetail OrderDetailsSample2 = new OrderDetail
            {
                OrderNumber = ExampleOrder1,
                ProductNumber = Product2,
                PlacedDate = new DateTime(2021, 03, 29, 17, 05, 59)
            };

            OrderDetail OrderDetailsSample3 = new OrderDetail
            {
                OrderNumber = ExampleOrder2,
                ProductNumber = Product3,
                PlacedDate = new DateTime(2021, 04, 03, 15, 53, 21)
            };
            OrderDetail OrderDetailsSample4 = new OrderDetail
            {
                OrderNumber = ExampleOrder2,
                ProductNumber = Product4,
                PlacedDate = DateTime.Now
            };

            dbContext.Orders.Add(ExampleOrder0);
            dbContext.Orders.Add(ExampleOrder1);
            dbContext.Orders.Add(ExampleOrder2);
            dbContext.Products.Add(Product0);
            dbContext.Products.Add(Product1);
            dbContext.Products.Add(Product2);
            dbContext.Products.Add(Product3);
            dbContext.Products.Add(Product4);
            dbContext.OrderProductDetails.Add(OrderDetailsSample0);
            dbContext.OrderProductDetails.Add(OrderDetailsSample1);
            dbContext.OrderProductDetails.Add(OrderDetailsSample2);
            dbContext.OrderProductDetails.Add(OrderDetailsSample3);
            dbContext.OrderProductDetails.Add(OrderDetailsSample4);

            /*
            // Read Operation

            Product ReadProduct = dbContext.Products
                                        .Where(p => p.ProductName == "Carrots")
                                        .FirstOrDefault();

            Product ReadProduct2 = dbContext.Products
                                        .Where(p => p.ProductName == "Tomato")
                                        .FirstOrDefault();

            Order ReadOrder = dbContext.Orders
                                        .Include(o => o.Items)
                                        .FirstOrDefault();

            // Update Operation

            ReadProduct.ProductName = "Beans";
            dbContext.Products.Update(ReadProduct);

            // Delete Operation

            dbContext.Products.Remove(ReadProduct2);
            */

            dbContext.SaveChanges();
            return View();
        }

        public ViewResult LINQOperations()
        {
            // Third Question

            // Part One

            Product ReqProductName = dbContext.Products
                                            .Where(p => p.ProductName == "Apple")
                                            .First();

            List<OrderDetail> ReadOrders = dbContext.OrderProductDetails
                                            .Where(o => o.ProductNumber == ReqProductName)
                                            .ToList();

            return View(ReadOrders);

        }


        // Part Two

        public ViewResult CourseDetails()
        {

            Product ReqProductName2 = dbContext.Products
                                            .Where(p => p.ProductName == "Apple")
                                            .Max();

            return View(ReqProductName2);
        }
    }
}