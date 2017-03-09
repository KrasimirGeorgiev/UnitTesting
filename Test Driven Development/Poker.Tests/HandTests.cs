namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Mock;
    using NUnit.Framework;

    [TestFixture]
    public class HandTests
    {
        public IHandsFactory HandsFactory { get; private set; }

        [SetUp]
        public void BeforeAll()
        {
            this.HandsFactory = new HandsFactory();
        }

        [Test]
        public void CreatingHand_WithNullCardsList_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Hand(null));
        }

        [Test]
        public void CreatingHand_WithEmptyCardsList_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(
                () => new Hand(new List<ICard>()));
        }

        [Test]
        public void Hand_ToString_ShouldReturnString_RepresentingHandCards()
        {
            var hand = this.HandsFactory.GetHighCardHand();

            var expected = string.Format(
                "Hand:\n{0}", string.Join("\n", hand.Cards));


            var result = hand.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
