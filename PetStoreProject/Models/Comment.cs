using System.ComponentModel.DataAnnotations.Schema;

namespace PetStoreProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int AnimalId { get; set; }
        public string? CommentText { get; set; }
    }
}
