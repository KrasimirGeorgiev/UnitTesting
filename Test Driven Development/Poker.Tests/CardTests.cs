namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enum;
    using Interfaces;
    using NUnit.Framework;

    [TestFixture]
    public class CardTests
    {
        [Test]
        public void ToString_ShouldReturnString_RepresentingFaceAndSuit()
        {
            this.ForEachPossibleCard(card =>
            {
                var toString = card.ToString();

                Assert.AreEqual($"{card.Face} of {card.Suit}", toString);
            });
        }

        [Test]
        public void Equals_ShouldRetunTrue_WhenPassedCardWithSameFaceAndSuit()
        {
            var cardA = new Card(CardFace.Five, CardSuit.Diamonds);
            var cardB = new Card(CardFace.Five, CardSuit.Diamonds);

            Assert.IsTrue(cardA.Equals(cardB));
        }

        [Test]
        public void Equals_ShouldReturnFalse_WhenPassedCardOfDifferentFace()
        {
            var cardA = new Card(CardFace.Five, CardSuit.Diamonds);
            var cardB = new Card(CardFace.Seven, CardSuit.Diamonds);

            Assert.IsFalse(cardA.Equals(cardB));
        }

        [Test]
        public void Equals_ShouldReturnFalse_WhenPassedCardOfDifferentSuit()
        {
            var cardA = new Card(CardFace.Five, CardSuit.Diamonds);
            var cardB = new Card(CardFace.Five, CardSuit.Clubs);

            Assert.IsFalse(cardA.Equals(cardB));
        }

        [Test]
        public void Equals_ShouldThrow_WhenPassedNull()
        {
            var card = new Card(CardFace.Five, CardSuit.Diamonds);

            Assert.Throws<ArgumentNullException>(() => card.Equals(null));
        }

        [Test]
        public void GetHashCode_ShouldProduceDifferentHash_ForEachCard()
        {
            var hashCodes = new List<int>();

            this.ForEachPossibleCard(card =>
            {
                hashCodes.Add(card.GetHashCode());
            });

            var expected = hashCodes.Count;
            var result = hashCodes.Distinct().Count();

            Assert.IsTrue(52 == hashCodes.Count);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHashCode_ShouldProduceTheSameHash_ForTheSameCard()
        {
            var hashA = new Card(CardFace.Five, CardSuit.Diamonds).GetHashCode();
            var hashB = new Card(CardFace.Five, CardSuit.Diamonds).GetHashCode();

            Assert.AreEqual(hashA, hashB);
        }

        [Test]
        public void Equals_ShouldBeUsable_ToDistinctCardsByEquality()
        {
            var cards = new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds)
            };


            var distinct = cards.Distinct().Count();

            Assert.AreEqual(1, distinct);
        }

        [Test]
        public void CompareTo_ShouldReturn_1_WhenFirstCard_IsHigher_ThanSecnod()
        {
            var faces = ((IEnumerable<CardFace>)Enum.GetValues(typeof(CardFace))).OrderByDescending(f => (int)f);

            var iterator = faces.GetEnumerator();

            var current = iterator.Current;

            while (iterator.MoveNext())
            {
                var next = iterator.Current;
                var a = new Card(current, CardSuit.Clubs);
                var b = new Card(next, CardSuit.Clubs);

                Assert.AreEqual(1, a.CompareTo(b));
            }
        }

        [Test]
        public void CompareTo_ShouldReturn_Minus1_WhenFirstCard_IsLower_ThanSecond()
        {
            var faces = ((IEnumerable<CardFace>)Enum.GetValues(typeof(CardFace))).OrderBy(f => (int)f);

            var iterator = faces.GetEnumerator();

            var current = iterator.Current;

            while (iterator.MoveNext())
            {
                var next = iterator.Current;
                var a = new Card(current, CardSuit.Clubs);
                var b = new Card(next, CardSuit.Clubs);

                Assert.AreEqual(-1, a.CompareTo(b));
            }
        }

        [Test]
        public void CompareTo_ShouldReturn_Zero_WhenTheCardsHaveTheSameFace()
        {
            var a = new Card(CardFace.Ace, CardSuit.Clubs);
            var b = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreEqual(0, a.CompareTo(b));
        }

        private void ForEachPossibleCard(Action<ICard> action)
        {
            var faces = Enum.GetValues(typeof(CardFace));
            var suits = Enum.GetValues(typeof(CardSuit));

            foreach (CardSuit suit in suits)
            {
                foreach (CardFace face in faces)
                {
                    var card = new Card(face, suit);
                    action(card);
                }
            }
        }
    }
}
