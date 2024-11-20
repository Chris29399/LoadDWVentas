using LoadDWVentas.Data.Entities.DwVentas;
using LoadDWVentas.Data.Results;

namespace LoadDWVentas.Data.Interfaces
{
    public interface IDataServiceDwVentas
    {
        Task<OperationResult> LoadDimCategory();
        Task<OperationResult> LoadDimEmployee();
        Task<OperationResult> LoadDimProduct();
    }
}
