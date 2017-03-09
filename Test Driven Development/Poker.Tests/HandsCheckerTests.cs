namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Enum;
    using Interfaces;
    using Mock;
    using NUnit.Framework;

    [TestFixture]
    public class HandsCheckerTests
    {
        public IHandsFactory HandsFactory { get; private set; }

        public IPokerHandsChecker HandsChecker { get; private set; }

        [SetUp]
        public void BeforeAll()
        {
            this.HandsFactory = new HandsFactory();

            var comparer = new PokerHandComparer();
            this.HandsChecker = new PokerHandsChecker(comparer);
        }

        /* IsValidHand Tests */

        [Test]
        public void IsValidHand_ShouldReturnTrue_ForValidHands()
        {
            var hand = this.HandsFactory.GetHighCardHand();

            Assert.IsTrue(this.HandsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_ShouldReturnFalse_ForHandsOfLessThanFiveCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            });

            Assert.IsFalse(this.HandsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_ShouldReturnFalse_ForHandsContainingTheSameCard()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),

                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            });

            Assert.IsFalse(this.HandsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_ShouldThrow_WhenTheHandIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.HandsChecker.IsValidHand(null));
        }

        /* IsFlush Tests */

        [Test]
        public void IsFlushHand_ShouldThrow_WhenTheHandIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.HandsChecker.IsFlush(null));
        }

        [Test]
        public void IsFlushHand_ShouldReturnTrue_ForFlushHands()
        {
            var hand = this.HandsFactory.GetFlushHand();

            Assert.IsTrue(this.HandsChecker.IsFlush(hand));
        }

        [Test]
        public void IsFlushHand_ShouldReturnFalse_ForNonFlushHands()
        {
            var hand = this.HandsFactory.GetThreeOfAKindHand();

            Assert.IsFalse(this.HandsChecker.IsFlush(hand));
        }

        [Test]
        public void IsFlushHand_ShouldReturnFalse_ForInvalidHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            Assert.IsFalse(this.HandsChecker.IsFlush(hand));
        }

        /* IsFourOfAKind Tests */

        [Test]
        public void IsFourOfAKind_ShouldThrow_WhenTheHandIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.HandsChecker.IsFourOfAKind(null));
        }

        [Test]
        public void IsFourOfAKind_ShouldReturnTrue_ForCorrectHands()
        {
            var hand = this.HandsFactory.GetFourOfAKindHand();

            Assert.IsTrue(this.HandsChecker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKind_ShouldReturnFalse_ForNonFourOfAKindHands()
        {
            var hand = this.HandsFactory.GetThreeOfAKindHand();

            Assert.IsFalse(this.HandsChecker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKind_ShouldReturnFalse_ForInvalidHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            Assert.IsFalse(this.HandsChecker.IsFourOfAKind(hand));
        }

        /* CompareHands Tests */

        [Test]
        public void CompareHands_ShouldThrow_IfAHandIsInvalid()
        {
            var invalidHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            var hand = this.HandsFactory.GetFlushHand();

            Assert.Throws<ArgumentException>(
                () => this.HandsChecker.CompareHands(invalidHand, hand));

            Assert.Throws<ArgumentException>(
                () => this.HandsChecker.CompareHands(hand, invalidHand));
        }
    }
}