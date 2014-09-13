﻿namespace DeckManagerOutput
{
    partial class PlayCrisisForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerDropDown = new System.Windows.Forms.ComboBox();
            this.PlayerCardListBox = new System.Windows.Forms.ListBox();
            this.CommitButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PlayerTakeCardsDropdown = new System.Windows.Forms.ComboBox();
            this.PlayerTakeCardsCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.PlayerTakeCardsDropdown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.PlayerDropDown, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerCardListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CommitButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ResultTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SubmitButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CancelButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.PlayerTakeCardsCheckBox, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 431);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PlayerDropDown
            // 
            this.PlayerDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerDropDown.FormattingEnabled = true;
            this.PlayerDropDown.Location = new System.Drawing.Point(3, 3);
            this.PlayerDropDown.Name = "PlayerDropDown";
            this.PlayerDropDown.Size = new System.Drawing.Size(201, 21);
            this.PlayerDropDown.TabIndex = 0;
            this.PlayerDropDown.SelectedIndexChanged += new System.EventHandler(this.PlayerDropDownSelectedIndexChanged);
            // 
            // PlayerCardListBox
            // 
            this.PlayerCardListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerCardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerCardListBox.FormattingEnabled = true;
            this.PlayerCardListBox.Location = new System.Drawing.Point(3, 33);
            this.PlayerCardListBox.Name = "PlayerCardListBox";
            this.PlayerCardListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PlayerCardListBox.Size = new System.Drawing.Size(201, 305);
            this.PlayerCardListBox.TabIndex = 1;
            // 
            // CommitButton
            // 
            this.CommitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitButton.Location = new System.Drawing.Point(129, 344);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(75, 23);
            this.CommitButton.TabIndex = 2;
            this.CommitButton.Text = "Commit →";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButtonClick);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ResultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTextBox.Location = new System.Drawing.Point(210, 3);
            this.ResultTextBox.Name = "ResultTextBox";
            this.tableLayoutPanel1.SetRowSpan(this.ResultTextBox, 3);
            this.ResultTextBox.Size = new System.Drawing.Size(201, 365);
            this.ResultTextBox.TabIndex = 3;
            this.ResultTextBox.Text = "";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(3, 404);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 4;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(336, 404);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // PlayerTakeCardsDropdown
            // 
            this.PlayerTakeCardsDropdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerTakeCardsDropdown.FormattingEnabled = true;
            this.PlayerTakeCardsDropdown.Location = new System.Drawing.Point(210, 374);
            this.PlayerTakeCardsDropdown.Name = "PlayerTakeCardsDropdown";
            this.PlayerTakeCardsDropdown.Size = new System.Drawing.Size(201, 21);
            this.PlayerTakeCardsDropdown.TabIndex = 7;
            // 
            // PlayerTakeCardsCheckBox
            // 
            this.PlayerTakeCardsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PlayerTakeCardsCheckBox.AutoSize = true;
            this.PlayerTakeCardsCheckBox.Location = new System.Drawing.Point(6, 377);
            this.PlayerTakeCardsCheckBox.Name = "PlayerTakeCardsCheckBox";
            this.PlayerTakeCardsCheckBox.Size = new System.Drawing.Size(198, 17);
            this.PlayerTakeCardsCheckBox.TabIndex = 8;
            this.PlayerTakeCardsCheckBox.Text = "Allow player to take committed cards";
            this.PlayerTakeCardsCheckBox.UseVisualStyleBackColor = true;
            // 
            // PlayCrisisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlayCrisisForm";
            this.Text = "PlayCrisisForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox PlayerDropDown;
        private System.Windows.Forms.ListBox PlayerCardListBox;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.RichTextBox ResultTextBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox PlayerTakeCardsDropdown;
        private System.Windows.Forms.CheckBox PlayerTakeCardsCheckBox;
    }
}