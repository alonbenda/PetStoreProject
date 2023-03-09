using Microsoft.AspNetCore.Mvc;
using Moq;
using PetStoreProject.Controllers;
using PetStoreProject.Data;
using PetStoreProject.Models;
using PetStoreProject.Services;

namespace PetStoreProject.Test
{
    [TestClass]
    public class StoreServicesTests
    {
        private readonly StoreServices _services;
        private readonly Mock<StoreContext> dataMock = new Mock<StoreContext>();

        public StoreServicesTests()
        {
            _services = new StoreServices(dataMock.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var animals = _services.GetAnimals();
            var listLenBefore = animals.Count();
            _services.AddNewAnimal(new Animal());
            var listLenAfter = animals.Count();
            Assert.AreEqual(listLenBefore + 1, listLenAfter);
        }
    }
}