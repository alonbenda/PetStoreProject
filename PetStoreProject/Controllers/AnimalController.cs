using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Models;
using PetStoreProject.Services;

namespace PetStoreProject.Controllers
{
    public class AnimalController : Controller
    {
        private IStoreServices _service;

        public AnimalController(IStoreServices service)
        {
            _service = service;
        }
        
        public IActionResult AnimalPage(int id)
        {
            ViewBag.Animal = _service.InitializeAnimalCommentsList(id);

            ViewBag.Category = _service.GetCategories().Where(category => category.Id == ViewBag.Animal.CategoryId).First();
            return View();
        }

        public IActionResult AddComment(Comment comment)
        {
            ViewBag.Animal = _service.InitializeAnimalCommentsList(comment.AnimalId);

            _service.AddComment(ViewBag.Animal, comment);

            ViewBag.Category = _service.GetCategories().Where(category => category.Id == ViewBag.Animal.CategoryId).First();
            return View("AnimalPage");
        }
    }
}
