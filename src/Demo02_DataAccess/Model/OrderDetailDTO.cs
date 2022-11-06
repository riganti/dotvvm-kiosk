using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementApp.Model
{
    public class OrderDetailDTO : IValidatableObject
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "The E-mail Address field is required!")]
        [EmailAddress(ErrorMessage = "The E-mail Address format is not valid!")]
        public string ContactEmail { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItemDetailDTO> OrderItems { get; set; } 


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderItems.Count == 0)
            {
                yield return new ValidationResult("The order must contain at least one item!", new [] { nameof(OrderItems) });
            }
        }
    }
}