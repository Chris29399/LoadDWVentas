using System.ComponentModel.DataAnnotations;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}
