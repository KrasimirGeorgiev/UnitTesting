namespace Poker.Interfaces
{
    using System;
    using Enum;

    public interface ICard : IEquatable<ICard>, IComparable<ICard>
    {
        CardFace Face { get; }
        CardSuit Suit { get; }

        string ToString();
    }
}
