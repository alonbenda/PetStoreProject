using System.ComponentModel.DataAnnotations;

namespace PetStoreProject.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }
    }
}
