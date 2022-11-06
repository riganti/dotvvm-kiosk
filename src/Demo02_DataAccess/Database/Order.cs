using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementApp.Database
{
    public class Order
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string ContactEmail { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}