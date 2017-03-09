namespace Cars.Tests
{
    using System;
    using System.Linq;
    using Contracts;
    using Controllers;
    using Mocks;
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class CarsControllerTests
    {
        private readonly ICarsRepositoryMock carsRepositoryMock;
        private readonly ICarsRepository carsData;
        private ICarsController controller;

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
            this.carsRepositoryMock = carsDataMock;
        }

        public CarsControllerTests()
             : this(new CarRepositoryMock())
        {
        }

        [SetUp]
        public void BeforeEach()
        {
            this.controller = new CarsController(this.carsData);
        }

        [Test]
        public void Index_ShouldReturnAllCars()
        {
            var model = this.GetModel(() => this.controller.Index());

            Assert.AreEqual(this.carsRepositoryMock.TotalCars, model.Count);
        }

        [Test]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.controller.Add(null));
        }

        [Test]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = null,
                Model = "330d",
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarMakeIsEmpty()
        {
            var car = new Car
            {
                Id = 15,
                Make = string.Empty,
                Model = "330d",
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = null,
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCar_ShouldThrowArgumentNullException_IfCarModelIsEmpty()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = string.Empty,
                Year = 2014
            };

            Assert.Throws<ArgumentNullException>(() => this.controller.Add(car));
        }

        [Test]
        public void AddingCar_ShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [Test]
        public void AddingCar_ShouldAddTheCar_ToTheRepository()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            this.controller.Add(car);

            // Verifies that the repository was called with this parameter
            this.carsRepositoryMock.Mock.Verify(r => r.Add(car));
        }

        [Test]
        [TestCase("make")]
        [TestCase("year")]
        public void Sort_ShouldWork_GivenTheCorrectParameter(string parameter)
        {
            var result = this.controller.Sort(parameter);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Sort_ShouldThrow_GivenInvalidParameter()
        {
            Assert.Throws<ArgumentException>(() => this.controller.Sort("kpacoma"));
        }

        [Test]
        public void Detail_ShouldReturn_CarDetails_GivenExistingId()
        {
            var model = this.GetModel(() => this.controller.Details(1));

            var expect = new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 };

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [Test]
        public void Detail_ShouldThrow_IfIdDoesNotExist()
        {
            var id = this.carsRepositoryMock.InvalidIds.First();

            Assert.Throws<ArgumentNullException>(() => this.controller.Details(id));
        }

        [Test]
        public void Search_ShouldWorkCorrectly_WithValidParameters()
        {
            var results = this.GetModel(() => this.controller.Search("MockBu4"));

            Assert.IsTrue(results.All(c => c.Make == "BMW"));
        }

        private T GetModel<T>(Func<IView<T>> funcView) where T : class
        {
            var view = funcView();
            return view.Model;
        }
    }
}
