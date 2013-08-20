﻿namespace DeckManagerOutput
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.characterQuorumHandCountTextBox = new System.Windows.Forms.TextBox();
            this.characterSkillHandCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.characterQuorumHandListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.characterSkillHandListBox = new System.Windows.Forms.ListBox();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.beginGameButton = new System.Windows.Forms.Button();
            this.characterListBox = new System.Windows.Forms.ListBox();
            this.skillDecksPanel = new System.Windows.Forms.Panel();
            this.giveCardToCurrentCharacterButton = new System.Windows.Forms.Button();
            this.treDeckButton = new System.Windows.Forms.Button();
            this.pilDeckButton = new System.Windows.Forms.Button();
            this.engDeckButton = new System.Windows.Forms.Button();
            this.tacDeckButton = new System.Windows.Forms.Button();
            this.leaDeckButton = new System.Windows.Forms.Button();
            this.polDeckButton = new System.Windows.Forms.Button();
            this.drawnCardListBox = new System.Windows.Forms.ListBox();
            this.crisisPanel = new System.Windows.Forms.Panel();
            this.addDestinyCardsButton = new System.Windows.Forms.Button();
            this.crisisSkillCheckListBox = new System.Windows.Forms.ListBox();
            this.crisisCopyTextButton = new System.Windows.Forms.Button();
            this.crisisTextListBox = new System.Windows.Forms.ListBox();
            this.drawCrisisButton = new System.Windows.Forms.Button();
            this.evalSkillCheckButton = new System.Windows.Forms.Button();
            this.playIntoCrisisButton = new System.Windows.Forms.Button();
            this.discardSkillCardButton = new System.Windows.Forms.Button();
            this.discardQuorumCardButton = new System.Windows.Forms.Button();
            this.drawQuorumButton = new System.Windows.Forms.Button();
            this.copySkillCheckResultsButton = new System.Windows.Forms.Button();
            this.destinationPanel = new System.Windows.Forms.Panel();
            this.destinationCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.drawDestinationsButton = new System.Windows.Forms.Button();
            this.destinationsListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.skillDecksPanel.SuspendLayout();
            this.crisisPanel.SuspendLayout();
            this.destinationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.discardQuorumCardButton);
            this.panel1.Controls.Add(this.discardSkillCardButton);
            this.panel1.Controls.Add(this.playIntoCrisisButton);
            this.panel1.Controls.Add(this.characterQuorumHandCountTextBox);
            this.panel1.Controls.Add(this.characterSkillHandCountTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.characterQuorumHandListBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.characterSkillHandListBox);
            this.panel1.Controls.Add(this.addPlayerButton);
            this.panel1.Controls.Add(this.beginGameButton);
            this.panel1.Controls.Add(this.characterListBox);
            this.panel1.Location = new System.Drawing.Point(9, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 452);
            this.panel1.TabIndex = 0;
            // 
            // characterQuorumHandCountTextBox
            // 
            this.characterQuorumHandCountTextBox.Enabled = false;
            this.characterQuorumHandCountTextBox.Location = new System.Drawing.Point(146, 211);
            this.characterQuorumHandCountTextBox.Name = "characterQuorumHandCountTextBox";
            this.characterQuorumHandCountTextBox.Size = new System.Drawing.Size(36, 20);
            this.characterQuorumHandCountTextBox.TabIndex = 8;
            this.characterQuorumHandCountTextBox.Visible = false;
            // 
            // characterSkillHandCountTextBox
            // 
            this.characterSkillHandCountTextBox.Enabled = false;
            this.characterSkillHandCountTextBox.Location = new System.Drawing.Point(306, 211);
            this.characterSkillHandCountTextBox.Name = "characterSkillHandCountTextBox";
            this.characterSkillHandCountTextBox.Size = new System.Drawing.Size(36, 20);
            this.characterSkillHandCountTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quorum Hand:";
            this.label2.Visible = false;
            // 
            // characterQuorumHandListBox
            // 
            this.characterQuorumHandListBox.FormattingEnabled = true;
            this.characterQuorumHandListBox.Location = new System.Drawing.Point(6, 234);
            this.characterQuorumHandListBox.Name = "characterQuorumHandListBox";
            this.characterQuorumHandListBox.Size = new System.Drawing.Size(176, 173);
            this.characterQuorumHandListBox.TabIndex = 5;
            this.characterQuorumHandListBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Skill Hand:";
            // 
            // characterSkillHandListBox
            // 
            this.characterSkillHandListBox.FormattingEnabled = true;
            this.characterSkillHandListBox.Location = new System.Drawing.Point(186, 234);
            this.characterSkillHandListBox.Name = "characterSkillHandListBox";
            this.characterSkillHandListBox.Size = new System.Drawing.Size(156, 173);
            this.characterSkillHandListBox.TabIndex = 3;
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Location = new System.Drawing.Point(4, 159);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton.TabIndex = 2;
            this.addPlayerButton.Text = "Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // beginGameButton
            // 
            this.beginGameButton.Enabled = false;
            this.beginGameButton.Location = new System.Drawing.Point(267, 159);
            this.beginGameButton.Name = "beginGameButton";
            this.beginGameButton.Size = new System.Drawing.Size(75, 23);
            this.beginGameButton.TabIndex = 1;
            this.beginGameButton.Text = "Begin Game";
            this.beginGameButton.UseVisualStyleBackColor = true;
            this.beginGameButton.Click += new System.EventHandler(this.beginGameButton_Click);
            // 
            // characterListBox
            // 
            this.characterListBox.Enabled = false;
            this.characterListBox.FormattingEnabled = true;
            this.characterListBox.Items.AddRange(new object[] {
            "Press the Add Player Button to add players"});
            this.characterListBox.Location = new System.Drawing.Point(4, 6);
            this.characterListBox.Name = "characterListBox";
            this.characterListBox.Size = new System.Drawing.Size(338, 147);
            this.characterListBox.TabIndex = 0;
            // 
            // skillDecksPanel
            // 
            this.skillDecksPanel.Controls.Add(this.drawQuorumButton);
            this.skillDecksPanel.Controls.Add(this.giveCardToCurrentCharacterButton);
            this.skillDecksPanel.Controls.Add(this.treDeckButton);
            this.skillDecksPanel.Controls.Add(this.pilDeckButton);
            this.skillDecksPanel.Controls.Add(this.engDeckButton);
            this.skillDecksPanel.Controls.Add(this.tacDeckButton);
            this.skillDecksPanel.Controls.Add(this.leaDeckButton);
            this.skillDecksPanel.Controls.Add(this.polDeckButton);
            this.skillDecksPanel.Controls.Add(this.drawnCardListBox);
            this.skillDecksPanel.Location = new System.Drawing.Point(361, 7);
            this.skillDecksPanel.Name = "skillDecksPanel";
            this.skillDecksPanel.Size = new System.Drawing.Size(102, 407);
            this.skillDecksPanel.TabIndex = 1;
            // 
            // giveCardToCurrentCharacterButton
            // 
            this.giveCardToCurrentCharacterButton.Location = new System.Drawing.Point(4, 242);
            this.giveCardToCurrentCharacterButton.Name = "giveCardToCurrentCharacterButton";
            this.giveCardToCurrentCharacterButton.Size = new System.Drawing.Size(29, 23);
            this.giveCardToCurrentCharacterButton.TabIndex = 7;
            this.giveCardToCurrentCharacterButton.Text = "<-";
            this.giveCardToCurrentCharacterButton.UseVisualStyleBackColor = true;
            this.giveCardToCurrentCharacterButton.Click += new System.EventHandler(this.giveCardToCurrentCharacterButton_Click);
            // 
            // treDeckButton
            // 
            this.treDeckButton.Location = new System.Drawing.Point(4, 155);
            this.treDeckButton.Name = "treDeckButton";
            this.treDeckButton.Size = new System.Drawing.Size(75, 23);
            this.treDeckButton.TabIndex = 6;
            this.treDeckButton.Text = "TRE";
            this.treDeckButton.UseVisualStyleBackColor = true;
            this.treDeckButton.Click += new System.EventHandler(this.treDeckButton_Click);
            // 
            // pilDeckButton
            // 
            this.pilDeckButton.Location = new System.Drawing.Point(4, 126);
            this.pilDeckButton.Name = "pilDeckButton";
            this.pilDeckButton.Size = new System.Drawing.Size(75, 23);
            this.pilDeckButton.TabIndex = 5;
            this.pilDeckButton.Text = "PIL";
            this.pilDeckButton.UseVisualStyleBackColor = true;
            this.pilDeckButton.Click += new System.EventHandler(this.pilDeckButton_Click);
            // 
            // engDeckButton
            // 
            this.engDeckButton.Location = new System.Drawing.Point(4, 96);
            this.engDeckButton.Name = "engDeckButton";
            this.engDeckButton.Size = new System.Drawing.Size(75, 23);
            this.engDeckButton.TabIndex = 4;
            this.engDeckButton.Text = "ENG";
            this.engDeckButton.UseVisualStyleBackColor = true;
            this.engDeckButton.Click += new System.EventHandler(this.engDeckButton_Click);
            // 
            // tacDeckButton
            // 
            this.tacDeckButton.Location = new System.Drawing.Point(4, 66);
            this.tacDeckButton.Name = "tacDeckButton";
            this.tacDeckButton.Size = new System.Drawing.Size(75, 23);
            this.tacDeckButton.TabIndex = 3;
            this.tacDeckButton.Text = "TAC";
            this.tacDeckButton.UseVisualStyleBackColor = true;
            this.tacDeckButton.Click += new System.EventHandler(this.tacDeckButton_Click);
            // 
            // leaDeckButton
            // 
            this.leaDeckButton.Location = new System.Drawing.Point(4, 36);
            this.leaDeckButton.Name = "leaDeckButton";
            this.leaDeckButton.Size = new System.Drawing.Size(75, 23);
            this.leaDeckButton.TabIndex = 2;
            this.leaDeckButton.Text = "LEA";
            this.leaDeckButton.UseVisualStyleBackColor = true;
            this.leaDeckButton.Click += new System.EventHandler(this.leaDeckButton_Click);
            // 
            // polDeckButton
            // 
            this.polDeckButton.Location = new System.Drawing.Point(4, 6);
            this.polDeckButton.Name = "polDeckButton";
            this.polDeckButton.Size = new System.Drawing.Size(75, 23);
            this.polDeckButton.TabIndex = 1;
            this.polDeckButton.Text = "POL";
            this.polDeckButton.UseVisualStyleBackColor = true;
            this.polDeckButton.Click += new System.EventHandler(this.polDeckButton_Click);
            // 
            // drawnCardListBox
            // 
            this.drawnCardListBox.FormattingEnabled = true;
            this.drawnCardListBox.Location = new System.Drawing.Point(1, 283);
            this.drawnCardListBox.Name = "drawnCardListBox";
            this.drawnCardListBox.Size = new System.Drawing.Size(101, 121);
            this.drawnCardListBox.TabIndex = 0;
            // 
            // crisisPanel
            // 
            this.crisisPanel.Controls.Add(this.copySkillCheckResultsButton);
            this.crisisPanel.Controls.Add(this.evalSkillCheckButton);
            this.crisisPanel.Controls.Add(this.addDestinyCardsButton);
            this.crisisPanel.Controls.Add(this.crisisSkillCheckListBox);
            this.crisisPanel.Controls.Add(this.crisisCopyTextButton);
            this.crisisPanel.Controls.Add(this.crisisTextListBox);
            this.crisisPanel.Controls.Add(this.drawCrisisButton);
            this.crisisPanel.Location = new System.Drawing.Point(469, 7);
            this.crisisPanel.Name = "crisisPanel";
            this.crisisPanel.Size = new System.Drawing.Size(312, 407);
            this.crisisPanel.TabIndex = 2;
            // 
            // addDestinyCardsButton
            // 
            this.addDestinyCardsButton.Location = new System.Drawing.Point(4, 179);
            this.addDestinyCardsButton.Name = "addDestinyCardsButton";
            this.addDestinyCardsButton.Size = new System.Drawing.Size(75, 40);
            this.addDestinyCardsButton.TabIndex = 4;
            this.addDestinyCardsButton.Text = "Add Destiny Cards";
            this.addDestinyCardsButton.UseVisualStyleBackColor = true;
            this.addDestinyCardsButton.Click += new System.EventHandler(this.addDestinyCardsButton_Click);
            // 
            // crisisSkillCheckListBox
            // 
            this.crisisSkillCheckListBox.FormattingEnabled = true;
            this.crisisSkillCheckListBox.Location = new System.Drawing.Point(85, 179);
            this.crisisSkillCheckListBox.Name = "crisisSkillCheckListBox";
            this.crisisSkillCheckListBox.Size = new System.Drawing.Size(224, 173);
            this.crisisSkillCheckListBox.TabIndex = 3;
            this.crisisSkillCheckListBox.Visible = false;
            // 
            // crisisCopyTextButton
            // 
            this.crisisCopyTextButton.Location = new System.Drawing.Point(3, 32);
            this.crisisCopyTextButton.Name = "crisisCopyTextButton";
            this.crisisCopyTextButton.Size = new System.Drawing.Size(75, 39);
            this.crisisCopyTextButton.TabIndex = 2;
            this.crisisCopyTextButton.Text = "Copy to Clipboard";
            this.crisisCopyTextButton.UseVisualStyleBackColor = true;
            this.crisisCopyTextButton.Click += new System.EventHandler(this.crisisCopyTextButton_Click);
            // 
            // crisisTextListBox
            // 
            this.crisisTextListBox.FormattingEnabled = true;
            this.crisisTextListBox.Location = new System.Drawing.Point(84, 0);
            this.crisisTextListBox.Name = "crisisTextListBox";
            this.crisisTextListBox.Size = new System.Drawing.Size(225, 173);
            this.crisisTextListBox.TabIndex = 1;
            // 
            // drawCrisisButton
            // 
            this.drawCrisisButton.Location = new System.Drawing.Point(3, 3);
            this.drawCrisisButton.Name = "drawCrisisButton";
            this.drawCrisisButton.Size = new System.Drawing.Size(75, 23);
            this.drawCrisisButton.TabIndex = 0;
            this.drawCrisisButton.Text = "Draw Crisis";
            this.drawCrisisButton.UseVisualStyleBackColor = true;
            this.drawCrisisButton.Click += new System.EventHandler(this.drawCrisisButton_Click);
            // 
            // evalSkillCheckButton
            // 
            this.evalSkillCheckButton.Location = new System.Drawing.Point(4, 226);
            this.evalSkillCheckButton.Name = "evalSkillCheckButton";
            this.evalSkillCheckButton.Size = new System.Drawing.Size(75, 39);
            this.evalSkillCheckButton.TabIndex = 5;
            this.evalSkillCheckButton.Text = "Evaluate Skill Check";
            this.evalSkillCheckButton.UseVisualStyleBackColor = true;
            this.evalSkillCheckButton.Click += new System.EventHandler(this.evalSkillCheckButton_Click);
            // 
            // playIntoCrisisButton
            // 
            this.playIntoCrisisButton.Location = new System.Drawing.Point(270, 415);
            this.playIntoCrisisButton.Name = "playIntoCrisisButton";
            this.playIntoCrisisButton.Size = new System.Drawing.Size(75, 34);
            this.playIntoCrisisButton.TabIndex = 9;
            this.playIntoCrisisButton.Text = "Play Into Crisis";
            this.playIntoCrisisButton.UseVisualStyleBackColor = true;
            this.playIntoCrisisButton.Click += new System.EventHandler(this.playIntoCrisisButton_Click);
            // 
            // discardSkillCardButton
            // 
            this.discardSkillCardButton.Location = new System.Drawing.Point(186, 415);
            this.discardSkillCardButton.Name = "discardSkillCardButton";
            this.discardSkillCardButton.Size = new System.Drawing.Size(75, 34);
            this.discardSkillCardButton.TabIndex = 10;
            this.discardSkillCardButton.Text = "Discard Skill Card";
            this.discardSkillCardButton.UseVisualStyleBackColor = true;
            this.discardSkillCardButton.Click += new System.EventHandler(this.discardSkillCardButton_Click);
            // 
            // discardQuorumCardButton
            // 
            this.discardQuorumCardButton.Location = new System.Drawing.Point(6, 415);
            this.discardQuorumCardButton.Name = "discardQuorumCardButton";
            this.discardQuorumCardButton.Size = new System.Drawing.Size(75, 34);
            this.discardQuorumCardButton.TabIndex = 11;
            this.discardQuorumCardButton.Text = "Discard Quorum Card";
            this.discardQuorumCardButton.UseVisualStyleBackColor = true;
            this.discardQuorumCardButton.Visible = false;
            this.discardQuorumCardButton.Click += new System.EventHandler(this.discardQuorumCardButton_Click);
            // 
            // drawQuorumButton
            // 
            this.drawQuorumButton.Location = new System.Drawing.Point(4, 204);
            this.drawQuorumButton.Name = "drawQuorumButton";
            this.drawQuorumButton.Size = new System.Drawing.Size(75, 23);
            this.drawQuorumButton.TabIndex = 8;
            this.drawQuorumButton.Text = "Quorum";
            this.drawQuorumButton.UseVisualStyleBackColor = true;
            this.drawQuorumButton.Click += new System.EventHandler(this.drawQuorumButton_Click);
            // 
            // copySkillCheckResultsButton
            // 
            this.copySkillCheckResultsButton.Location = new System.Drawing.Point(4, 312);
            this.copySkillCheckResultsButton.Name = "copySkillCheckResultsButton";
            this.copySkillCheckResultsButton.Size = new System.Drawing.Size(75, 39);
            this.copySkillCheckResultsButton.TabIndex = 6;
            this.copySkillCheckResultsButton.Text = "Copy to Clipboard";
            this.copySkillCheckResultsButton.UseVisualStyleBackColor = true;
            // 
            // destinationPanel
            // 
            this.destinationPanel.Controls.Add(this.destinationsListBox);
            this.destinationPanel.Controls.Add(this.drawDestinationsButton);
            this.destinationPanel.Controls.Add(this.destinationCountUpDown);
            this.destinationPanel.Location = new System.Drawing.Point(9, 462);
            this.destinationPanel.Name = "destinationPanel";
            this.destinationPanel.Size = new System.Drawing.Size(344, 107);
            this.destinationPanel.TabIndex = 3;
            // 
            // destinationCountUpDown
            // 
            this.destinationCountUpDown.Location = new System.Drawing.Point(87, 13);
            this.destinationCountUpDown.Name = "destinationCountUpDown";
            this.destinationCountUpDown.Size = new System.Drawing.Size(32, 20);
            this.destinationCountUpDown.TabIndex = 0;
            this.destinationCountUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.destinationCountUpDown.ValueChanged += new System.EventHandler(this.destinationCountUpDown_ValueChanged);
            // 
            // drawDestinationsButton
            // 
            this.drawDestinationsButton.Location = new System.Drawing.Point(6, 3);
            this.drawDestinationsButton.Name = "drawDestinationsButton";
            this.drawDestinationsButton.Size = new System.Drawing.Size(75, 36);
            this.drawDestinationsButton.TabIndex = 1;
            this.drawDestinationsButton.Text = "Draw Destinations";
            this.drawDestinationsButton.UseVisualStyleBackColor = true;
            // 
            // destinationsListBox
            // 
            this.destinationsListBox.FormattingEnabled = true;
            this.destinationsListBox.Location = new System.Drawing.Point(6, 47);
            this.destinationsListBox.Name = "destinationsListBox";
            this.destinationsListBox.Size = new System.Drawing.Size(113, 56);
            this.destinationsListBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.destinationPanel);
            this.Controls.Add(this.crisisPanel);
            this.Controls.Add(this.skillDecksPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "BSG Deck Manager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.skillDecksPanel.ResumeLayout(false);
            this.crisisPanel.ResumeLayout(false);
            this.destinationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.destinationCountUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox characterListBox;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Button beginGameButton;
        private System.Windows.Forms.Panel skillDecksPanel;
        private System.Windows.Forms.ListBox characterQuorumHandListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox characterSkillHandListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox characterQuorumHandCountTextBox;
        private System.Windows.Forms.TextBox characterSkillHandCountTextBox;
        private System.Windows.Forms.Button giveCardToCurrentCharacterButton;
        private System.Windows.Forms.Button treDeckButton;
        private System.Windows.Forms.Button pilDeckButton;
        private System.Windows.Forms.Button engDeckButton;
        private System.Windows.Forms.Button tacDeckButton;
        private System.Windows.Forms.Button leaDeckButton;
        private System.Windows.Forms.Button polDeckButton;
        private System.Windows.Forms.ListBox drawnCardListBox;
        private System.Windows.Forms.Panel crisisPanel;
        private System.Windows.Forms.Button addDestinyCardsButton;
        private System.Windows.Forms.ListBox crisisSkillCheckListBox;
        private System.Windows.Forms.Button crisisCopyTextButton;
        private System.Windows.Forms.ListBox crisisTextListBox;
        private System.Windows.Forms.Button drawCrisisButton;
        private System.Windows.Forms.Button evalSkillCheckButton;
        private System.Windows.Forms.Button playIntoCrisisButton;
        private System.Windows.Forms.Button discardSkillCardButton;
        private System.Windows.Forms.Button discardQuorumCardButton;
        private System.Windows.Forms.Button drawQuorumButton;
        private System.Windows.Forms.Button copySkillCheckResultsButton;
        private System.Windows.Forms.Panel destinationPanel;
        private System.Windows.Forms.Button drawDestinationsButton;
        private System.Windows.Forms.NumericUpDown destinationCountUpDown;
        private System.Windows.Forms.ListBox destinationsListBox;
    }
}
