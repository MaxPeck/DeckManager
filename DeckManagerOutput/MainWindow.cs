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
            // give drawn card to currently selected player (skill or quorum)

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

        }

        private void crisisCopyTextButton_Click(object sender, EventArgs e)
        {

        }

        private void addDestinyCardsButton_Click(object sender, EventArgs e)
        {

        }

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            
        }

        private void beginGameButton_Click(object sender, EventArgs e)
        {

        }

        private void evalSkillCheckButton_Click(object sender, EventArgs e)
        {

        }

        private void playIntoCrisisButton_Click(object sender, EventArgs e)
        {

        }

        private void discardSkillCardButton_Click(object sender, EventArgs e)
        {

        }

        private void drawQuorumButton_Click(object sender, EventArgs e)
        {

        }

        private void discardQuorumCardButton_Click(object sender, EventArgs e)
        {

        }

        private void destinationCountUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void returnToDeckButton_Click(object sender, EventArgs e)
        {
            // return the selected card to the appropriate deck
        }





    }
}
