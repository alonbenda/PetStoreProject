using PetStoreProject.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStoreProject.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Range(0, 150)]
        public int Age { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Please enter a valid picture url")]
        public string? PictureName { get; set; }
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [ForeignKey("Id")]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

        public Animal()
        {
            Comments = new List<Comment>();
        }
    }
}
