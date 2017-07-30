using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MenuForm : Form
    {
        Thread thread;

        public MenuForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            //MAIN MENU PANEL
            MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            MainMenuPanel.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            nameOfGamePic.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - nameOfGamePic.Size.Width / 2, (Screen.PrimaryScreen.Bounds.Height / 2) - 350);

            ResumeGameButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            ResumeGameButton.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - ResumeGameButton.Size.Width / 2, Constants.MENU_BUTTON_MARGIN_UP);

            NewGameButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            NewGameButton.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - NewGameButton.Size.Width / 2, Constants.MENU_BUTTON_MARGIN_UP + Constants.MENU_BUTTON_MARGIN_BETWEEN_BUTTONS * 1);

            SelectLevelButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            SelectLevelButton.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - NewGameButton.Size.Width / 2, Constants.MENU_BUTTON_MARGIN_UP + Constants.MENU_BUTTON_MARGIN_BETWEEN_BUTTONS * 2);
            
            OptionsButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            OptionsButton.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - OptionsButton.Size.Width / 2, Constants.MENU_BUTTON_MARGIN_UP + Constants.MENU_BUTTON_MARGIN_BETWEEN_BUTTONS * 3);
            
            ExitButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            ExitButton.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - ExitButton.Size.Width / 2, Constants.MENU_BUTTON_MARGIN_UP + Constants.MENU_BUTTON_MARGIN_BETWEEN_BUTTONS * 4);

            // OPTIONS PANEL
            OptionsPanel.Location = new System.Drawing.Point(0, 0);
            OptionsPanel.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            AboutGameButton.Size = new System.Drawing.Size(Constants.OPTIONS_BUTTON_WIDTH, Constants.OPTIONS_BUTTON_HEIGHT);
            AboutGameButton.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Constants.OPTIONS_PIC_WIDTH + Constants.OPTIONS_BUTTON_WIDTH) / 2, Constants.MARGIN_OPTIONS_UP);
            
            AboutAuthorButton.Size = new System.Drawing.Size(Constants.OPTIONS_BUTTON_WIDTH, Constants.OPTIONS_BUTTON_HEIGHT);
            AboutAuthorButton.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Constants.OPTIONS_PIC_WIDTH + Constants.OPTIONS_BUTTON_WIDTH) / 2, Constants.MARGIN_OPTIONS_UP + AboutAuthorButton.Height);

            ControlButton.Size = new System.Drawing.Size(Constants.OPTIONS_BUTTON_WIDTH, Constants.OPTIONS_BUTTON_HEIGHT);
            ControlButton.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Constants.OPTIONS_PIC_WIDTH + Constants.OPTIONS_BUTTON_WIDTH) / 2, Constants.MARGIN_OPTIONS_UP + 2 * ControlButton.Height);

            OptionsPictures.Size = new System.Drawing.Size(Constants.OPTIONS_PIC_WIDTH, Constants.OPTIONS_PIC_HEIGHT);
            OptionsPictures.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Constants.OPTIONS_PIC_WIDTH + Constants.OPTIONS_BUTTON_WIDTH) / 2 + Constants.OPTIONS_BUTTON_WIDTH, Constants.MARGIN_OPTIONS_UP);

            BackFromOptionsToMenu.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            BackFromOptionsToMenu.Location = new System.Drawing.Point(Constants.MARGIN_BACK2MENU, Screen.PrimaryScreen.Bounds.Height - (BackFromOptionsToMenu.Height + Constants.MARGIN_BACK2MENU));

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            MainMenuPanel.Visible = false;
            MainMenuPanel.Enabled = false;

            OptionsPanel.Visible = true;
            OptionsPanel.Enabled = true;

            AboutGameButton.BackColor = System.Drawing.Color.Firebrick;

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "1");
            

            this.Close();
            thread = new Thread(OpenNewFormWithGame);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void ResumeGameButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            if(!File.Exists(path)){
                System.IO.File.WriteAllText(path, "1");
            }

            this.Close();
            thread = new Thread(OpenNewFormWithGame);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void OpenNewFormWithGame(object obj)
        {
            Application.Run(new GameForm());
        }

        private void OpenNewFormWithSelectLevel(object obj)
        {
            Application.Run(new SelectLevelForm());
        }

        private void BackFromOptionsToMenu_Click(object sender, EventArgs e)
        {
            MainMenuPanel.Visible = true;
            MainMenuPanel.Enabled = true;

            OptionsPanel.Visible = false;
            OptionsPanel.Enabled = false;

            AboutGameButton.BackColor = System.Drawing.Color.Maroon;
            AboutAuthorButton.BackColor = System.Drawing.Color.Maroon;
            ControlButton.BackColor = System.Drawing.Color.Maroon;

            OptionsPictures.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.aboutGamePIC;

        }

        private void AboutAuthorButton_Click(object sender, EventArgs e)
        {
            AboutGameButton.BackColor = System.Drawing.Color.Maroon;
            AboutAuthorButton.BackColor = System.Drawing.Color.Firebrick;
            ControlButton.BackColor = System.Drawing.Color.Maroon;
            OptionsPictures.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.aboutAuthorPIC;
        }

        private void AboutGameButton_Click(object sender, EventArgs e)
        {
            AboutGameButton.BackColor = System.Drawing.Color.Firebrick;
            AboutAuthorButton.BackColor = System.Drawing.Color.Maroon;
            ControlButton.BackColor = System.Drawing.Color.Maroon;
            OptionsPictures.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.aboutGamePIC;
        }

        private void ControlButton_Click(object sender, EventArgs e)
        {
            AboutGameButton.BackColor = System.Drawing.Color.Maroon;
            AboutAuthorButton.BackColor = System.Drawing.Color.Maroon;
            ControlButton.BackColor = System.Drawing.Color.Firebrick;
            OptionsPictures.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.controlPIC;
        }

        private void SelectLevelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(OpenNewFormWithSelectLevel);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
