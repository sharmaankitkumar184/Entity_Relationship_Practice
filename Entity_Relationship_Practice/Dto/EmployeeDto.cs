using System.ComponentModel.DataAnnotations;

namespace Entity_Relationship_Practice.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBrith { get; set; }
        public int DepartmentId { get; set; }
    }
}
