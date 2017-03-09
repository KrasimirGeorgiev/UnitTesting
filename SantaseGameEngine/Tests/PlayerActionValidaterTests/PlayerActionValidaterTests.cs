namespace PlayerActionValidaterTests
{
    using NUnit.Framework;
    using Santase.Logic.Cards;
    using Santase.Logic.PlayerActionValidate;
    using Santase.Logic.Players;
    using Santase.Logic.RoundStates;

    [TestFixture]
    public class PlayerActionValidaterTests
    {
        public IPlayerActionValidator Validator => PlayerActionValidator.Instance;

        public IDeck Deck { get; private set; }

        public IStateManager StateManager { get; private set; }

        [PreTest]
        public void BeforeEach()
        {
            this.Deck = new Deck();
            this.StateManager = new StateManager();
        }

        // Todo: this action may not be possible to start with
        [Test]
        public void Announce_OutOfTurn_ShouldThrow()
        {
            var card = new Card(CardSuit.Club, CardType.Queen);
            var action = PlayerAction.PlayCard(card);
            var state = new MoreThanTwoCardsLeftRoundState(this.StateManager);
            this.StateManager.SetState(state);
            var context = new PlayerTurnContext(state, this.Deck.TrumpCard, this.Deck.CardsLeft, 0, 0);
        }

        // Todo: this action may not be possible to start with
        [Test]
        public void ChangingTrump_OutOfTurn_ShouldThrow()
        {

        }

        [Test]
        public void ChangeTrump_WithoutNineOfTrump_ShouldThrow()
        {
            var trump = new Card(CardSuit.Diamond, CardType.Queen);
            this.Deck.ChangeTrumpCard(trump);
            var card = new Card(CardSuit.Club, CardType.Jack);
            var state = new MoreThanTwoCardsLeftRoundState(this.StateManager);
            this.StateManager.SetState(state);

            var action = PlayerAction.ChangeTrump();
            var context = new PlayerTurnContext(state, this.Deck.TrumpCard, this.Deck.CardsLeft, 0, 0);


        }

        [Test]
        public void ChangeTrump_InSecondPhaseOfGame_ShouldThrow()
        {

        }

        [Test]
        public void Announce40_WithoutKingAndQueenOfTrump_ShouldThrow()
        {

        }

        [Test]
        public void Announce20_WithoutKingAndQueenFromTheSameSuit_ShouldThrow()
        {

        }

        [Test]
        public void Announce20_WithKingAndQueenOfTrump_ShouldThrow()
        {

        }
    }
}