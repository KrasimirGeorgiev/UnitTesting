namespace Poker.Tests.Mock
{
    using Enum;
    using Interfaces;

    public interface IHandsFactory
    {
        ICard CardFactoryMethod(CardFace face, CardSuit suit);

        IHand GetHighCardHand();
        IHand GetOnePairHand();
        IHand GetThreeOfAKindHand();
        IHand GetFlushHand();
        IHand GetFourOfAKindHand();
    }
}
