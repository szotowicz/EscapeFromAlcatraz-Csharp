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
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class GameForm : Form
    {
        Thread thread;
        char[,] prison = new char[Constants.MATRIX_H, Constants.MATRIX_W];
        int prisonerX;
        int prisonerY;
        Key[] keys = new Key[4];
        int keys_count = 0;
        int[] locks = new int[8];
        int locks_count = 0;
        int exitX;
        int exitY;

        public GameForm()
        {
            InitializeComponent();
            KeyPreview = true;
            
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            PrisonMapPanel.Size = new System.Drawing.Size(Constants.MATRIX_W * Constants.IMG_SIZE, Constants.MATRIX_H * Constants.IMG_SIZE);
            PrisonMapPanel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 - (PrisonMapPanel.Width / 2), Constants.GAME_MARGIN_UP);

            BackFromGame2MenuButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            BackFromGame2MenuButton.Location = new System.Drawing.Point(Constants.MARGIN_BACK2MENU, Screen.PrimaryScreen.Bounds.Height - (BackFromGame2MenuButton.Height + Constants.MARGIN_BACK2MENU));
           
            RestartLvlButton.Size = new System.Drawing.Size(Constants.MENU_BUTTON_WIDTH, Constants.MENU_BUTTON_HEIGHT);
            RestartLvlButton.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - (RestartLvlButton.Width + Constants.MARGIN_BACK2MENU), Screen.PrimaryScreen.Bounds.Height - (RestartLvlButton.Height + Constants.MARGIN_BACK2MENU));

            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            string level = System.IO.File.ReadAllText(path);
            
            StartLevel(level);

        }
        private void StartLevel(string level)
        {
            locks_count = 0;
            keys_count = 0;
            CurrentLevelLabel.Text = (level + "/" + Constants.MAX_LEVEL);
            CurrentLevelLabel.Font = new System.Drawing.Font("Mistral", 52F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            CurrentLevelLabel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - (CurrentLevelLabel.Width + Constants.MARGIN_CURRENT_LEVEL), Constants.MARGIN_CURRENT_LEVEL);

            //read matrix & init pictureBoxes
            PictureBox[] boxes = {
              pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
              pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20,
              pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,
              pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36, pictureBox37, pictureBox38, pictureBox39, pictureBox40,
              pictureBox41, pictureBox42, pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48, pictureBox49, pictureBox50,
              pictureBox51, pictureBox52, pictureBox53, pictureBox54, pictureBox55, pictureBox56, pictureBox57, pictureBox58, pictureBox59, pictureBox60,
              pictureBox61, pictureBox62, pictureBox63, pictureBox64, pictureBox65, pictureBox66, pictureBox67, pictureBox68, pictureBox69, pictureBox70,
              pictureBox71, pictureBox72, pictureBox73, pictureBox74, pictureBox75, pictureBox76, pictureBox77, pictureBox78, pictureBox79, pictureBox80,
              pictureBox81, pictureBox82, pictureBox83, pictureBox84, pictureBox85, pictureBox86, pictureBox87, pictureBox88, pictureBox89, pictureBox90,
              pictureBox91, pictureBox92, pictureBox93, pictureBox94, pictureBox95, pictureBox96, pictureBox97, pictureBox98, pictureBox99, pictureBox100,
              pictureBox101, pictureBox102, pictureBox103, pictureBox104, pictureBox105, pictureBox106, pictureBox107, pictureBox108, pictureBox109, pictureBox110,
              pictureBox111, pictureBox112, pictureBox113, pictureBox114, pictureBox115, pictureBox116, pictureBox117, pictureBox118, pictureBox119, pictureBox120,
              pictureBox121, pictureBox122, pictureBox123, pictureBox124, pictureBox125, pictureBox126, pictureBox127, pictureBox128,
            };

            string pathOfMap = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/" + level + ".txt");
            string[] prisonTMP = File.ReadAllLines(pathOfMap);

            int counter = 0;
            for (int i = 0; i < Constants.MATRIX_H; i++)
            {
                for (int j = 0; j < Constants.MATRIX_W; j++)
                {
                    prison[i, j] = prisonTMP[i].ElementAt(j);

                    boxes[counter].Size = new System.Drawing.Size(Constants.IMG_SIZE, Constants.IMG_SIZE);
                    boxes[counter].Location = new System.Drawing.Point(j * Constants.IMG_SIZE, i * Constants.IMG_SIZE);
                    boxes[counter].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

                    counter++;
                }
            }
            
            // location
            for (int i = 0; i < Constants.MATRIX_H; i++)
            {
                for (int j = 0; j < Constants.MATRIX_W; j++)
                {
                    if (prison[i, j] == 'e')
                    {
                        exitX = j;
                        exitY = i;
                    }
                    else if (prison[i, j] == 'k')
                    {
                        keys[keys_count] = new Key(keys_count, j, i);  // [ ID X Y ]
                        keys_count++;
                    }
                    else if (prison[i, j] == 'l')
                    {
                        locks[locks_count++] = j; // [ X Y ]
                        locks[locks_count++] = i; 
                    }
                    else if (prison[i, j] == 'p')
                    {
                        prisonerX = j;
                        prisonerY = i;
                    }

                }
            }

            DisplayPrison(boxes);
        }

        private void BackFromGame2MenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(OpenNewFormWithMenu);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void DisplayPrison(PictureBox[] boxes)
        {
            int counter = 0;
            for (int i = 0; i < Constants.MATRIX_H; i++)
            {
                for (int j = 0; j < Constants.MATRIX_W; j++)
                {
                    if (prison[i, j] == 'g')
                    {
                        boxes[counter].BackgroundImage = null;
                    }
                    else if (prison[i, j] == 'w')
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.wall_icon;
                    }
                    else if (prison[i, j] == 'e')
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.exit_icon;
                    }
                    else if (prison[i, j] == 's')
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.start_icon;
                    }
                    else if (prison[i, j] == 'k')
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.key_icon;
                    }
                    else if (prison[i, j] == 'K') //Key in padlock
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.keyOK_icon;
                    }
                    else if (prison[i, j] == 'l')
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.lock_icon;
                    }
                    else if (prison[i, j] == 'p')
                    {
                        boxes[counter].BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.prisoner_icon;
                    }

                    counter++;
                }
            }

        }

        private void OpenNewFormWithMenu(object obj)
        {
            Application.Run(new MenuForm());
        }

        private void RestartLvlButton_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            string level = System.IO.File.ReadAllText(path);

            StartLevel(level);
        }
        
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                MoveItems('W');
            }
            else if (e.KeyCode == Keys.S)
            {
                MoveItems('S');
            }
            else if (e.KeyCode == Keys.A)
            {
                MoveItems('A');
            }
            else if (e.KeyCode == Keys.D)
            {
                MoveItems('D');
            }
        }
        
        private void MoveItems(char direction)
        {
            PictureBox[] boxes = {
              pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
              pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20,
              pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,
              pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36, pictureBox37, pictureBox38, pictureBox39, pictureBox40,
              pictureBox41, pictureBox42, pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48, pictureBox49, pictureBox50,
              pictureBox51, pictureBox52, pictureBox53, pictureBox54, pictureBox55, pictureBox56, pictureBox57, pictureBox58, pictureBox59, pictureBox60,
              pictureBox61, pictureBox62, pictureBox63, pictureBox64, pictureBox65, pictureBox66, pictureBox67, pictureBox68, pictureBox69, pictureBox70,
              pictureBox71, pictureBox72, pictureBox73, pictureBox74, pictureBox75, pictureBox76, pictureBox77, pictureBox78, pictureBox79, pictureBox80,
              pictureBox81, pictureBox82, pictureBox83, pictureBox84, pictureBox85, pictureBox86, pictureBox87, pictureBox88, pictureBox89, pictureBox90,
              pictureBox91, pictureBox92, pictureBox93, pictureBox94, pictureBox95, pictureBox96, pictureBox97, pictureBox98, pictureBox99, pictureBox100,
              pictureBox101, pictureBox102, pictureBox103, pictureBox104, pictureBox105, pictureBox106, pictureBox107, pictureBox108, pictureBox109, pictureBox110,
              pictureBox111, pictureBox112, pictureBox113, pictureBox114, pictureBox115, pictureBox116, pictureBox117, pictureBox118, pictureBox119, pictureBox120,
              pictureBox121, pictureBox122, pictureBox123, pictureBox124, pictureBox125, pictureBox126, pictureBox127, pictureBox128,
            };
            bool haveKey = false;


            if (direction == 'W')
            {
                if (prisonerX == exitX && prisonerY == exitY && exitY == 0)
                    NextLevel();
                if ((prison[prisonerY - 1, prisonerX] == 'k' || prison[prisonerY - 1, prisonerX] == 'K') && (prison[prisonerY - 2, prisonerX] == 'l' || prison[prisonerY - 2, prisonerX] == 'g'))
                {
                    prison[prisonerY - 1, prisonerX] = 'g';
                    prison[prisonerY - 2, prisonerX] = 'k';

                    SetLocationKey(GetIdKey(prisonerY - 1, prisonerX), prisonerY - 2, prisonerX);
                    haveKey = true;
                }
                if (prison[prisonerY - 1, prisonerX] == 'g' || prison[prisonerY - 1, prisonerX] == 'l')
                {
                    MovePrisoner(prisonerY * Constants.MATRIX_W + prisonerX, direction, boxes, haveKey);
                    SetLocationPrisoner(prisonerY - 1, prisonerX);
                }
            }
            else if (direction == 'S')
            {
                if (prisonerX == exitX && prisonerY == exitY && exitY == Constants.MATRIX_H - 1)
                    NextLevel();
                if ((prison[prisonerY + 1, prisonerX] == 'k' || prison[prisonerY + 1, prisonerX] == 'K') && (prison[prisonerY + 2, prisonerX] == 'l' || prison[prisonerY + 2, prisonerX] == 'g'))
                {
                    prison[prisonerY + 1, prisonerX] = 'g';
                    prison[prisonerY + 2, prisonerX] = 'k';

                    SetLocationKey(GetIdKey(prisonerY + 1, prisonerX), prisonerY + 2, prisonerX);
                    haveKey = true;
                }
                if (prison[prisonerY + 1, prisonerX] == 'g' || prison[prisonerY + 1, prisonerX] == 'l' )
                {
                    MovePrisoner(prisonerY * Constants.MATRIX_W + prisonerX, direction, boxes, haveKey);
                    SetLocationPrisoner(prisonerY + 1, prisonerX);
                }
            }
            else if (direction == 'A')
            {
                if (prisonerX == exitX && prisonerY == exitY && exitX == 0)
                    NextLevel();
                if ((prison[prisonerY, prisonerX - 1] == 'k' || prison[prisonerY, prisonerX - 1] == 'K') && (prison[prisonerY, prisonerX - 2] == 'l' || prison[prisonerY, prisonerX - 2] == 'g'))
                {
                    prison[prisonerY, prisonerX - 1] = 'g';
                    prison[prisonerY, prisonerX - 2] = 'k';

                    SetLocationKey(GetIdKey(prisonerY, prisonerX - 1), prisonerY, prisonerX - 2);
                    haveKey = true;
                }
                if (prison[prisonerY, prisonerX - 1] == 'g' || prison[prisonerY, prisonerX - 1] == 'l' )
                {
                    MovePrisoner(prisonerY * Constants.MATRIX_W + prisonerX, direction, boxes, haveKey);
                    SetLocationPrisoner(prisonerY, prisonerX - 1);
                }
            }
            else if (direction == 'D')
            {
                if (prisonerX == exitX && prisonerY == exitY && exitX == Constants.MATRIX_W - 1)
                    NextLevel();
                if ((prison[prisonerY, prisonerX + 1] == 'k' || prison[prisonerY, prisonerX + 1] == 'K') && (prison[prisonerY, prisonerX + 2] == 'l' || prison[prisonerY, prisonerX + 2] == 'g'))
                {
                    prison[prisonerY, prisonerX + 1] = 'g';
                    prison[prisonerY, prisonerX + 2] = 'k';

                    SetLocationKey(GetIdKey(prisonerY, prisonerX + 1), prisonerY, prisonerX + 2);
                    haveKey = true;
                }
                if (prison[prisonerY, prisonerX + 1] == 'g' || prison[prisonerY, prisonerX + 1] == 'l')
                {
                    MovePrisoner(prisonerY * Constants.MATRIX_W + prisonerX, direction, boxes, haveKey);
                    SetLocationPrisoner(prisonerY, prisonerX + 1);
                }
            }
            if (prisonerX != exitX)
                CheckWin();
            ShowLock();
            DisplayPrison(boxes);
           
        }

        private void MovePrisoner(int which, char direction, PictureBox[] boxes, bool haveKey)
        {
            if (direction == 'W')
            {
                for (int i = 0; i < Constants.NUMBER_OF_STEPS; i++)
                {
                    if (haveKey)
                    {
                        boxes[which - Constants.MATRIX_W].BringToFront();
                        boxes[which - Constants.MATRIX_W].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, (prisonerY - 1) * Constants.IMG_SIZE - (Constants.DISTANCE_TO_MOVE * i));
                    }
                    boxes[which].BringToFront();
                    boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE - (Constants.DISTANCE_TO_MOVE * i));
                    Thread.Sleep(Constants.TIME_TO_MOVE);
                }

                prison[prisonerY, prisonerX] = 'g';
                prison[prisonerY - 1, prisonerX] = 'p';
                DisplayPrison(boxes);
                if (haveKey)
                    boxes[which - Constants.MATRIX_W].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, (prisonerY - 1) * Constants.IMG_SIZE);
                boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE);
            }
            else if (direction == 'S')
            {
                for (int i = 0; i < Constants.NUMBER_OF_STEPS; i++)
                {
                    if(haveKey)
                    { 
                        boxes[which + Constants.MATRIX_W].BringToFront();
                        boxes[which + Constants.MATRIX_W].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, (prisonerY + 1) * Constants.IMG_SIZE + (Constants.DISTANCE_TO_MOVE * i));
                    }
                    boxes[which].BringToFront();
                    boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE + (Constants.DISTANCE_TO_MOVE * i));
                    Thread.Sleep(Constants.TIME_TO_MOVE);
                }

                prison[prisonerY, prisonerX] = 'g';
                prison[prisonerY + 1, prisonerX] = 'p';
                DisplayPrison(boxes);
                if(haveKey)
                    boxes[which + Constants.MATRIX_W].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, (prisonerY + 1) * Constants.IMG_SIZE);
                boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE);
            }
            else if(direction == 'A')
            {
                for (int i = 0; i < Constants.NUMBER_OF_STEPS; i++)
                {
                    if (haveKey)
                    {
                        boxes[which - 1].BringToFront();
                        boxes[which - 1].Location = new System.Drawing.Point((prisonerX - 1) * Constants.IMG_SIZE - (Constants.DISTANCE_TO_MOVE * i), prisonerY * Constants.IMG_SIZE);
                    }
                    boxes[which].BringToFront();
                    boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE - (Constants.DISTANCE_TO_MOVE * i), prisonerY * Constants.IMG_SIZE);
                    Thread.Sleep(Constants.TIME_TO_MOVE);
                }

                prison[prisonerY, prisonerX] = 'g';
                prison[prisonerY, prisonerX - 1] = 'p';
                DisplayPrison(boxes);
                if (haveKey)
                    boxes[which - 1].Location = new System.Drawing.Point((prisonerX - 1) * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE);
                boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE);
            }
            else if (direction == 'D')
            {
                for (int i = 0; i < Constants.NUMBER_OF_STEPS; i++)
                {
                    if (haveKey)
                    {
                        boxes[which + 1].BringToFront();
                        boxes[which + 1].Location = new System.Drawing.Point((prisonerX + 1) * Constants.IMG_SIZE + (Constants.DISTANCE_TO_MOVE * i), prisonerY * Constants.IMG_SIZE);
                    }
                    boxes[which].BringToFront();
                    boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE + (Constants.DISTANCE_TO_MOVE * i), prisonerY * Constants.IMG_SIZE);
                    Thread.Sleep(Constants.TIME_TO_MOVE);
                }
                
                prison[prisonerY, prisonerX] = 'g';
                prison[prisonerY, prisonerX + 1] = 'p';
                DisplayPrison(boxes);
                if (haveKey)
                    boxes[which + 1].Location = new System.Drawing.Point((prisonerX + 1) * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE);
                boxes[which].Location = new System.Drawing.Point(prisonerX * Constants.IMG_SIZE, prisonerY * Constants.IMG_SIZE);
            }
        }

        private void CheckWin()
        {
            int win = 0;
            for (int i = 0; i < locks_count; i+=2)
            {
                for (int j = 0; j < keys_count; j++)
                {
                    if (locks[i] == keys[j].X && locks[i + 1] == keys[j].Y)
                    {
                        win++;
                        prison[keys[j].Y, keys[j].X] = 'K';
                    }
                }

            }

            if(win == keys_count)
                prison[exitY, exitX] = 'g';
            else
                prison[exitY, exitX] = 'e';

        }

        private void ShowLock()
        {
            for (int i = 0; i < locks_count; i += 2)
            {
                bool isClear = true;

                if (locks[i] == prisonerX && locks[i + 1] == prisonerY)
                    isClear = false;
                for (int j = 0; j < keys_count; j++)
                {
                    if (locks[i] == keys[j].X && locks[i + 1] == keys[j].Y)
                    {
                        isClear = false;
                        break;
                    }
                }

                if (isClear)
                    prison[locks[i + 1], locks[i]] = 'l';

            }
        }

        private void NextLevel()
        {
            string path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/level.txt");
            string pathSelectLevel = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), @"Lib/maxLevel.txt");
            string level = System.IO.File.ReadAllText(path);

            if (Int32.Parse(level) == Constants.MAX_LEVEL)
            {
                MessageBox.Show("Congratulations! You escaped from prison!");
                this.Close();
                thread = new Thread(OpenNewFormWithMenu);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Congratulations! You got another room. Take on a new challenge.");

                System.IO.File.WriteAllText(path, (Int32.Parse(level) + 1).ToString());
                if(Int32.Parse(System.IO.File.ReadAllText(pathSelectLevel)) < Int32.Parse(level) + 1)
                    System.IO.File.WriteAllText(pathSelectLevel, (Int32.Parse(level) + 1).ToString());

                level = System.IO.File.ReadAllText(path);
                StartLevel(level);
            }
        }

        private int GetIdKey(int y, int x)
        {
            for (int i = 0; i < keys_count; i++)
            {
                if (keys[i].X == x && keys[i].Y == y)
                    return keys[i].ID;
            }
            return 0;
        }

        private void SetLocationKey(int id, int y, int x)
        {
            keys[id].X = x;
            keys[id].Y = y;
        }

        private void SetLocationPrisoner(int y, int x)
        {
            prisonerX = x;
            prisonerY = y;
        }

    }
}
