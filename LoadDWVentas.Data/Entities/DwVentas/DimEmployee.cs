using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimCategories")]
    public class DimEmployee
    {
        public int EmployeeId { get; set; }

        public int EmployeeKey { get; set; }

        public int EmployeeName { get; set; }
    }
}
