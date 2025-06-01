using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class PersonRepository : CRUDGeneric<Person>
    {
        #region Fields
        private readonly DbSet<Person> _personSet;
        #endregion

        #region Constructors
        public PersonRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
            _personSet = warehouseDbContext.Set<Person>();
        }
        #endregion

        #region Methods

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _personSet.OfType<Supplier>().ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _personSet.OfType<Customer>().ToListAsync();
        }

        public async Task<Supplier> GetSupplierByPKAsync(int id)
        {
            return  _personSet.OfType<Supplier>().Where(i => i.Id == id).FirstOrDefault();
        }

        public async Task<Customer> GetCustomerByPKAsync(int id)
        {
            return  _personSet.OfType<Customer>().Where(i => i.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
