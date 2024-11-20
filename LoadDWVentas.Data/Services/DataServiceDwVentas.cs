using LoadDWVentas.Data.Context;
using LoadDWVentas.Data.Entities.DwVentas;
using LoadDWVentas.Data.Interfaces;
using LoadDWVentas.Data.Results;

namespace LoadDWVentas.Data.Services
{
    public class DataServiceDwVentas : IDataServiceDwVentas
    {
        private readonly NorthWindContext _northwindContext;
        private readonly DbSalesContext _dbsalesContext;

        public DataServiceDwVentas(NorthWindContext northwindContext, 
                                   DbSalesContext dbsalesContext) 
        {
            _northwindContext = northwindContext;
            _dbsalesContext = dbsalesContext;
        }
        public async Task<OperationResult> LoadDimCategory()
        {
            OperationResult result = new OperationResult();

            try
            {
                var categories = _northwindContext.Categories.Select(cat => new DimCategory() 
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.CategoryName
                }).ToList();

                await _dbsalesContext.DimCategories.AddRangeAsync(categories);
                await _dbsalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de categoría. {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult> LoadDimEmployee()
        {
            OperationResult result = new OperationResult();

            try
            {
                var employees = _northwindContext.Employees.Select(emp => new DimEmployee()
                {
                    EmployeeId = emp.EmployeeId,
                    EmployeeName = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToList();

                await _dbsalesContext.DimEmployees.AddRangeAsync(employees);
                await _dbsalesContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de empleado. {ex.Message}";
            }

            return result;
        }

        public async Task<OperationResult> LoadDimProduct()
        {
            OperationResult result = new OperationResult();

            try
            {
                var products = (from product in _northwindContext.Products
                             join category in _northwindContext.Categories on product.CategoryId equals category.CategoryId
                             join supplier in _northwindContext.Suppliers on product.SupplierId equals supplier.SupplierId
                             select new DimProduct()
                             {
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 SupplierKey = supplier.SupplierId,
                                 CategoryKey = category.CategoryId,
                             }).ToList();


                await _dbsalesContext.DimProducts.AddRangeAsync();
                await _dbsalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de producto. {ex.Message}";
            }

            return result;
        }
    }
}