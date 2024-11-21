using System.ComponentModel.DataAnnotations;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }
        public required string CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}
