using System;
using System.Collections.Generic;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Player;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using KojackGames.Blackjack.Domain.Membership.Model;
using Machine.Specifications;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.DealerAction_Specs.PayingOut
{
    [Subject(typeof(ChipAllocator))]
    public class when_paying_a_winning_hand_with_a_bet_of_5_dollars
    {
        private Establish context = () =>
        {
            chips_that_the_player_should_win = new Chips(12.50m);
            var chips_bet = new Chips(5m);

            SUT = new ChipAllocator();

            playing_positions = MockRepository.GenerateStub<IPlayingPositions>();
            var players_hands = new List<IPlayersHand>();
            var playing_hand = MockRepository.GenerateStub<IPlayersHand>();
            playing_hand.Stub(x => x.has_status_of(HandStatus.won)).Return(true);            
            playing_hand.Stub(x => x.wager).Return(chips_bet);
            players_hands.Add(playing_hand);
            playing_positions.Stub(x => x.players_hands()).Return(players_hands);

            player = MockRepository.GenerateStub<IPlayer>();
        };

        private Because of = () => SUT.allocate_chips_to_player_for_winnings_hands_in(playing_positions, player);
        
        private It should_increase_players_pot_by_12_dollars_and_50_cents =
            () => player.AssertWasCalled(x => x.increase_pot_by(Arg<Chips>.Is.Equal(chips_that_the_player_should_win)));

        private static ChipAllocator SUT;
        private static IPlayingPositions playing_positions;
        private static IPlayer player;
        private static Chips chips_that_the_player_should_win;
    }
}
