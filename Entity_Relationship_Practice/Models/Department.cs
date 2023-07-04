using System.ComponentModel.DataAnnotations;

namespace Entity_Relationship_Practice.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
