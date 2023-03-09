using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Models;
using PetStoreProject.Services;
using System.ComponentModel.DataAnnotations;

namespace PetStoreProject.Controllers
{
    public class AdminController : Controller
    {
        private IStoreServices _service;

        public AdminController(IStoreServices service)
        {
            _service = service;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogInPost(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (_service.CheckValidAdmin(admin, out string errorMessage))
                {
                    return RedirectToAction("AdminPage", admin);
                }
                else
                {
                    ViewBag.Error = errorMessage;
                }
            }
            return View("LogIn");
        }

        public IActionResult AdminPage()
        {
            ViewBag.Animals = _service.GetAnimals();
            ViewBag.Categories = _service.GetCategories();
            return View();
        }

        public IActionResult FilterCategories()
        {
            var selectedCategory = Request.Form["categorylist"].ToString();

            ViewBag.Categories = _service.GetCategories();
            ViewBag.Animals = _service.FilteringCategories(selectedCategory!);
            return View("AdminPage");
        }

        #region Edit
        public IActionResult EditPage(int id)
        {
            ViewBag.Animal = _service.GetAnimals().Where(animal => animal.Id == id).First();
            return View();
        }

        public IActionResult EditName(int id, string name)
        {
            var animal = _service.GetAnimals().Where(animal => animal.Id == id).First();
            animal.Name = name;
            _service.EditName(id, animal);
            return RedirectToAction("AdminPage");
        }
        public IActionResult EditAge(int id, int age)
        {
            var animal = _service.GetAnimals().Where(animal => animal.Id == id).First();
            animal.Age = age;
            _service.EditAge(id, animal);
            return RedirectToAction("AdminPage");
        }
        public IActionResult EditPicture(int id, string pictureName)
        {
            var animal = _service.GetAnimals().Where(animal => animal.Id == id).First();
            animal.PictureName = pictureName;
            _service.EditPicture(id, animal);
            return RedirectToAction("AdminPage");
        }
        public IActionResult EditDescription(int id, string description)
        {
            var animal = _service.GetAnimals().Where(animal => animal.Id == id).First();
            animal.Description = description;
            _service.EditDescription(id, animal);
            return RedirectToAction("AdminPage");
        }
        #endregion Edit

        public IActionResult ReturnToAdmin()
        {
            return RedirectToAction("AdminPage");
        }

        public IActionResult Delete(int id)
        {
            var animal = _service.GetAnimals().Where(animal => animal.Id == id).First();
            _service.DeleteAnimal(animal);
            return RedirectToAction("AdminPage");
        }

        public IActionResult Insert()
        {
            ViewBag.Categories = _service.GetCategories();
            return View();
        }
        public IActionResult AddNewAnimal(Animal animal)
        {
            var selectedCategory = Request.Form["categorylist"].ToString();
            var category = _service.GetCategories().Where(c => c.Name == selectedCategory).First();

            animal.Category = category;
            animal.CategoryId = category.Id;

            if (ModelState.IsValid)
            {
                _service.AddNewAnimal(animal);
                return RedirectToAction("AdminPage");
            }
            return View("Insert");
        }

        public IActionResult NewAdmin()
        {
            return View();
        }

        public IActionResult AddNewAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _service.AddNewAdmin(admin);
                return RedirectToAction("LogInPost");
            }

            return View("NewAdmin");
        }
    }
}
