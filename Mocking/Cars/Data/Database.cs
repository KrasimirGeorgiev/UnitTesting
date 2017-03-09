namespace Cars.Data
{
    using System.Collections.Generic;

    using Cars.Contracts;

    public class Database : IDatabase
    {
        public IList<ICar> Cars { get; set; }
    }
}
