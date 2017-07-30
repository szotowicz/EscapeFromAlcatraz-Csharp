namespace WindowsFormsApplication1
{
    partial class MenuForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.nameOfGamePic = new System.Windows.Forms.PictureBox();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.ResumeGameButton = new System.Windows.Forms.Button();
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.SelectLevelButton = new System.Windows.Forms.Button();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.OptionsPictures = new System.Windows.Forms.PictureBox();
            this.ControlButton = new System.Windows.Forms.Button();
            this.AboutGameButton = new System.Windows.Forms.Button();
            this.AboutAuthorButton = new System.Windows.Forms.Button();
            this.BackFromOptionsToMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nameOfGamePic)).BeginInit();
            this.MainMenuPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsPictures)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.exitPIC;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(28, 369);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(250, 65);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.Transparent;
            this.NewGameButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.newgamePIC;
            this.NewGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewGameButton.FlatAppearance.BorderSize = 0;
            this.NewGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NewGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NewGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGameButton.Location = new System.Drawing.Point(12, 227);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(250, 65);
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // nameOfGamePic
            // 
            this.nameOfGamePic.BackColor = System.Drawing.Color.Transparent;
            this.nameOfGamePic.Image = global::WindowsFormsApplication1.Properties.Resources.nameOfGame;
            this.nameOfGamePic.Location = new System.Drawing.Point(73, -18);
            this.nameOfGamePic.Name = "nameOfGamePic";
            this.nameOfGamePic.Size = new System.Drawing.Size(800, 200);
            this.nameOfGamePic.TabIndex = 2;
            this.nameOfGamePic.TabStop = false;
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.Transparent;
            this.OptionsButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.optionsPIC;
            this.OptionsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OptionsButton.FlatAppearance.BorderSize = 0;
            this.OptionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OptionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsButton.Location = new System.Drawing.Point(12, 298);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(250, 65);
            this.OptionsButton.TabIndex = 3;
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // ResumeGameButton
            // 
            this.ResumeGameButton.BackColor = System.Drawing.Color.Transparent;
            this.ResumeGameButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.resumePIC;
            this.ResumeGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResumeGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResumeGameButton.FlatAppearance.BorderSize = 0;
            this.ResumeGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ResumeGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ResumeGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResumeGameButton.Location = new System.Drawing.Point(12, 166);
            this.ResumeGameButton.Name = "ResumeGameButton";
            this.ResumeGameButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResumeGameButton.Size = new System.Drawing.Size(250, 65);
            this.ResumeGameButton.TabIndex = 4;
            this.ResumeGameButton.UseVisualStyleBackColor = false;
            this.ResumeGameButton.Click += new System.EventHandler(this.ResumeGameButton_Click);
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainMenuPanel.Controls.Add(this.SelectLevelButton);
            this.MainMenuPanel.Controls.Add(this.ExitButton);
            this.MainMenuPanel.Controls.Add(this.NewGameButton);
            this.MainMenuPanel.Controls.Add(this.nameOfGamePic);
            this.MainMenuPanel.Controls.Add(this.OptionsButton);
            this.MainMenuPanel.Controls.Add(this.ResumeGameButton);
            this.MainMenuPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(978, 498);
            this.MainMenuPanel.TabIndex = 5;
            // 
            // SelectLevelButton
            // 
            this.SelectLevelButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.selectLevelPIC;
            this.SelectLevelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SelectLevelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectLevelButton.FlatAppearance.BorderSize = 0;
            this.SelectLevelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SelectLevelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SelectLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectLevelButton.Location = new System.Drawing.Point(284, 384);
            this.SelectLevelButton.Name = "SelectLevelButton";
            this.SelectLevelButton.Size = new System.Drawing.Size(166, 49);
            this.SelectLevelButton.TabIndex = 5;
            this.SelectLevelButton.UseVisualStyleBackColor = true;
            this.SelectLevelButton.Click += new System.EventHandler(this.SelectLevelButton_Click);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.OptionsPanel.Controls.Add(this.OptionsPictures);
            this.OptionsPanel.Controls.Add(this.ControlButton);
            this.OptionsPanel.Controls.Add(this.AboutGameButton);
            this.OptionsPanel.Controls.Add(this.AboutAuthorButton);
            this.OptionsPanel.Controls.Add(this.BackFromOptionsToMenu);
            this.OptionsPanel.Enabled = false;
            this.OptionsPanel.Location = new System.Drawing.Point(0, 0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(920, 378);
            this.OptionsPanel.TabIndex = 5;
            this.OptionsPanel.Visible = false;
            // 
            // OptionsPictures
            // 
            this.OptionsPictures.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.aboutGamePIC;
            this.OptionsPictures.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionsPictures.Location = new System.Drawing.Point(386, 29);
            this.OptionsPictures.Name = "OptionsPictures";
            this.OptionsPictures.Size = new System.Drawing.Size(427, 254);
            this.OptionsPictures.TabIndex = 9;
            this.OptionsPictures.TabStop = false;
            // 
            // ControlButton
            // 
            this.ControlButton.BackColor = System.Drawing.Color.Maroon;
            this.ControlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ControlButton.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlButton.ForeColor = System.Drawing.Color.Black;
            this.ControlButton.Location = new System.Drawing.Point(73, 166);
            this.ControlButton.Name = "ControlButton";
            this.ControlButton.Size = new System.Drawing.Size(245, 52);
            this.ControlButton.TabIndex = 8;
            this.ControlButton.Text = "Control";
            this.ControlButton.UseVisualStyleBackColor = false;
            this.ControlButton.Click += new System.EventHandler(this.ControlButton_Click);
            // 
            // AboutGameButton
            // 
            this.AboutGameButton.BackColor = System.Drawing.Color.Maroon;
            this.AboutGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutGameButton.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutGameButton.Location = new System.Drawing.Point(73, 29);
            this.AboutGameButton.Name = "AboutGameButton";
            this.AboutGameButton.Size = new System.Drawing.Size(258, 51);
            this.AboutGameButton.TabIndex = 7;
            this.AboutGameButton.Text = "About the game";
            this.AboutGameButton.UseVisualStyleBackColor = false;
            this.AboutGameButton.Click += new System.EventHandler(this.AboutGameButton_Click);
            // 
            // AboutAuthorButton
            // 
            this.AboutAuthorButton.BackColor = System.Drawing.Color.Maroon;
            this.AboutAuthorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutAuthorButton.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutAuthorButton.Location = new System.Drawing.Point(73, 95);
            this.AboutAuthorButton.Name = "AboutAuthorButton";
            this.AboutAuthorButton.Size = new System.Drawing.Size(258, 51);
            this.AboutAuthorButton.TabIndex = 6;
            this.AboutAuthorButton.Text = "About the author";
            this.AboutAuthorButton.UseVisualStyleBackColor = false;
            this.AboutAuthorButton.Click += new System.EventHandler(this.AboutAuthorButton_Click);
            // 
            // BackFromOptionsToMenu
            // 
            this.BackFromOptionsToMenu.BackColor = System.Drawing.Color.Transparent;
            this.BackFromOptionsToMenu.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.back2menuPIC;
            this.BackFromOptionsToMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackFromOptionsToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackFromOptionsToMenu.FlatAppearance.BorderSize = 0;
            this.BackFromOptionsToMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BackFromOptionsToMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BackFromOptionsToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackFromOptionsToMenu.Location = new System.Drawing.Point(54, 247);
            this.BackFromOptionsToMenu.Name = "BackFromOptionsToMenu";
            this.BackFromOptionsToMenu.Size = new System.Drawing.Size(255, 68);
            this.BackFromOptionsToMenu.TabIndex = 5;
            this.BackFromOptionsToMenu.UseVisualStyleBackColor = false;
            this.BackFromOptionsToMenu.Click += new System.EventHandler(this.BackFromOptionsToMenu_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.prisoner;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(977, 499);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.MainMenuPanel);
            this.Name = "MenuForm";
            this.Text = "Alcatraz";
            ((System.ComponentModel.ISupportInitialize)(this.nameOfGamePic)).EndInit();
            this.MainMenuPanel.ResumeLayout(false);
            this.OptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptionsPictures)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.PictureBox nameOfGamePic;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button ResumeGameButton;
        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Button BackFromOptionsToMenu;
        private System.Windows.Forms.Button AboutAuthorButton;
        private System.Windows.Forms.Button AboutGameButton;
        private System.Windows.Forms.Button ControlButton;
        private System.Windows.Forms.PictureBox OptionsPictures;
        private System.Windows.Forms.Button SelectLevelButton;
    }
}

