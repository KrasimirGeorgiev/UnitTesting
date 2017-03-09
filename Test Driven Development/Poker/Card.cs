namespace Poker
{
    using System;
    using Enum;
    using Interfaces;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; }

        public CardSuit Suit { get; }

        public override string ToString()
        {
            return string.Format("{0} of {1}", this.Face, this.Suit);
        }

        public override int GetHashCode()
        {
            return ((int)this.Face + 17) *
                    ((int)this.Suit + 79);
        }

        public override bool Equals(object obj)
        {
            var asCard = obj as ICard;

            if (asCard != null)
            {
                return this.Equals(asCard);
            }

            return false;
        }

        public bool Equals(ICard other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            return this.Face == other.Face && this.Suit == other.Suit;
        }

        public int CompareTo(ICard other)
        {
            throw new NotImplementedException();
        }
    }
}
