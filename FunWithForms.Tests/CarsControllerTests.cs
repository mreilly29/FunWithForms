using FunWithForms.Controllers;
using FunWithForms.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace FunWithForms.Tests
{
    public class CarsControllerTests
    {
        private Car car;
        private ICarRepository carRepo;
        private CarsController underTest;

        public CarsControllerTests()
        {
            car = new Car();
            carRepo = Substitute.For<ICarRepository>();
            underTest = new CarsController(carRepo);
        }


        [Fact]
        public void Create_Creates_And_Saves_Car()
        {
            underTest.Create(car);

            carRepo.Received().Create(car);
        }

        [Fact]
        public void Create_Redirects_To_Index_After_Creating()
        {
            var result = underTest.Create(car);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName); //redirecting specifically to Index

        }
        [Fact]
        public void Index_Passes_All_Cars_To_View()
        {
            var expectedCars = new List<Car>();
            carRepo.GetAll().Returns(expectedCars);
            var result = underTest.Index();
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCars, model);
        }

        [Fact]
        public void Details_Passes_Correct_Car_To_View()
        {
            var carId = 42;
            var expectedCar = new Car();

            carRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Details(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }
        [Fact]
        public void Delete_Passes_Correct_Car_To_View()
        {
            var carId = 42;
            var expectedCar = new Car();

            carRepo.GetById(carId).Returns(expectedCar);

            var result = underTest.Delete(carId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCar, model);
        }

        [Fact]
        public void Delete_Post_Deletes_The_Car()
        {
            var carId = 42;
            underTest.DeletePost(carId);

            carRepo.Received().Delete(carId);
        }

        [Fact]
        public void Delete_Redirects_To_Index_After_Creating()
        {
            var result = underTest.DeletePost(42);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName); //redirecting specifically to Index

        }
    }
}
