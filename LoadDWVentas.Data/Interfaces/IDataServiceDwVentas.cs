using LoadDWVentas.Data.Results;

namespace LoadDWVentas.Data.Interfaces
{
    public interface IDataServiceDwVentas
    {
        Task<OperationResult> LoadDWH();
    }
}