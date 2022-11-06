using System.ComponentModel.DataAnnotations;

namespace OrderManagementApp.Model
{
    public class OrderItemDetailDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The quantity is required!")]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}