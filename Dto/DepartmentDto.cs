using System.ComponentModel;

namespace FirstApi.Dto
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [DefaultValue("Bezohminds")]
        public string CompanyName { get; set; }
    }
}
