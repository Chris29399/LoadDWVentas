using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimEmployees")]
    public class DimEmployee
    {
        public int EmployeeId { get; set; }

        public int EmployeeKey { get; set; }

        public string? EmployeeName { get; set; }
    }
}
