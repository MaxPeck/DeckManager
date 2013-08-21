﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeckManager;
using DeckManagerOutput;

namespace DeckManagerOutput
{
    public partial class MainForm : Form
    {
        private MainMenu _mainMenu;

        public MainForm()
        {
            InitializeComponent();
            _mainMenu = new MainMenu();
            _mainMenu.MenuItems.Add(new MenuItem("Game"));
            Menu = _mainMenu;
        }

        private void giveCardToCurrentCharacterButton_Click(object sender, EventArgs e)
        {
            // BIG TODO changed selection mode to multiple, rewrite this 
            // give drawn card to currently selected player (skill or quorum)
            DeckManager.Cards.BaseCard card = (DeckManager.Cards.BaseCard)this.drawnCardListBox.SelectedItem;
            DeckManager.Characters.Character currentPlayer = (DeckManager.Characters.Character)this.characterListBox.SelectedItem;

            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Skill:
                    currentPlayer.skillHand.Add((DeckManager.Cards.SkillCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Quorum:
                    // @todo no representation of quorum deck yet
                    break;
            }

            this.drawnCardListBox.Items.Remove(card);
        }

        private void polDeckButton_Click(object sender, EventArgs e)
        {

            this.drawnCardListBox.BeginUpdate();
            //DeckManager.Cards.SkillCard card = Program.gManager.CurrentGameState.PoliticsDeck.Draw();

            DeckManager.Cards.SkillCard card = new DeckManager.Cards.SkillCard();
            card.CardColor =DeckManager.Cards.Enums.SkillCardColor.Politics;
            card.CardPower = 5;
            card.Heading = "test Card";

            this.drawnCardListBox.Items.Add(card);

            this.drawnCardListBox.EndUpdate();
        }

        private void leaDeckButton_Click(object sender, EventArgs e)
        {

        }

        private void tacDeckButton_Click(object sender, EventArgs e)
        {

        }

        private void engDeckButton_Click(object sender, EventArgs e)
        {

        }

        private void pilDeckButton_Click(object sender, EventArgs e)
        {

        }

        private void treDeckButton_Click(object sender, EventArgs e)
        {

        }

        private void drawCrisisButton_Click(object sender, EventArgs e)
        {
            this.crisisSkillCheckListBox.BeginUpdate();

            // DeckManager.Cards.CrisisCard crisis = Program.gManager.CurrentGameState.CrisisDeck.Draw();

            DeckManager.Cards.CrisisCard crisis = new DeckManager.Cards.CrisisCard();
            crisis.Activation = DeckManager.Cards.Enums.CylonActivations.Raiders;
            crisis.Heading = "Test Crisis";
            crisis.JumpPrep = true;
            crisis.PositiveColors = new List<DeckManager.Cards.Enums.SkillCardColor>();
            crisis.PositiveColors.Add(DeckManager.Cards.Enums.SkillCardColor.Engineering);
            crisis.PositiveColors.Add(DeckManager.Cards.Enums.SkillCardColor.Politics);
            
            this.crisisSkillCheckListBox.Items.Add(crisis);
            this.crisisSkillCheckListBox.EndUpdate();
        }

        private void crisisCopyTextButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(((DeckManager.Cards.CrisisCard)this.crisisSkillCheckListBox.SelectedItem).ToString());
        }

        private void addDestinyCardsButton_Click(object sender, EventArgs e)
        {
            DeckManager.Cards.SkillCard dest1 =  Program.gManager.CurrentGameState.DestinyDeck.Draw();
            DeckManager.Cards.SkillCard dest2 = Program.gManager.CurrentGameState.DestinyDeck.Draw();

            this.crisisSkillCheckListBox.BeginUpdate();
            this.crisisSkillCheckListBox.Items.Add(dest1);            
            this.crisisSkillCheckListBox.Items.Add(dest2);
            this.crisisSkillCheckListBox.EndUpdate();
        }

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            
        }

        private void beginGameButton_Click(object sender, EventArgs e)
        {
            this.addPlayerButton.Enabled = false;
        }

        private void evalSkillCheckButton_Click(object sender, EventArgs e)
        {

        }

        private void playIntoCrisisButton_Click(object sender, EventArgs e)
        {
            DeckManager.Cards.SkillCard card = (DeckManager.Cards.SkillCard)this.characterSkillHandListBox.SelectedItem;
            this.crisisSkillCheckListBox.Items.Add(card);
            ((DeckManager.Characters.Character)this.characterListBox.SelectedItem).discard(card);
            this.characterSkillHandListBox.Items.Remove(card);
        }

        private void discardSkillCardButton_Click(object sender, EventArgs e)
        {
            DeckManager.Characters.Character currentCharacter = (DeckManager.Characters.Character)this.characterListBox.SelectedItem;
            DeckManager.Cards.SkillCard card = (DeckManager.Cards.SkillCard)this.characterSkillHandListBox.SelectedItem;

            bool success = currentCharacter.discard(card);
            if (success)
                ; // update character skill box with character's skill hand info
        }

        private void drawQuorumButton_Click(object sender, EventArgs e)
        {
            DeckManager.Cards.QuorumCard quorum = (DeckManager.Cards.QuorumCard)Program.gManager.CurrentGameState.QuorumDeck.Draw();
            this.drawnCardListBox.Items.Add(quorum);
        }

        private void discardQuorumCardButton_Click(object sender, EventArgs e)
        {

        }

        private void destinationCountUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void returnToDeckButton_Click(object sender, EventArgs e)
        {
            // BIG TODO changed selection mode to multiple, rewrite this 
            // return the selected card to the appropriate deck
            // should probably move these switches elsewhere, outside of gui code.
            DeckManager.Cards.BaseCard card = (DeckManager.Cards.BaseCard)this.drawnCardListBox.SelectedItem;
            switch (card.CardType)
            {
                case DeckManager.Cards.Enums.CardType.Quorum:
                    Program.gManager.CurrentGameState.QuorumDeck.Bury((DeckManager.Cards.QuorumCard)card);
                    break;
                case DeckManager.Cards.Enums.CardType.Skill:
                    switch (((DeckManager.Cards.SkillCard)card).CardColor)
                    {
                        case DeckManager.Cards.Enums.SkillCardColor.Politics:
                            Program.gManager.CurrentGameState.PoliticsDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Leadership:
                            Program.gManager.CurrentGameState.LeadershipDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Tactics:
                            Program.gManager.CurrentGameState.TacticsDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Engineering:
                            Program.gManager.CurrentGameState.EngineeringDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Piloting:
                            Program.gManager.CurrentGameState.PilotingDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                        case DeckManager.Cards.Enums.SkillCardColor.Treachery:
                            Program.gManager.CurrentGameState.TreacheryDeck.Bury((DeckManager.Cards.SkillCard)card);
                            break;
                    }
                    break;
            }
            this.drawnCardListBox.Items.Remove(card);
        }

        private void drawDestinationsButton_Click(object sender, EventArgs e)
        {
            int count = (int)this.destinationCountUpDown.Value;
            this.destinationsListBox.Items.Add(Program.gManager.CurrentGameState.DestinationDeck.DrawMany(count));
        }

        private void characterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update skill card list box
            // update quorum card list box if current character is president
        }

        private void removeFromHandButton_Click(object sender, EventArgs e)
        {
            // move character's currently selected card into the drawn card window. can use this to transfer cards between players
        }

        private void copyGameButton_Click(object sender, EventArgs e)
        {
            // this button click copies an entire post update to the clipboard
            // e.g. http://forums.somethingawful.com/showthread.php?threadid=3563154&userid=0&perpage=40&pagenumber=2#post418151171

        }

        private void drawMissionButton_Click(object sender, EventArgs e)
        {

        }




    }
}
