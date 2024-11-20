using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimCategories")]
    public class DimCategory
    {
        [Key]
        public int CategoryKey { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
