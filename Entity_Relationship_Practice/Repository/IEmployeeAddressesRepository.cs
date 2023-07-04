using Entity_Relationship_Practice.Models;

namespace Entity_Relationship_Practice.Repository
{
    public interface IEmployeeAddressesRepository
    {
        Task<IEnumerable<EmployeeAddresses>> GetEmployeeAddresses();
        Task<EmployeeAddresses> GetEmployeeAddresses(int Id);
        Task<EmployeeAddresses> AddEmployeeAddresses(EmployeeAddresses employeeaddress);
        Task<EmployeeAddresses> UpdateEmployeeAddresses(EmployeeAddresses employeeaddress);
        Task<EmployeeAddresses> DeleteEmployeeAddresses(int Id);
    }
}
