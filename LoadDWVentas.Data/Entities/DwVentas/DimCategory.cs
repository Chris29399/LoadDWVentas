using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimCategories")]
    public class DimCategory
    {
        public int CategoryKey { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
