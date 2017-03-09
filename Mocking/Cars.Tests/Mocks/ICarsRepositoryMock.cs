namespace Cars.Tests.Mocks
{
    using Contracts;
    using Moq;

    public interface ICarsRepositoryMock
    {
        ICarsRepository CarsData { get; }

        Mock<ICarsRepository> Mock { get; }

        int TotalCars { get; }

        int[] InvalidIds { get; }
    }
}
