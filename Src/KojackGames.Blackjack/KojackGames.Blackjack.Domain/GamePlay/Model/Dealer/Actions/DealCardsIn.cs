using System;
using KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Observations;
using KojackGames.Blackjack.Domain.GamePlay.Model.Exceptions;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using KojackGames.Blackjack.Domain.Membership.Model;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public class DealCardsIn : IDealerAction
    {
        private readonly IHandStatusFactory _hand_status_factory;
        private readonly IPlayingHandsEndGameStatusDecider _playing_hands_end_game_status_decider;
        private readonly IOptionsAvailableToPlayerAfterDealing _options_available_to_player_after_dealing;
        private readonly IChipAllocator _chip_allocator;
        private readonly CardDealer _card_dealer;

        public DealCardsIn(IHandStatusFactory hand_status_factory, 
                            IPlayingHandsEndGameStatusDecider playing_hands_end_game_status_decider, 
                            IOptionsAvailableToPlayerAfterDealing options_available_to_player_after_dealing, 
                            IChipAllocator chip_allocator)
        {
            _hand_status_factory = hand_status_factory;
            _playing_hands_end_game_status_decider = playing_hands_end_game_status_decider;
            _options_available_to_player_after_dealing = options_available_to_player_after_dealing;
            _chip_allocator = chip_allocator;
            _card_dealer = new CardDealer();
        }
   
        public void perform_on(IPlayingPositions playing_positions, ICardShoe card_shoe, IPlayer player)
        {
            raise_illegal_move_if_action_cannot_be_made_on(playing_positions);

            _card_dealer.deal_two_cards_to_each_hand_in(playing_positions, card_shoe);

            _hand_status_factory.update_the_status_of_each_hand_in(playing_positions);

            if (playing_positions.player_has_blackjack())
            {
                _playing_hands_end_game_status_decider.decide_end_game_status_for_hands_in(playing_positions);
                _chip_allocator.allocate_chips_to_player_for_winnings_hands_in(playing_positions, player);
            }
            else            
                _options_available_to_player_after_dealing.set_for_hands_in(playing_positions);                                                            

            playing_positions.mark_cards_as_dealt();

            playing_positions.update_active_hand();
        }
        
        public void raise_illegal_move_if_action_cannot_be_made_on(IPlayingPositions playing_positions)
        {
            if (playing_positions.have_cards_been_dealt())
                throw new IllegalMoveException("Cannot stick hand as your turn has ended.");
        }            
    }
}
