namespace Poker.Interfaces
{
    using System.Collections.Generic;

    public interface IHand
    {
        IEnumerable<ICard> Cards { get; }

        string ToString();
    }
}
