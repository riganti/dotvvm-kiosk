namespace OrderManagementApp.Model
{
    public class ProductListDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public string DisplayText => $"{Name} ({UnitPrice:c})";

    }
}