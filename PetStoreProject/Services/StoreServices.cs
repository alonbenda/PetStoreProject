using PetStoreProject.Data;
using PetStoreProject.Models;

namespace PetStoreProject.Services
{
    public class StoreServices : IStoreServices
    {
        private StoreContext _context;
        public StoreServices(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals!;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories!;
        }
        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments!;
        }
        public IEnumerable<Admin> GetAdmins()
        {
            return _context.Admins!;
        }

        public void AddNewAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }
        public void AddNewAdmin(Admin admin)
        {
            _context.Admins!.Add(admin);
            _context.SaveChanges();
        }
        
        #region Edit
        public void EditName(int id, Animal animal)
        {
            _context.Animals!.Where(a => a.Id == id).First().Name = animal.Name;
            _context.SaveChanges();
        }
        public void EditAge(int id, Animal animal)
        {
            _context.Animals!.Where(a => a.Id == id).First().Age = animal.Age;
            _context.SaveChanges();
        }
        public void EditPicture(int id, Animal animal)
        {
            _context.Animals!.Where(a => a.Id == id).First().PictureName = animal.PictureName;
            _context.SaveChanges();
        }
        public void EditDescription(int id, Animal animal)
        {
            _context.Animals!.Where(a => a.Id == id).First().Description = animal.Description;
            _context.SaveChanges();
        }
        #endregion Edit

        public void DeleteAnimal(Animal animal)
        {
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }

        public void AddComment(Animal animal, Comment comment)
        {
            animal.Comments!.Add(comment);
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> GetMostCommentedAnimals()
        {
            var animals = GetAnimals();
            var comments = GetComments().ToList();
            foreach (var animal in animals)
            {
                animal.Comments = comments.Where(c => c.AnimalId == animal.Id).ToList();
            }
            return animals.OrderByDescending(a => a.Comments!.Count).Take(2);
        }

        public IEnumerable<Animal> FilteringCategories(string selectedCategory)
        {
            if (selectedCategory == "" || selectedCategory == null)
            {
                return GetAnimals();
            }
            else
            {
                var category = GetCategories().Where(c => c.Name == selectedCategory).First();
                return GetAnimals().Where(a => a.CategoryId == category.Id);
            }
        }
    
        public bool CheckValidAdmin(Admin admin, out string errorMessage)
        {
            errorMessage = "";
            foreach (var adm in GetAdmins())
            {
                if (admin.UserName == adm.UserName)
                {
                    if (admin.Password == adm.Password)
                    {
                        return true;
                    }
                    else
                    {
                        errorMessage = "Wrong Password";
                        break;
                    }
                }
                else
                {
                    errorMessage = "Wrong UserName";
                }
            }
            return false;
        }

        public Animal InitializeAnimalCommentsList(int id)
        {
            var animal = GetAnimals().Where(a => a.Id == id).First();
            animal.Comments = GetComments().Where(c => c.AnimalId == animal.Id).ToList();
            return animal;
        }
    }
}
