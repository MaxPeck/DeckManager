﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using DeckManager.Boards;
using DeckManager.Boards.Dradis;
using DeckManager.Cards.Enums;
using DeckManager.Components;
using DeckManager.Decks;
using DeckManager.Extensions;
using DeckManager.States;
using DeckManager.States.Enums;
using Newtonsoft.Json;
using log4net;

namespace DeckManager
{
    public class GameManager
    {
        private readonly ILog _logger;

        public GameManager()
        {
            _logger = LogManager.GetLogger(typeof (GameManager));
        }

        public GameManager(ILog logger)
        {
            _logger = logger;
        }

        public IList<GameState> GameStates { get; private set; }

        public GameState CurrentGameState
        {
            get { return GameStates.Last(); }
        }

        public GameState NewGame(IEnumerable<Player> numPlayers, int extraLoyaltyCards, bool usingSympathizer)
        {
            var playerList = numPlayers.ToList();
            GameStates = new List<GameState>();
            var firstTurn = new GameState
                {
                    TurnLog = "Begin game.",
                    Players = playerList,

                    CrisisDeck = new CrisisDeck(_logger, ConfigurationManager.AppSettings["CrisisDeckLocation"]),
                    MissionDeck  = new MissionDeck(_logger),
                    DestinationDeck = new DestinationDeck(_logger, ConfigurationManager.AppSettings["DestinationDeckLocation"]),

                    EngineeringDeck = new SkillCardDeck(_logger, SkillCardColor.Engineering, ConfigurationManager.AppSettings["EngineeringDeckLocation"]),
                    LeadershipDeck = new SkillCardDeck(_logger, SkillCardColor.Leadership, ConfigurationManager.AppSettings["LeadershipDeckLocation"]),
                    LoyaltyDeck = new LoyaltyDeck(_logger, playerList.Count(), extraLoyaltyCards, usingSympathizer, ConfigurationManager.AppSettings["LoyaltyDeckLocation"]),
                    PilotingDeck = new SkillCardDeck(_logger, SkillCardColor.Piloting, ConfigurationManager.AppSettings["PilotingDeckLocation"]),
                    PoliticsDeck = new SkillCardDeck(_logger, SkillCardColor.Politics, ConfigurationManager.AppSettings["PoliticsDeckLocation"]),
                    QuorumDeck = new QuorumDeck(_logger, ConfigurationManager.AppSettings["QuorumDeckLocation"]),
                    SuperCrisisDeck = new SuperCrisisDeck(_logger, ConfigurationManager.AppSettings["SuperCrisisDeckLocation"]),
                    TacticsDeck = new SkillCardDeck(_logger, SkillCardColor.Tactics, ConfigurationManager.AppSettings["TacticsDeckLocation"]),
                    TreacheryDeck = new SkillCardDeck(_logger, SkillCardColor.Treachery, ConfigurationManager.AppSettings["TreacheryDeckLocation"]),

                    Dradis = new DradisBoard(),
                    Boards = BuildBoards(),

                    ActiveCivilians = BuildCivilians(),
                    Vipers = BuildVipers(),

                    Turn = 1,
                    Fuel = 8,
                    Food = 8,
                    Morale = 10,
                    Population = 12
                };
            GameStates.Add(firstTurn);

            ShuffleCivs();
            CurrentGameState.Dradis.AddComponentToNode(DrawCiv(), DradisNodeName.Delta);
            CurrentGameState.Dradis.AddComponentToNode(DrawCiv(), DradisNodeName.Delta);
            CurrentGameState.Dradis.AddComponentToNode(DrawViper(), DradisNodeName.Foxtrot);
            CurrentGameState.Dradis.AddComponentToNode(DrawViper(), DradisNodeName.Echo);
            CurrentGameState.Dradis.AddComponentToNode(new Basestar(), DradisNodeName.Alpha);
            CurrentGameState.Dradis.AddComponentToNode(new Raider(), DradisNodeName.Alpha);
            CurrentGameState.Dradis.AddComponentToNode(new Raider(), DradisNodeName.Alpha);
            CurrentGameState.Dradis.AddComponentToNode(new Raider(), DradisNodeName.Alpha);

            //TODO: Fuck it we're not handling Baltar here just let the moderator draw extra cards
            foreach (var player in playerList)
            {
                player.LoyaltyCards.Add(CurrentGameState.LoyaltyDeck.Draw());
                DoPlayerDraw(player);
                AttemptToPlacePlayer(player);
            }

            return CurrentGameState;
        }

        private void AttemptToPlacePlayer(Player player)
        {
            foreach (var location in CurrentGameState.Boards.Select(board => board.Locations.FirstOrDefault(x => player.Character.SetupLocation == x.Name)))
            {
                location.PlayersPresent.Add(player.PlayerName);
                return;
            }
        }

        private List<Board> BuildBoards()
        {
            string jsonString;
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["BoardLocation"]))
            {
                jsonString = reader.ReadToEnd();
            }
            var fromBox = JsonConvert.DeserializeObject<List<BasicLocation>>(jsonString);
            var ret = new List<Board>();
            foreach (var boardName in fromBox.Select(x => x.Name).Distinct())
            {
                var nonClosureBoardName = boardName; // It's unstable to access a foreach variable in a closure like we do below, so we need to copy it out.
                var board = new Board{Locations = new List<BasicLocation>()};
                board.Locations.AddRange(fromBox.Where(x => x.Name == nonClosureBoardName));
                ret.Add(board);
            }
            return ret;
        }

        private List<Viper> BuildVipers()
        {
            // todo account for mk7 vipers

            var viperLimit = ConfigurationManager.AppSettings["MaxVipers"].ParseAs<int>();
            var vipers = new Viper[viperLimit];
            var viperInt = 0;
            // This is a janky way to do a ForEach loop but this is still superior to a For loop because this is guaranteed to terminate.
            foreach (var viper in vipers)
            {
                var newViper = new Viper
                    {
                        PermanentDesignation = Guid.NewGuid(),
                        InternalDesignation = Guid.NewGuid(),
                        PublicDesignation = "Vigilante " + (viperInt+1),
                        Status = ViperStatus.InReserve
                    };
                vipers[viperInt] = newViper;
                viperInt++;
            }
            return vipers.OrderBy(x => x.InternalDesignation).ToList();
        }

        private Viper DrawViper()
        {
            return CurrentGameState.Vipers.FirstOrDefault(x => x.Status == ViperStatus.InReserve);
        }

        private List<Civilian> BuildCivilians()
        {
            string jsonString;
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["CivilianLocation"]))
            {
                jsonString = reader.ReadToEnd();
            }
            var fromBox = JsonConvert.DeserializeObject<List<Civilian>>(jsonString);

            foreach (var civ in fromBox)
                civ.PermanentDesignation = Guid.NewGuid();

            return fromBox;
        }

        private void ShuffleCivs()
        {
            var civInt = 1;
            foreach (var civ in CurrentGameState.ActiveCivilians)
            {
                civ.InternalDesignation = Guid.NewGuid();
                civ.PublicDesignation = "Civ " + civInt;
                civInt++;
            }
            
            CurrentGameState.ActiveCivilians = CurrentGameState.ActiveCivilians.OrderBy(x => x.InternalDesignation).ToList();
        }

        private Civilian DrawCiv()
        {
            return CurrentGameState.ActiveCivilians.Count > 0 ? CurrentGameState.ActiveCivilians.ElementAt(0) : null;
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

        public void DiscardCard(Cards.BaseCard card)
        {   
            // todo each discard creates new gamestate? that would let us implement undos
            // discards the passed card into its appropriate deck
            switch (card.CardType)
            {
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Discard((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    switch (((Cards.SkillCard)card).CardColor)
                    {
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Discard((Cards.SkillCard)card);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Discard((Cards.SkillCard)card);
                            break;
                    }
                    break;
            }
        }
        public void DiscardCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                DiscardCard(card);
        }
                /// <summary>
        /// Place the card on the top of its deck
        /// </summary>
        /// <param name="card"></param>
        public void TopCard(Cards.BaseCard card)
        {
            switch (card.CardType)
            {
                case CardType.Crisis:
                    CurrentGameState.CrisisDeck.Top((Cards.CrisisCard)card);
                    break;
                case CardType.Destination:
                    CurrentGameState.DestinationDeck.Top((Cards.DestinationCard)card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Top((Cards.LoyaltyCard)card);
                    break;
                case CardType.Mission:
                    CurrentGameState.MissionDeck.Top((Cards.MissionCard)card);
                    break;
                case CardType.Mutiny:
                    CurrentGameState.MutinyDeck.Top((Cards.MutinyCard)card);
                    break;
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Top((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skill = (Cards.SkillCard)card;
                    switch (skill.CardColor)
                    {
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Top(skill);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Top(skill);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Top(skill);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Top(skill);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Top(skill);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Top(skill);
                            break;
                    }
                    break;
                case CardType.SuperCrisis:
                    CurrentGameState.SuperCrisisDeck.Top((Cards.SuperCrisisCard)card);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Places the cards on the top of their decks.
        /// </summary>
        /// <param name="cards"></param>
        public void TopCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                BuryCard(card);
        }
        /// <summary>
        /// Place the card on the bottom of its Deck
        /// </summary>
        /// <param name="card"></param>
        public void BuryCard(Cards.BaseCard card)
        {
            switch (card.CardType)
            { 
                case CardType.Crisis:
                    CurrentGameState.CrisisDeck.Bury((Cards.CrisisCard)card);
                    break;
                case CardType.Destination:
                    CurrentGameState.DestinationDeck.Bury((Cards.DestinationCard)card);
                    break;
                case CardType.Loyalty:
                    CurrentGameState.LoyaltyDeck.Bury((Cards.LoyaltyCard)card);
                    break;
                case CardType.Mission:
                    CurrentGameState.MissionDeck.Bury((Cards.MissionCard)card);
                    break;
                case CardType.Mutiny:
                    CurrentGameState.MutinyDeck.Bury((Cards.MutinyCard)card);
                    break;
                case CardType.Quorum:
                    CurrentGameState.QuorumDeck.Bury((Cards.QuorumCard)card);
                    break;
                case CardType.Skill:
                    var skill = (Cards.SkillCard)card;
                    switch (skill.CardColor)
                    { 
                        case SkillCardColor.Politics:
                            CurrentGameState.PoliticsDeck.Bury(skill);
                            break;
                        case SkillCardColor.Leadership:
                            CurrentGameState.LeadershipDeck.Bury(skill);
                            break;
                        case SkillCardColor.Tactics:
                            CurrentGameState.TacticsDeck.Bury(skill);
                            break;
                        case SkillCardColor.Engineering:
                            CurrentGameState.EngineeringDeck.Bury(skill);
                            break;
                        case SkillCardColor.Piloting:
                            CurrentGameState.PilotingDeck.Bury(skill);
                            break;
                        case SkillCardColor.Treachery:
                            CurrentGameState.TreacheryDeck.Bury(skill);
                            break;
                    }
                    break;
                case CardType.SuperCrisis:
                    CurrentGameState.SuperCrisisDeck.Bury((Cards.SuperCrisisCard)card);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// places the cards on the bottom of their decks
        /// </summary>
        /// <param name="cards"></param>
        public void BuryCards(IEnumerable<Cards.BaseCard> cards)
        {
            foreach (Cards.BaseCard card in cards)
                BuryCard(card);
        }
        /// <summary>
        /// Marks the component as destroyed and changes the GameState accordingly.
        /// </summary>
        /// <param name="ship"></param>
        public void DestroyComponent(DeckManager.Components.BaseComponent ship)
        { 
        }

        public void DestroyComponents(IEnumerable<DeckManager.Components.BaseComponent> ships)
        { }

        /// <summary>
        /// Removes the component from active play and places it back in its pile
        /// </summary>
        /// <param name="ship"></param>
        public void DiscardComponent(DeckManager.Components.BaseComponent ship)
        { }

        public void DiscardComponents(IEnumerable<DeckManager.Components.BaseComponent> ships)
        { }
    }
}
