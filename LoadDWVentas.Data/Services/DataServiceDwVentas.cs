﻿using LoadDWVentas.Data.Context;
using LoadDWVentas.Data.Entities.DwVentas;
using LoadDWVentas.Data.Interfaces;
using LoadDWVentas.Data.Results;
using Microsoft.EntityFrameworkCore;

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
        public async Task<OperationResult> LoadDWH()
        {
            OperationResult result = new OperationResult();
            try
            {
                //await LoadDimCategory();
                //await LoadDimCustomer();
                //await LoadDimEmployee();
                //await LoadDimProduct();
                //await LoadDimShipper();
                //await LoadFactSales();
                await LoadFactClients();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando el DW Ventas {ex.Message}";
            }
            return result;
        }
        private async Task<OperationResult> LoadDimCategory()
        {
            OperationResult result = new OperationResult();

            try
            {
                var categories = _northwindContext.Categories.AsNoTracking().Select(cat => new DimCategory() 
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

        private async Task<OperationResult> LoadDimCustomer()
        {
            OperationResult result = new OperationResult();

            try
            {
                var customers = _northwindContext.Customers.AsNoTracking().Select(cus => new DimCustomer()
                {
                    CustomerId = cus.CustomerId,
                    CustomerName = cus.CompanyName
                }).ToList();

                await _dbsalesContext.DimCustomers.AddRangeAsync(customers);
                await _dbsalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de categoría. {ex.Message}";
            }

            return result;
        }
        private async Task<OperationResult> LoadDimEmployee()
        {
            OperationResult result = new OperationResult();

            try
            {
                var employees = _northwindContext.Employees.AsNoTracking().Select(emp => new DimEmployee()
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

        private async Task<OperationResult> LoadDimProduct()
        {
            OperationResult result = new OperationResult();

            try
            {
                var products = (from product in _northwindContext.Products
                             join category in _northwindContext.Categories 
                                on product.CategoryId equals category.CategoryId
                             select new DimProduct()
                             {
                                 CategoryKey = category.CategoryId,
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName
                             }).AsNoTracking().ToList();


                await _dbsalesContext.DimProducts.AddRangeAsync(products);
                await _dbsalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de producto. {ex.Message}";
            }

            return result;
        }

        private async Task<OperationResult> LoadDimShipper()
        {
            OperationResult result = new OperationResult();

            try
            {
                var shippers = _northwindContext.Shippers.AsNoTracking().Select(sh => new DimShipper()
                {
                    ShipperId = sh.ShipperId,
                    ShipperName = sh.CompanyName
                }).ToList();

                await _dbsalesContext.DimShippers.AddRangeAsync(shippers);
                await _dbsalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la dimensión de empleado. {ex.Message}";
            }

            return result;
        }

        private async Task<OperationResult> LoadFactSales()
        {
            OperationResult result = new OperationResult();

            try
            {
                var ventas = await _northwindContext.VwVentas.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            { 
                result.Success = false;
                result.Message = $"Error cargando Fact de Ventas. {ex.Message} ";
            }

            return result;
        }

        private async Task<OperationResult> LoadFactClients()
        {
            OperationResult result = new OperationResult();

            try
            {
                var clientes = await _northwindContext.VwClientesAtendidos.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando Fact de Clientes. {ex.Message} ";
            }

            return result;
        }
    }
}