﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckManager.Cards.Enums;
using DeckManager.Decks;
using DeckManager.States;
using log4net;

namespace DeckManager
{
    public class GameManager
    {
        private readonly ILog _logger;

        public GameManager(ILog logger)
        {
            _logger = logger;
        }

        public List<GameState> GameStates { get; set; }

        public GameState CurrentGameState { get; private set; }

        public GameState NewGame(IEnumerable<Player> numPlayers, int extraLoyaltyCards, bool usingSympathizer)
        {
            var playerList = numPlayers.ToList();
            GameStates = new List<GameState>();
            var firstTurn = new GameState
                {
                    TurnLog = "Begin game.",

                    CrisisDeck = new CrisisDeck(_logger),
                    MissionDeck  = new MissionDeck(_logger),
                    DestinationDeck = new DestinationDeck(_logger),

                    EngineeringDeck = new SkillCardDeck(_logger, SkillCardColor.Engineering),
                    LeadershipDeck = new SkillCardDeck(_logger, SkillCardColor.Leadership),
                    LoyaltyDeck = new LoyaltyDeck(_logger, playerList.Count(), extraLoyaltyCards, usingSympathizer),
                    PilotingDeck = new SkillCardDeck(_logger, SkillCardColor.Piloting),
                    PoliticsDeck = new SkillCardDeck(_logger, SkillCardColor.Politics),
                    QuorumDeck = new QuorumDeck(_logger),
                    SuperCrisisDeck = new SuperCrisisDeck(_logger),
                    TacticsDeck = new SkillCardDeck(_logger, SkillCardColor.Tactics),
                    TreacheryDeck = new SkillCardDeck (_logger, SkillCardColor.Treachery),
                    Turn = 1,
                    Fuel = 8,
                    Food = 8,
                    Morale = 10,
                    Population = 12
                };

            CurrentGameState = firstTurn;

            //TODO: Need a graceful way to handle Baltar here.
            foreach (var player in playerList)
            {
                player.LoyaltyCards.Add(firstTurn.LoyaltyDeck.Draw());
                DoPlayerDraw(player);
            }

            throw new NotImplementedException();
        }

        public void DoPlayerDraw(Player player, int drawIndex = 0)
        {
            try
            {
                foreach (var color in player.SkillCardDraws.ElementAt(drawIndex))
                {
                    switch (color)
                    {
                        case SkillCardColor.Engineering:
                            player.Cards.Add(CurrentGameState.EngineeringDeck.Draw());
                            break;
                        case SkillCardColor.Leadership:
                            player.Cards.Add(CurrentGameState.EngineeringDeck.Draw());
                            break;
                        case SkillCardColor.Piloting:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
                            break;
                        case SkillCardColor.Tactics:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
                            break;
                        case SkillCardColor.Politics:
                            player.Cards.Add(CurrentGameState.PilotingDeck.Draw());
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error("Error when executing player draw.", e);
                throw;
            }
        }

        public void discardCard(Cards.BaseCard card)
        {   
            // todo each discard creates new gamestate? that would let us implement undos
            // discards the passed card into its appropriate deck
            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Quorum:
                    this.CurrentGameState.QuorumDeck.Discard((DeckManager.Cards.QuorumCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Skill:
                    switch (((DeckManager.Cards.SkillCard)card).CardColor)
                    {
                        case DeckManager.Cards.Enums.SkillCardColor.Politics:
                            this.CurrentGameState.PoliticsDeck.Discard((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Leadership:
                            this.CurrentGameState.LeadershipDeck.Discard((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Tactics:
                            this.CurrentGameState.TacticsDeck.Discard((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Engineering:
                            this.CurrentGameState.EngineeringDeck.Discard((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Piloting:
                            this.CurrentGameState.PilotingDeck.Discard((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Treachery:
                            this.CurrentGameState.TreacheryDeck.Discard((DeckManager.Cards.SkillCard)card);
                            break;
                    }
                    break;
            }
            return;
        }
    }
}
