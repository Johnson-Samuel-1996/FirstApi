using System.ComponentModel.DataAnnotations;

namespace FirstApi.Dto
{
    public class EmployeeDto
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
