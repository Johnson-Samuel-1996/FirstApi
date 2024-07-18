using System.ComponentModel.DataAnnotations;

namespace FirstApi.Dto
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }

    }
}
