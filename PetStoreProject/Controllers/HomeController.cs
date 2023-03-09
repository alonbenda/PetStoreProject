using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Data;
using PetStoreProject.Services;

namespace PetStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private IStoreServices _service;

        public HomeController(IStoreServices service)
        {
            _service = service;
        }

        public IActionResult HomePage()
        {
            var a = _service.GetMostCommentedAnimals();
            return View(a);
        }
    }
}
