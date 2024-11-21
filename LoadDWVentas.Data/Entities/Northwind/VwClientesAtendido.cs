using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Entities.Northwind
{
    public class VwClientesAtendido
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public int? Clientes { get; set; }
    }
}
