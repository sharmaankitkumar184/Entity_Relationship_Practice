namespace Entity_Relationship_Practice.Dto
{
    public class EmployeeAddressDto
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int EmployeeId { get; set; }
    }
}
