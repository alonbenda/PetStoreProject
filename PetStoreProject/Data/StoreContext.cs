using Microsoft.EntityFrameworkCore;
using PetStoreProject.Models;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace PetStoreProject.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Admin>? Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new { Id = 1, Name = "Eagel", Age = 4, PictureName  = @"https://cdn.statically.io/img/poemanalysis.com/f=auto/wp-content/uploads/2021/05/Eagle-Poem-by-Joy-Harjo-Visual-Representation-e1622495790616.jpg", Description = "This is an eagel", CategoryId = 1},
                new { Id = 2, Name = "Lizard", Age = 2, PictureName = @"https://th.bing.com/th/id/OIP.hyLgPqScY4E0JI3530RTBwHaGe?pid=ImgDet&rs=1", Description = "This is a lizard", CategoryId = 2 },
                new { Id = 3, Name = "Snake", Age = 3, PictureName = @"https://th.bing.com/th/id/R.8703175821d5eabbc4e559cd733bd8e7?rik=l2B%2f11zGJXLGqw&riu=http%3a%2f%2fupload.wikimedia.org%2fwikipedia%2fcommons%2ff%2ffe%2fFierce_Snake-Oxyuranus_microlepidotus.jpg&ehk=gE4i29DDZFD9X7oxdbtUFZFhgSnBNhXMjjbxc6cExNQ%3d&risl=&pid=ImgRaw&r=0", Description = "This is a snake", CategoryId = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Bird"},
                new { Id = 2, Name = "Reptile" },
                new { Id = 3, Name = "Mammal" },
                new { Id = 4, Name = "Aquatic" }
            );

            modelBuilder.Entity<Comment>().HasData(
                new { Id = 1, AnimalId = 1, CommentText = "The eagle can see a mouse from 2 km" },
                new { Id = 2, AnimalId = 1, CommentText = "I think her wing span is 2 meters!" },
                new { Id = 3, AnimalId = 2, CommentText = "I think this species is almost extinct" },
                new { Id = 4, AnimalId = 2, CommentText = "Its colors are remarkable" }
            );

            modelBuilder.Entity<Admin>().HasData(
                new { Id = 1, UserName = "Alon", Password = "1234" }
            );
        }
    }
}
