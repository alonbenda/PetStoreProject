using PetStoreProject.Models;

namespace PetStoreProject.Services
{
    public interface IStoreServices
    {
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Category> GetCategories();
        IEnumerable<Comment> GetComments();
        IEnumerable<Admin> GetAdmins();

        void AddNewAnimal(Animal animal);
        void AddNewAdmin(Admin admin);

        void EditName(int id, Animal animal);
        void EditAge(int id, Animal animal);
        void EditPicture(int id, Animal animal);
        void EditDescription(int id, Animal animal);

        void DeleteAnimal(Animal animal);

        void AddComment(Animal animal, Comment comment);

        IEnumerable<Animal> GetMostCommentedAnimals();

        IEnumerable<Animal> FilteringCategories(string selectedCategory);

        bool CheckValidAdmin(Admin admin, out string errorMessage);

        Animal InitializeAnimalCommentsList(int id);
    }
}
