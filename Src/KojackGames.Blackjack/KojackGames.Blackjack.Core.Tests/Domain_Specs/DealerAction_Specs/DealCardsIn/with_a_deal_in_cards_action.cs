using System.Collections.Generic;
using KojackGames.Blackjack.Domain.GamePlay.Model;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Dealer;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Player;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using KojackGames.Blackjack.Domain.Membership.Model;
using Rhino.Mocks;

namespace KojackGames.Blackjack.Core.Tests.Domain_Specs.DealerAction_Specs.DealCardsIn
{
public abstract class with_a_deal_in_cards_action
{
    protected static Domain.GamePlay.Model.Dealer.Actions.DealCardsIn SUT;
    protected static IPlayingHandsEndGameStatusDecider playing_hands_end_game_status_decider;
    protected static IHandStatusFactory hand_status_factory;
        
    protected static IPlayingPositions positions;
    protected static IPlayersHand players_hand;
    protected static IDealersHand dealers_hand;
    protected static List<IHand> hands;
    protected static IHand hand;
    protected static ICardShoe card_shoe;    
    protected static IPlayer player;
    protected static IOptionsAvailableToPlayerAfterDealing after_dealing_options;
    protected static IChipAllocator chip_allocator;

    public with_a_deal_in_cards_action()
    {
        player = MockRepository.GenerateStub<IPlayer>();

        card_shoe = MockRepository.GenerateStub<ICardShoe>();
        positions = MockRepository.GenerateStub<IPlayingPositions>();
            
        players_hand = MockRepository.GenerateStub<IPlayersHand>();
        positions.Stub(x => x.players_active_hand).Return(players_hand);
        dealers_hand = MockRepository.GenerateStub<IDealersHand>();
        positions.Stub(x => x.dealers_hand).Return(dealers_hand);

        hand = MockRepository.GenerateStub<IHand>();
        hands = new List<IHand>() { hand };
        positions.Stub(x => x.all_hands).Return(hands);

        hand_status_factory = MockRepository.GenerateStub<IHandStatusFactory>();
        playing_hands_end_game_status_decider = MockRepository.GenerateStub<IPlayingHandsEndGameStatusDecider>();
        after_dealing_options = MockRepository.GenerateStub<IOptionsAvailableToPlayerAfterDealing>();
        chip_allocator = MockRepository.GenerateStub<IChipAllocator>();

        SUT = new Domain.GamePlay.Model.Dealer.Actions.DealCardsIn(hand_status_factory, 
                                                                    playing_hands_end_game_status_decider,
                                                                    after_dealing_options,
                                                                    chip_allocator);
    }
}
}