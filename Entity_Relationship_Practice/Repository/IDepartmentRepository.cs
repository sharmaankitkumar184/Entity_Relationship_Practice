using Entity_Relationship_Practice.Models;

namespace Entity_Relationship_Practice.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task<Department> AddDepartment(Department department);
    }
}
