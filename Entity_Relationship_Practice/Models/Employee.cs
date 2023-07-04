using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Entity_Relationship_Practice.Models
{
    public class Employee
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

        [JsonIgnore]
        public Department Department { get; set; } = null!;

        public List<EmployeeAddresses> EmployeeAddresses { get; set; } = null!;
    }
}
