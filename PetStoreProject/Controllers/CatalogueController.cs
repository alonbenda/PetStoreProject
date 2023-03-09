using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStoreProject.Models;
using PetStoreProject.Services;

namespace PetStoreProject.Controllers
{
    public class CatalogueController : Controller
    {
        private IStoreServices _service;

        public CatalogueController(IStoreServices service)
        {
            _service = service;
        }

        public IActionResult CataloguePage()
        {
            ViewBag.Categories = _service.GetCategories();
            ViewBag.Animals = _service.GetAnimals();
            return View();
        }

        public IActionResult FilteringCategories()
        {
            var selectedCategory = Request.Form["categorylist"].ToString();

            ViewBag.Categories = _service.GetCategories();
            ViewBag.Animals = _service.FilteringCategories(selectedCategory!);
            return View("CataloguePage");
        }
    }
}
