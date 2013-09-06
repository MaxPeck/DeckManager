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
using DeckManager.States;
using DeckManagerOutput;

namespace DeckManagerOutput
{
    public partial class MainForm : Form
    {
        private readonly MainMenu _mainMenu;
        private DradisForm dradis;
        

        public MainForm()
        {
            InitializeComponent();
            _mainMenu = new MainMenu();
            _mainMenu.MenuItems.Add(new MenuItem("Game"));
            Menu = _mainMenu;

            dradis = new DradisForm(this);
        }

        private void GiveCardToCurrentCharacterButtonClick(object sender, EventArgs e)
        {
            // if no cards selected, give all
            object[] cards = new DeckManager.Cards.BaseCard[drawnCardListBox.Items.Count];
            if (drawnCardListBox.SelectedIndex == -1)
                drawnCardListBox.Items.CopyTo(cards, 0);
            else
                drawnCardListBox.SelectedItems.CopyTo(cards, 0);
            var currentPlayer = (Player)characterListBox.SelectedItem;

            // give selected cards to currently selected player (skill or quorum)
            foreach (DeckManager.Cards.BaseCard card in cards)
            {
                switch (card.CardType)
                {
                    case DeckManager.Cards.Enums.CardType.Skill:
                        currentPlayer.Cards.Add((DeckManager.Cards.SkillCard)card);
                        characterSkillHandListBox.Items.Add(card);
                        break;
                    case DeckManager.Cards.Enums.CardType.Quorum:
                        currentPlayer.QuorumHand.Add((DeckManager.Cards.QuorumCard)card);
                        if (!currentPlayer.Titles.Contains(DeckManager.Characters.Enums.Titles.President))
                            ;   // warning case, giving quorum to non-president player. not sure what to do here
                        break;
                }
                drawnCardListBox.Items.Remove(card);
            }
        }

        private void PolDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.PoliticsDeck.Draw();
            drawnCardListBox.Items.Add(card);

            drawnCardListBox.EndUpdate();
        }

        private void LeaDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.LeadershipDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void TacDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.TacticsDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void EngDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.EngineeringDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void PilDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.PilotingDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();   
        }

        private void TreDeckButtonClick(object sender, EventArgs e)
        {
            drawnCardListBox.BeginUpdate();
            DeckManager.Cards.SkillCard card = Program.GManager.CurrentGameState.TreacheryDeck.Draw();
            drawnCardListBox.Items.Add(card);
            drawnCardListBox.EndUpdate();        
        }
        private void CrisisTextBoxMeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 50;
            string item = crisisTextListBox.Items[e.Index].ToString();
            int count = item.Count(f=>f=='\n');
            count++;
            e.ItemHeight *= count;
        }

        private void CrisisTextBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Rectangle itemBounds = e.Bounds;

            e.Graphics.DrawString(crisisTextListBox.Items[e.Index].ToString(),
                e.Font,
                Brushes.Black,
                itemBounds,
                StringFormat.GenericDefault);
            e.DrawFocusRectangle();

        }

        private void DrawCrisisButtonClick(object sender, EventArgs e)
        {
            crisisTextListBox.BeginUpdate();

            // DeckManager.Cards.CrisisCard crisis = Program.gManager.CurrentGameState.CrisisDeck.Draw();
            // TODO: This sort of stuff should really be done in the TESTS project.  See my example in there.
            var crisis = new DeckManager.Cards.CrisisCard
                {
                    Activation = DeckManager.Cards.Enums.CylonActivations.Raiders,
                    Heading = "Test Crisis",
                    JumpPrep = true,
                    AdditionalText = "A description of the crisis",
                    PositiveColors =
                        new List<DeckManager.Cards.Enums.SkillCardColor>
                            {
                                DeckManager.Cards.Enums.SkillCardColor.Engineering,
                                DeckManager.Cards.Enums.SkillCardColor.Politics
                            }
                };

            //DeckManager.Cards.CrisisCard crisis = Program.GManager.CurrentGameState.CrisisDeck.Draw();          
            crisisTextListBox.Items.Add(crisis);
            crisisTextListBox.EndUpdate();
        }

        private void CrisisCopyTextButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetText(crisisSkillCheckListBox.SelectedItem.ToString());
        }

        private void AddDestinyCardsButtonClick(object sender, EventArgs e)
        {
            var dest1 = Program.GManager.CurrentGameState.DestinyDeck.Draw();
            var dest2 = Program.GManager.CurrentGameState.DestinyDeck.Draw();

            crisisSkillCheckListBox.BeginUpdate();
            crisisSkillCheckListBox.Items.Add(dest1);            
            crisisSkillCheckListBox.Items.Add(dest2);
            crisisSkillCheckListBox.EndUpdate();
        }

        private void AddPlayerButtonClick(object sender, EventArgs e)
        {
            ListBox characterList = new ListBox();
            // populate list of characters
            DeckManager.Characters.Character character = new DeckManager.Characters.Character();
            character.CharacterName = "Testman";

            character.DefaultDrawColors = new List<List<DeckManager.Cards.Enums.SkillCardColor>>();
            List<DeckManager.Cards.Enums.SkillCardColor> colores = new List<DeckManager.Cards.Enums.SkillCardColor>();
            colores.Add(DeckManager.Cards.Enums.SkillCardColor.Engineering);

            colores.Add(DeckManager.Cards.Enums.SkillCardColor.Politics);
            colores.Add(DeckManager.Cards.Enums.SkillCardColor.Leadership);
            character.DefaultDrawColors.Add(colores);
            

            characterList.Items.Add(character);
            NewPlayerForm newPlayerForm = new NewPlayerForm(characterList);

            if (newPlayerForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Player newPlayer = newPlayerForm.newPlayer;
                if (characterListBox.Enabled == false)
                {
                    characterListBox.Enabled = true;
                    characterListBox.Items.Clear();
                }
                characterListBox.Items.Add(newPlayer);
            }
        }

        private void BeginGameButtonClick(object sender, EventArgs e)
        {
            addPlayerButton.Enabled = false;
            beginGameButton.Enabled = false;

            //List<Player> players = new List<Player>();
            //players.Add(new Player());
            //players.Add(new Player());
            //players.Add(new Player());

            var players = characterListBox.Items.Cast<Player>().ToList();
            
            GameState gs =  Program.GManager.NewGame(players,0,false);
            enableControls();
        }
        /// <summary>
        /// Controls should be disabled before the game begins. Calling this method enables everything.
        /// </summary>
        private void enableControls()
        { }

        private void EvalSkillCheckButtonClick(object sender, EventArgs e)
        {
            
        }

        private void PlayIntoCrisisButtonClick(object sender, EventArgs e)
        {
            var card = (DeckManager.Cards.SkillCard)characterSkillHandListBox.SelectedItem;
            crisisSkillCheckListBox.Items.Add(card);
            ((Player)characterListBox.SelectedItem).Cards.Remove(card);
            characterSkillHandListBox.Items.Remove(card);
        }

        private void DiscardSkillCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.SkillCard[characterSkillHandListBox.SelectedItems.Count];
            characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.SkillCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                characterSkillHandListBox.Items.Remove(card);
            }
        }

        private void DrawQuorumButtonClick(object sender, EventArgs e)
        {
            var quorum = Program.GManager.CurrentGameState.QuorumDeck.Draw();
            drawnCardListBox.Items.Add(quorum);
        }

        private void DiscardQuorumCardButtonClick(object sender, EventArgs e)
        {
            Array cards = new DeckManager.Cards.QuorumCard[characterSkillHandListBox.SelectedItems.Count];
            characterSkillHandListBox.SelectedItems.CopyTo(cards, 0);
            var currentCharacter = (Player)characterListBox.SelectedItem;

            foreach (DeckManager.Cards.QuorumCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                currentCharacter.Discard(card);
                characterQuorumHandListBox.Items.Remove(card);
            }

        }

        private void DestinationCountUpDownValueChanged(object sender, EventArgs e)
        {
            // number of destination cards to draw
        }

        private void ReturnToDeckButtonClick(object sender, EventArgs e)
        {
            if (drawnCardListBox.SelectedIndex == -1)
                return;

            Array cards = new DeckManager.Cards.BaseCard[drawnCardListBox.SelectedItems.Count];
            drawnCardListBox.SelectedItems.CopyTo(cards, 0);

            foreach (DeckManager.Cards.BaseCard card in cards)
            {
                Program.GManager.DiscardCard(card);
                drawnCardListBox.Items.Remove(card);
            }
        }

        private void DrawDestinationsButtonClick(object sender, EventArgs e)
        {
            var count = (int)destinationCountUpDown.Value;
            destinationsListBox.BeginUpdate();
            destinationsListBox.Items.AddRange(Program.GManager.CurrentGameState.DestinationDeck.DrawMany(count).ToArray());
            destinationsListBox.EndUpdate();
        }

        private void CharacterListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // update skill card list box
            characterSkillHandListBox.BeginUpdate();
            characterQuorumHandListBox.BeginUpdate();

            characterSkillHandListBox.Items.Clear();
            foreach (DeckManager.Cards.SkillCard card in ((Player)characterListBox.SelectedItem).Cards)
                characterSkillHandListBox.Items.Add(card);
            characterSkillHandCountTextBox.Text = characterSkillHandListBox.Items.Count.ToString();

            characterQuorumHandListBox.Items.Clear();
            if (((Player)characterListBox.SelectedItem).QuorumHand.Count > 0)
                foreach (DeckManager.Cards.QuorumCard card in ((Player)characterListBox.SelectedItem).QuorumHand)
                    characterQuorumHandListBox.Items.Add(card);
            characterQuorumHandCountTextBox.Text = characterQuorumHandListBox.Items.Count.ToString();

            characterQuorumHandListBox.EndUpdate();            
            characterSkillHandListBox.EndUpdate();
            // update quorum card list box if current character is president
        }

        private void RemoveFromHandButtonClick(object sender, EventArgs e)
        {
            // move character's currently selected card into the drawn card window. can use this to transfer cards between players
            var currentPlayer = (Player)this.characterListBox.SelectedItem;
            //currentPlayer.Cards.RemoveAll(
        }

        private void CopyGameButtonClick(object sender, EventArgs e)
        {
            // this button click copies an entire post update to the clipboard
            // e.g. http://forums.somethingawful.com/showthread.php?threadid=3563154&userid=0&perpage=40&pagenumber=2#post418151171

        }

        private void DrawMissionButtonClick(object sender, EventArgs e)
        {
            crisisTextListBox.BeginUpdate();
            DeckManager.Cards.MissionCard mis = Program.GManager.CurrentGameState.MissionDeck.Draw();
            crisisTextListBox.Items.Add(mis);
            crisisTextListBox.EndUpdate();
        }

        private void FuelUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void FoodUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void MoraleUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void PopulationUpDownValueChanged(object sender, EventArgs e)
        {

        }

        private void CopyDestinationsButtonClick(object sender, EventArgs e)
        {
            // copies drawn destination cards to clipboard, used to send PM to destination chooser
            var dests = destinationsListBox.Items.Cast<DeckManager.Cards.DestinationCard>().ToList();
            string bbcode = string.Join("\r\n", dests.Select(x => x.ToBBCode()));
            Clipboard.SetText(bbcode);
        }

        private void JumpToDestinationButton_Click(object sender, EventArgs e)
        {

        }

        private void copySkillCheckResultsButton_Click(object sender, EventArgs e)
        {

        }

        private void clearCrisisButton_Click(object sender, EventArgs e)
        {
            // discard all crisis/mission cards drawn
            // discard all skill cards in skill check pile

        }

        private void DradisButton_Click(object sender, EventArgs e)
        {
            dradis.Show();
        }

        private void AddToSkillCheckButton_Click(object sender, EventArgs e)
        {

        }

        private void CopyQuorumToClipboardButton_Click(object sender, EventArgs e)
        {
            if (characterQuorumHandListBox.SelectedIndex >= 0)
                Clipboard.SetText(((DeckManager.Cards.QuorumCard)characterQuorumHandListBox.SelectedItem).ToBBCode());
        }






    }
}
