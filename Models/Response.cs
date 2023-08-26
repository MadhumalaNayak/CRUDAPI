namespace CRUDAPI.Models
{
    public class Response
    {
        public string? StatusMessage { get; set; }
        public Employee? Employee { get; set; }
        public List<Employee>? ListEmployees { get; set; }
        public List<Department>? ListDepartments { get; set; }
    }
}
