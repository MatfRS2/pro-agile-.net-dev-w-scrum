using System;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition;
using KojackGames.Blackjack.Domain.GamePlay.Model.PlayingPosition.Hands.Status;
using KojackGames.Blackjack.Domain.Membership.Model;

namespace KojackGames.Blackjack.Domain.GamePlay.Model.Dealer.Actions
{
    public abstract class DealerActionOnPlayersHand
    {
        private readonly IHandStatusFactory _hand_status_factory;
        private readonly IPlayDealersHand _play_dealers_hand;
        private readonly IPlayingHandsEndGameStatusDecider _playing_hands_end_game_status_decider;
        private readonly IChipAllocator _chip_allocator;

        public DealerActionOnPlayersHand(IHandStatusFactory hand_status_factory, 
                                         IPlayDealersHand play_dealers_hand,
                                         IPlayingHandsEndGameStatusDecider playing_hands_end_game_status_decider,
                                         IChipAllocator chip_allocator)
        {
            _hand_status_factory = hand_status_factory;
            _play_dealers_hand = play_dealers_hand;
            _playing_hands_end_game_status_decider = playing_hands_end_game_status_decider;
            _chip_allocator = chip_allocator;
        }

        public void perform_on(IPlayingPositions playing_positions, ICardShoe card_shoe, IPlayer player)
        {
            action_to_perform(playing_positions, card_shoe, player);

            update_hand_status(playing_positions);

            if (should_play_dealers_hand(playing_positions))
                play_dealers_hand(playing_positions, card_shoe, player);

            playing_positions.clear_all_first_hand_decision_offers();

            playing_positions.update_active_hand();
        }
       
        private bool should_play_dealers_hand(IPlayingPositions hands)
        {
            return hands.player_has_finished();
        }

        public abstract void action_to_perform(IPlayingPositions playing_positions, ICardShoe card_shoe, IPlayer player);

        public void play_dealers_hand(IPlayingPositions playing_positions, ICardShoe card_shoe, IPlayer player)
        {

            // Add to seperate class used twice - CompleteGameActions.perform()
            // 1 . Play Dealers Hand
            // 2 . Work out winners
            // 1 . Pay out cash

            _play_dealers_hand.draw_cards_for_dealer_in(playing_positions, card_shoe);
            
            _playing_hands_end_game_status_decider.decide_end_game_status_for_hands_in(playing_positions);

            _chip_allocator.allocate_chips_to_player_for_winnings_hands_in(playing_positions, player);
        }

        public void update_hand_status(IPlayingPositions hands)
        {
            var players_active_hand = hands.players_active_hand;
            _hand_status_factory.set_status_for(players_active_hand);
        }
    }
}
