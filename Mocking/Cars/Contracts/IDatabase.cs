namespace Cars.Contracts
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        IList<ICar> Cars { get; set; }
    }
}
