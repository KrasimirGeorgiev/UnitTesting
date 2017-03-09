namespace Poker.Tests.Mock
{
    using System.Collections.Generic;
    using Enum;
    using Interfaces;

    public class HandsFactory : IHandsFactory
    {
        public IHand GetHighCardHand()
        {
            var cards = new List<ICard>
            {
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Three, CardSuit.Spades),
                this.CardFactoryMethod(CardFace.Queen, CardSuit.Spades),
                this.CardFactoryMethod(CardFace.Two, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Seven, CardSuit.Clubs)
            };

            var hand = new Hand(cards);

            return hand;
        }

        public IHand GetOnePairHand()
        {
            var cards = new List<ICard>
            {
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Spades),
                this.CardFactoryMethod(CardFace.Queen, CardSuit.Spades),
                this.CardFactoryMethod(CardFace.Two, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Seven, CardSuit.Clubs)
            };

            var hand = new Hand(cards);

            return hand;
        }

        public IHand GetThreeOfAKindHand()
        {
            var cards = new List<ICard>
            {
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Spades),
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Diamonds),
                this.CardFactoryMethod(CardFace.Two, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Seven, CardSuit.Clubs)
            };

            var hand = new Hand(cards);

            return hand;
        }

        public IHand GetFlushHand()
        {
            var cards = new List<ICard>
            {
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Six, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Queen, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Two, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Seven, CardSuit.Clubs)
            };

            var hand = new Hand(cards);

            return hand;
        }

        public IHand GetFourOfAKindHand()
        {
            var cards = new List<ICard>
            {
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Clubs),
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Spades),
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Diamonds),
                this.CardFactoryMethod(CardFace.Ace, CardSuit.Hearts),
                this.CardFactoryMethod(CardFace.Seven, CardSuit.Clubs)
            };

            var hand = new Hand(cards);

            return hand;
        }

        public ICard CardFactoryMethod(CardFace face, CardSuit suit)
        {
            return new Card(face, suit);
        }
    }
}