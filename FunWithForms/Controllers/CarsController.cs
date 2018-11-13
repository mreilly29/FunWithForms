using System;
using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunWithForms.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository carRepo;

        public CarsController(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }

        public IActionResult Index()
        {
            var allCars = carRepo.GetAll();
            return View(allCars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            carRepo.Create(car);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var car = carRepo.GetById(id);
            return View(car);
        }
        public IActionResult Delete(int id)
        {
            var car = carRepo.GetById(id);
            return View(car);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            carRepo.Delete(id);

            return RedirectToAction("Index");

        }
    }
}
