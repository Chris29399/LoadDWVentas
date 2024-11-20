using System.ComponentModel.DataAnnotations;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    public class DimShipper
    {
        [Key]
        public int ShipperKey { get; set; }
        public int ShipperId {  get; set; }
        public string? ShipperName {  get; set; }
    }
}
