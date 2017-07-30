﻿using System;
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

            SelectLevelName.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - SelectLevelName.Size.Width / 2, (Screen.PrimaryScreen.Bounds.Height / 2) - 300);


            BackFromSelectLvl2MenuButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            BackFromSelectLvl2MenuButton.Location = new System.Drawing.Point(Constants.MARGIN_BACK2MENU, Screen.PrimaryScreen.Bounds.Height - (BackFromSelectLvl2MenuButton.Height + Constants.MARGIN_BACK2MENU));

            LevelsPanel.Size = new System.Drawing.Size(Constants.VALUE_OF_LEVELS_IN_ROW * (Constants.IMG_LEVEL_SIZE + Constants.MARGIN_BETWEEN_LEVELS), (Constants.MAX_LEVEL / Constants.VALUE_OF_LEVELS_IN_ROW) * (Constants.IMG_LEVEL_SIZE + Constants.MARGIN_BETWEEN_LEVELS));
            LevelsPanel.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width / 2) - (Constants.VALUE_OF_LEVELS_IN_ROW * (Constants.IMG_LEVEL_SIZE + Constants.MARGIN_BETWEEN_LEVELS)) / 2 ,Constants.SELECT_LEVEL_PANEL_MARGIN_UP);

            Button[] buttons = {
                               button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, 
                               button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
                               button21, button22, button23, button24, button25, button26, button27, button28, button29, button30,
                           };

            int counter = 0;
            for (int i = 0; i < Constants.MAX_LEVEL / Constants.VALUE_OF_LEVELS_IN_ROW; i++)
            {
                for (int j = 0; j < Constants.VALUE_OF_LEVELS_IN_ROW; j++)
                {
                    buttons[counter].Size = new System.Drawing.Size(Constants.IMG_LEVEL_SIZE, Constants.IMG_LEVEL_SIZE);
                    buttons[counter].Location = new System.Drawing.Point(j * (Constants.IMG_LEVEL_SIZE + Constants.MARGIN_BETWEEN_LEVELS), i * (Constants.IMG_LEVEL_SIZE + Constants.MARGIN_BETWEEN_LEVELS));
                    buttons[counter++].Enabled = false;
                }
            }
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/maxLevel.txt");
            if (!File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "0");
            }
            int level = Int32.Parse(System.IO.File.ReadAllText(path));
            if (level > Constants.MAX_LEVEL)
                level = Constants.MAX_LEVEL;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "1");

            RunLevel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "2");

            RunLevel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "3");

            RunLevel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "4");

            RunLevel();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "5");

            RunLevel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "6");

            RunLevel();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "7");

            RunLevel();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "8");

            RunLevel();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "9");

            RunLevel();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "10");

            RunLevel();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "11");

            RunLevel();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "12");

            RunLevel();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "13");

            RunLevel();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "14");

            RunLevel();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "15");

            RunLevel();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "16");

            RunLevel();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "17");

            RunLevel();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "18");

            RunLevel();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "19");

            RunLevel();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "20");

            RunLevel();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "21");

            RunLevel();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "22");

            RunLevel();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "23");

            RunLevel();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "24");

            RunLevel();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "25");

            RunLevel();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "26");

            RunLevel();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "27");

            RunLevel();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "28");

            RunLevel();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "29");

            RunLevel();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            System.IO.File.WriteAllText(path, "30");

            RunLevel();
        }
    }
}
