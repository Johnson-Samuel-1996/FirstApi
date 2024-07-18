using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstApi.Models
{
    public class Department
    {
     
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        [DefaultValue("Bezohminds")]
        public string CompanyName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
