namespace Cars.Controllers
{
    using System;
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Data;
    using Infrastructure;

    public class CarsController : ICarsController
    {
        private readonly ICarsRepository carsData;

        public CarsController()
            : this(new CarsRepository())
        {
        }

        public CarsController(ICarsRepository data)
        {
            this.carsData = data;
        }

        public IView<ICollection<ICar>> Index()
        {
            var cars = this.carsData.All();
            return new View<ICollection<ICar>>(cars);
        }

        public IView<ICar> Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car", "Car cannot be null");
            }

            if (string.IsNullOrEmpty(car.Make) || string.IsNullOrEmpty(car.Model))
            {
                throw new ArgumentNullException("car", "Car make and model cannot be empty");
            }

            this.carsData.Add(car);
            return this.Details(car.Id);
        }

        public IView<ICar> Details(int id)
        {
            var car = this.carsData.GetById(id);

            if (car == null)
            {
                throw new ArgumentNullException("car", "Car could not be found");
            }

            return new View<ICar>(car);
        }

        public IView<ICollection<ICar>> Search(string condition)
        {
            var result = this.carsData.Search(condition);
            return new View<ICollection<ICar>>(result);
        }

        public IView<ICollection<ICar>> Sort(string parameter)
        {
            ICollection<ICar> result = null;

            switch (parameter)
            {
                case "make": result = this.carsData.SortedByMake(); break;
                case "year": result = this.carsData.SortedByYear(); break;
                default: throw new ArgumentException("Invalid sorting parameter", "parameter");
            }

            return new View<ICollection<ICar>>(result);
        }
    }
}
