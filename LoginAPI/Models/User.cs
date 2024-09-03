using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
