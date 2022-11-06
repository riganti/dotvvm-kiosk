using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Model;
using OrderManagementApp.Database;

namespace OrderManagementApp.Services
{
    public class OrderService
    {
        private readonly AppDbContext dbContext;

        public OrderService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public IQueryable<OrderListDTO> GetOrdersQuery()
        {
            return dbContext.Orders.Select(o => new OrderListDTO()
            {
                Id = o.Id,
                CreatedDate = o.CreatedDate,
                ContactEmail = o.ContactEmail,
                ItemsCount = o.OrderItems.Count(),
                TotalPrice = o.TotalPrice
            });
        }

        public OrderDetailDTO GetOrderDetail(int id)
        {
            var order = dbContext.Orders.Include("OrderItems.Product").Single(o => o.Id == id);
            
            return new OrderDetailDTO()
            {
                Id = order.Id,
                CreatedDate = order.CreatedDate,
                ContactEmail = order.ContactEmail,
                TotalPrice = order.TotalPrice,
                OrderItems = order.OrderItems.Select(i => new OrderItemDetailDTO()
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                })
                .ToList()
            };
        }

        public void SaveOrderDetail(OrderDetailDTO data)
        {
            // get or create order
            var order = dbContext.Orders.Include("OrderItems").SingleOrDefault(o => o.Id == data.Id);
            if (order == null)
            {
                order = new Order()
                {
                    CreatedDate = DateTime.UtcNow
                };
                dbContext.Orders.Add(order);
            }

            // update order items
            order.OrderItems.Clear();
            foreach (var item in data.OrderItems)
            {
                var orderItem = new OrderItem()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                order.OrderItems.Add(orderItem);
            }

            // update order total price
            RecalculateOrderTotalPrice(data);
            order.TotalPrice = data.TotalPrice;

            // update remaining properties
            order.CreatedDate = data.CreatedDate;
            order.ContactEmail = data.ContactEmail;

            dbContext.SaveChanges();
        }

        public void RecalculateOrderTotalPrice(OrderDetailDTO data)
        {
            // load products
            var productIds = data.OrderItems
                .Select(i => i.ProductId)
                .ToList();
            var products = dbContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            // calculate the price
            var totalPrice = 0m;
            foreach (var item in data.OrderItems)
            {
                var product = products.Single(p => p.Id == item.ProductId);
                totalPrice += product.UnitPrice * item.Quantity;
            }
            
            // update the order data
            data.TotalPrice = totalPrice;
        }

    }
}