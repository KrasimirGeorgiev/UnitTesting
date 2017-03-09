using System;

namespace Poker
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int ValidHandCards = 5;

        private readonly IComparer<IHand> handComparer;

        public PokerHandsChecker(IComparer<IHand> pokerHandComparer)
        {
            if (pokerHandComparer == null)
            {
                throw new ArgumentNullException(nameof(pokerHandComparer));
            }

            this.handComparer = pokerHandComparer;
        }

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException(nameof(hand));
            }

            bool validCount = hand.Cards
                .Distinct()
                .Count() == ValidHandCards;

            return validCount;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return this.CheckHand(hand, h =>
            {
                return h.Cards
                    .GroupBy(c => c.Face)
                    .Any(group => group.Count() == 4);
            });
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            return this.CheckHand(hand, h =>
            {
                return h.Cards
                    .All(c => c.Suit == h.Cards.First().Suit);
            });
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("Cannot compare invalid hands");
            }

            return this.handComparer.Compare(firstHand, secondHand);
        }

        private bool CheckHand(IHand hand, Predicate<IHand> predicate)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            return predicate(hand);
        }
    }
}
