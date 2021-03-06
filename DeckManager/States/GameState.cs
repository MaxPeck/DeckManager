﻿using System.Collections.Generic;
using DeckManager.Boards.Dradis;
using DeckManager.Cards;
using DeckManager.Components;
using DeckManager.Decks;

namespace DeckManager.States
{
    public class GameState
    {
        /// <summary>
        /// A generic string to dump crap that happened during the turn in, for the brains of fleshbags.
        /// </summary>
        public string TurnLog { get; set; }

        public int Fuel { get; set; }
        public int Food { get; set; }
        public int Morale { get; set; }
        public int Population { get; set; }

        public int Turn { get; set; }
        public int Subturn { get; set; }

        public List<Player> Players { get; set; }
        public Player QuorumHandOwner { get; set; }
        public List<QuorumCard> QuorumHand { get; set; }

        public List<Viper> Vipers { get; set; }

        public int MaxRaptors { get; set; }
        public int CurrentRaptors { get; set; }
        
        public List<Civilian> Civilians { get; set; }

        public List<Board> Boards { get; set; }
        public CrisisDeck BoardSkillChecks { get; set; }
        public DradisBoard Dradis { get; set; }

        public int Distance { get; set; }

        private int _jumpPrep;
        public int JumpPrep
        {
            get { return _jumpPrep; }
            set
            {
                _jumpPrep = value;
                if (value < 0)
                    _jumpPrep = 0;
                if (value > 5)
                    _jumpPrep = 5;
            }
        }

        private List<int> _cylonBoarding;
        public List<int> CylonBoarding {
            get
            {
                if (_cylonBoarding == null || _cylonBoarding.Count != 5)
                    _cylonBoarding = new List<int> {0, 0, 0, 0, 0};
                return _cylonBoarding;
            }
            set { _cylonBoarding = value; }
        }

        #region Decks

        public CrisisDeck CrisisDeck { get; set; }
        public DestinationDeck DestinationDeck { get; set; }
        public SuperCrisisDeck SuperCrisisDeck { get; set; }
        public LoyaltyDeck LoyaltyDeck { get; set; }
        public DestinyDeck DestinyDeck { get; set; }
        public QuorumDeck QuorumDeck { get; set; }

        public SkillCardDeck LeadershipDeck { get; set;  }

        public SkillCardDeck PoliticsDeck { get; set; }

        public SkillCardDeck EngineeringDeck { get; set; }

        public SkillCardDeck PilotingDeck { get; set; }

        public SkillCardDeck TacticsDeck { get; set; }

        public SkillCardDeck TreacheryDeck { get; set; }

        #endregion //decks

        public string ToBBCode()
        {
            return "not implemented";
        }
    }
}
