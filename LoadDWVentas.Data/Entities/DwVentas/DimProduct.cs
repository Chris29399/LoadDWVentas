using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimProducts")]
    public class DimProduct
    {
        [Key]
        public int ProductKey { get; set; }

        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int CategoryKey { get; set; }
    }
}
