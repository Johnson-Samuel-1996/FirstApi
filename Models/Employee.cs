using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [Range(18,56)]
        public int Age { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
