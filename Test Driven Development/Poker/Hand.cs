using System.Collections.Generic;

namespace Poker
{
    using System;
    using Interfaces;

    public class Hand : IHand
    {
        private readonly IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException();
            }

            if (cards.Count == 0)
            {
                throw new ArgumentException("Cards should be more than zero");
            }

            this.cards = cards;
        }

        public IEnumerable<ICard> Cards => this.cards;

        public override string ToString()
        {
            return string.Format("Hand:\n{0}", string.Join("\n", this.Cards));
        }
    }
}
