namespace DeckTests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void CreatingDeck_ShouldCreateDeck_With24CardsLeft()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void CreatingDeck_ShouldAssingTrumpCard()
        {
            var deck = new Deck();

            Assert.NotNull(deck.TrumpCard);
        }

        [Test]
        public void GettingCard_ShouldReduceCount_ByOne()
        {
            var deck = new Deck();
            var count = deck.CardsLeft;

            var card = deck.GetNextCard();

            Assert.AreEqual(count - 1, deck.CardsLeft);
        }

        [Test]
        public void GettingsCards_FromEmptyDeck_ShouldThrow()
        {
            var deck = new Deck();
            var cardsCount = deck.CardsLeft;

            for (int i = 0; i < cardsCount; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void ThrumpCard_ShouldBeTheLastDrawnCard()
        {
            var deck = new Deck();
            var cardsCount = deck.CardsLeft;

            for (int i = 0; i < cardsCount - 1; i++)
            {
                deck.GetNextCard();
            }

            var last = deck.GetNextCard();
            Assert.AreSame(last, deck.TrumpCard);

        }

        [Test]
        public void GettingCard_ShouldNever_ReturnTheSameCard()
        {
            var deck = new Deck();
            var cardsCount = deck.CardsLeft;
            var cards = new HashSet<Card>();

            for (int i = 0; i < cardsCount; i++)
            {
                var card = deck.GetNextCard();
                Assert.IsFalse(cards.Contains(card));

                cards.Add(card);
            }
        }

        [Test]
        public void GettingCard_ShouldNotReturn_NullValue()
        {
            var deck = new Deck();
            var cardsCount = deck.CardsLeft;

            for (int i = 0; i < cardsCount; i++)
            {
                var card = deck.GetNextCard();
                Assert.NotNull(card);
            }
        }

        [Test]
        public void ChangingTrumpCards_ShouldWork_WhitValidCard()
        {
            var deck = new Deck();
            var card = deck.GetNextCard();

            Assert.AreNotSame(card, deck.TrumpCard);
            deck.ChangeTrumpCard(card);
            Assert.AreSame(card, deck.TrumpCard);
        }

        // Sole purpose was to create parametrized test for the homework
        [Test]
        [TestCase(5)]
        [TestCase(15)]
        public void EachDeck_ShouldBeShuffled(int decks)
        {
            var firstCards = new List<Card>();

            for (int i = 0; i < decks; i++)
            {
                var deck = new Deck();
                firstCards.Add(deck.GetNextCard());
            }

            var distinct = firstCards.Distinct().ToArray();
            Assert.IsTrue(distinct.Length > 1);
        }
    }
}
