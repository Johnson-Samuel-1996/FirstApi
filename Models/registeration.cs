using System.ComponentModel.DataAnnotations;

namespace FirstApi.Models
{
    public class Registeration
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
