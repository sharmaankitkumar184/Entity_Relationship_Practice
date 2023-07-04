using Entity_Relationship_Practice.Models;
using Microsoft.EntityFrameworkCore;


namespace Entity_Relationship_Practice.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department?> GetDepartment(int departmentId)
        {
            if (departmentId == 0)
                return null;
            return await appDbContext.Departments.FirstOrDefaultAsync<Department>(id => id.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }

        public async Task<Department> AddDepartment(Department department)
        {
            var result = await appDbContext.Departments.AddAsync(department);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
