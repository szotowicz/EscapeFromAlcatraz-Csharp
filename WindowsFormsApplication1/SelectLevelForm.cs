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
    public partial class SelectLevelForm : Form
    {
        Thread thread;

        public SelectLevelForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            SetElementsOnTheForm();
        }

        private void SetElementsOnTheForm()
        {
            SelectLevelName.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - SelectLevelName.Size.Width / 2, (Screen.PrimaryScreen.Bounds.Height / 2) - 300);

            BackFromSelectLvl2MenuButton.Size = new System.Drawing.Size(Constants.MenuButtonWidth, Constants.MenuButtonHeight);
            BackFromSelectLvl2MenuButton.Location = new System.Drawing.Point(Constants.MarginBack2Menu, Screen.PrimaryScreen.Bounds.Height - (BackFromSelectLvl2MenuButton.Height + Constants.MarginBack2Menu));

            LevelsPanel.Size = new System.Drawing.Size(Constants.ValueOfLevelsInRow * (Constants.ImgLevelSize + Constants.MarginBetweenLevels), (Constants.MaxLevel / Constants.ValueOfLevelsInRow) * (Constants.ImgLevelSize + Constants.MarginBetweenLevels));
            LevelsPanel.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Constants.ValueOfLevelsInRow * (Constants.ImgLevelSize + Constants.MarginBetweenLevels)) / 2, Constants.SelectLevelPanelMarginUp);

            Button[] buttons = {
                               button1, button2, button3, button4, button5, button6, button7, button8, button9, button10,
                               button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
                               button21, button22, button23, button24, button25, button26, button27, button28, button29, button30,
                           };

            int counter = 0;
            for (int i = 0; i < Constants.MaxLevel / Constants.ValueOfLevelsInRow; i++)
            {
                for (int j = 0; j < Constants.ValueOfLevelsInRow; j++)
                {
                    buttons[counter].Size = new System.Drawing.Size(Constants.ImgLevelSize, Constants.ImgLevelSize);
                    buttons[counter].Location = new System.Drawing.Point(j * (Constants.ImgLevelSize + Constants.MarginBetweenLevels), i * (Constants.ImgLevelSize + Constants.MarginBetweenLevels));
                    buttons[counter++].Enabled = false;
                }
            }
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/maxLevel.txt");
            if (!File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "0");
            }
            int level = Int32.Parse(System.IO.File.ReadAllText(path));
            if (level > Constants.MaxLevel)
                level = Constants.MaxLevel;

            for (int i = 0; i < level; i++)
            {
                buttons[i].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.unlockedLevel;
                buttons[i].Text = (i + 1).ToString();
                buttons[i].ForeColor = System.Drawing.Color.White;
                buttons[i].Enabled = true;
            }
        }

        private void BackFromSelectLvl2MenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(OpenNewFormWithMenu);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenNewFormWithMenu(object obj)
        {
            Application.Run(new MenuForm());
        }

        private void OpenNewFormWithGame(object obj)
        {
            Application.Run(new GameForm());
        }

        private void RunLevel()
        {
            this.Close();
            thread = new Thread(OpenNewFormWithGame);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

         private void buttonChangeLvl_Click(object sender, EventArgs e)
         {
             string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
             Button btnSender = (Button)sender;
             File.WriteAllText(path, btnSender.Text);

             RunLevel();
         }
    }
}
