namespace Cars.Tests.Mocks
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;
    using Moq;

    public class CarRepositoryMock : ICarsRepositoryMock
    {
        public CarRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeCarsRepositoryMock();
        }

        public ICarsRepository CarsData { get; private set; }

        // Exposed mock to be used for assertions
        public Mock<ICarsRepository> Mock { get; private set; }

        public int TotalCars => this.FakeCarCollection.Count;

        public int[] InvalidIds => new[] { 101, 102, 103 };

        protected ICollection<ICar> FakeCarCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeCarCollection = new List<ICar>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 }
            };
        }

        // Inheritance vs transparency -> Mock is now in a single file and easier to understand/follow
        private void ArrangeCarsRepositoryMock()
        {
            this.Mock = new Mock<ICarsRepository>();

            this.Mock.Setup(r => r.Add(It.IsAny<ICar>())).Verifiable();
            this.Mock.Setup(r => r.All()).Returns(this.FakeCarCollection);
            this.Mock.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            this.Mock.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());

            // Homework bellow

            this.Mock.Setup(r => r.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());

            this.Mock.Setup(r => r.SortedByYear())
               .Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());

            this.Mock.Setup(r => r.GetById(It.IsIn(this.InvalidIds))).Returns(default(ICar));

            this.CarsData = this.Mock.Object;
        }
    }
}
