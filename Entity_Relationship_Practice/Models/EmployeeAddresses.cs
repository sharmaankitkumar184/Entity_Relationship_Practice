using System.Text.Json.Serialization;

namespace Entity_Relationship_Practice.Models
{
    public class EmployeeAddresses
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }=null!;
    }
}
