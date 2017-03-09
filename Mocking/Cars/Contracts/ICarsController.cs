namespace Cars.Contracts
{
    using System.Collections.Generic;

    public interface ICarsController
    {
        IView<ICollection<ICar>> Index();
        IView<ICar> Add(ICar car);
        IView<ICar> Details(int id);
        IView<ICollection<ICar>> Search(string condition);
        IView<ICollection<ICar>> Sort(string parameter);
    }
}