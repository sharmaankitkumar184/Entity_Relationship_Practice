using Entity_Relationship_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Relationship_Practice.Repository
{
    public class EmployeeAddressesRepository : IEmployeeAddressesRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeAddressesRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<EmployeeAddresses> AddEmployeeAddresses(EmployeeAddresses employeeaddress)
        {
            var result = await appDbContext.employeeAddresses.AddAsync(employeeaddress);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EmployeeAddresses> DeleteEmployeeAddresses(int Id)
        {
            var result = await appDbContext.employeeAddresses
               .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                appDbContext.employeeAddresses.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<EmployeeAddresses>> GetEmployeeAddresses()
        {
            return await appDbContext.employeeAddresses.ToListAsync();
        }

        public async Task<EmployeeAddresses> GetEmployeeAddresses(int Id)
        {
            if (Id == 0)
                return null;
            return await appDbContext.employeeAddresses
               .FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<EmployeeAddresses> UpdateEmployeeAddresses(EmployeeAddresses employeeaddress)
        {
            var result = await appDbContext.employeeAddresses
               .FirstOrDefaultAsync(e => e.EmployeeId == employeeaddress.EmployeeId);

            if (result != null)
            {
                result.City = employeeaddress.City;
                result.Country= employeeaddress.Country;
                result.EmployeeId= employeeaddress.EmployeeId;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
