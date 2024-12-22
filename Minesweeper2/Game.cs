using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Minesweeper2
{
    public partial class Game : Form

    {
        static int width=0; //number of columns of the game grid; number of buttons horizontally
        static int height=0; //number of rows of the game grid; number of buttons vertically
        int distanceBetweenButtons = 35;


        // used to ensure user will not lose the game on the first turn
        bool isFirstClick = true;

        // two-dimensional array which stores FieldButton objects (generated buttons the user interacts with)
        // in the current game grid
        FieldButton[,] field = new FieldButton[width, height];

        // related to the game win condition
        int cellsOpened = 0;
        int bombs; // total number of bombs

        // elapsed game time
        Stopwatch stopwatch;

        //current player name
        string plname;

        // used for saving a game result in csv
        readonly char separator = ',';

        bool isWin = false;
        bool isLost = false;

        public Game(string playerName)
        {
            InitializeComponent();

          // get player name from Initial form
           plname = playerName;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
            this.Icon = Properties.Resources.bomb;

            //Welcome message for the current user
            lblName.Text = "Здравей, " + plname + " !" + " Стартирай играта когато си готов/a!";
            lblPlayerName.Text = "Играч: " + plname;
            stopwatch = new Stopwatch();
            
        }

        public void GenerateField(int width, int height, int bombsWanted, int plusRegion)
        {
            //Hide welcome message
            lblName.Visible = false;

            //set number of buttons in the game grid
            field = new FieldButton[width, height];

            Random random = new Random();

            // draw buttons
            for (int x = 10; (x - 10) < width * distanceBetweenButtons; x += distanceBetweenButtons)
            {
                for (int y = 100; (y - 100) < height * distanceBetweenButtons; y += distanceBetweenButtons)
                {
                    FieldButton newButton = new FieldButton();
                    newButton.Location = new Point(x, y); //determines where button is drawn on the form
                    newButton.Size = new Size(30, 30); // each button is 30x30 square
                    newButton.isClickable = true;

                   //Randomly assign bombs while ensuring the correct number of bombs is placed

                   int number = random.Next(0,(width*height)+1); //Generates a random number between 0 and width*height (inclusive)
                    if (number <= bombsWanted+plusRegion)
                    {
                        if (bombs!=bombsWanted) //ensures the total number of bombs does not exceed bombsWanted
                        {
                            newButton.isBomb = true;
                            bombs++; // count bombs
                        }
                      

                    }
                    lblNumberOfBombs.Text = " " + "Брой бомби: " + bombs;


                    //set location for the current button in the array (its column and row)
                    newButton.xIndex = (x - 10) / distanceBetweenButtons;
                    newButton.yIndex = (y - 100) / distanceBetweenButtons;

                    Controls.Add(newButton);

                    // set event listener for button click
                    newButton.MouseUp += new MouseEventHandler(FieldButtonClick);

                    //save current button in the field array with its data
                    field[(x - 10) / distanceBetweenButtons, (y - 100) / distanceBetweenButtons] = newButton;
                }
            }
        }

        void FieldButtonClick(object sender, MouseEventArgs e)
        {
            // detect the clicked button
            FieldButton clickedButton = (FieldButton)sender;

            //left mouse button clicked
            if (e.Button == MouseButtons.Left && clickedButton.isClickable)
            {
                if (clickedButton.isBomb)
                {
                    if (isFirstClick && bombs!=1)
                    {
                        clickedButton.isBomb = false;
                        isFirstClick = false;
                                             
                        bombs--; 
                        lblNumberOfBombs.Text = " " + "Брой бомби: " + bombs;

                        OpenRegion(clickedButton.xIndex, clickedButton.yIndex, clickedButton);
                    }
                    else
                    {
                        Explode();

                    }

                }
                else
                {
                    clickedButton.BackColor = Color.LightGreen;
                    EmptyFieldButtonClick(clickedButton);
                }

                isFirstClick = false;
            }

            //right mouse button click
            if (e.Button == MouseButtons.Right)
            {
                //switch between clickable and unclickable depending on if user has marked a potential bomb
                clickedButton.isClickable = !clickedButton.isClickable;

                if (!clickedButton.isClickable)
                {
                        ImageList imageList = new ImageList();
                        imageList.Images.Add(Properties.Resources.flag);
                        imageList.ImageSize = new Size(10, 10);
                        clickedButton.ImageList = imageList;
                        clickedButton.ImageIndex = 0; 
                }
                else
                {
                        clickedButton.ImageList = null;
                }
            }
            CheckWin();
        }
            void Explode()
            {
            if (isWin)
            {
                return;
            }
            else
            {
                //обхождаме създадения масив, съдържащ съдържанието на вс от бутоните
                // и показваме всички бомби
                foreach (FieldButton button in field)
                {
                    if (button.isBomb)
                    {
                        isLost = true;
                        button.BackColor = Color.IndianRed;

                        ImageList imageList = new ImageList();
                        imageList.Images.Add(Properties.Resources.bomb);
                        imageList.ImageSize = new Size(10, 10); // размер който искам
                        button.ImageList = imageList;
                        button.ImageIndex = 0;
                    }
                }
                stopwatch.Stop();
                MessageBox.Show("Загуба", "Резултат");
                lblResult.Text = "резултат: загуба";
                btnSaveResult.Enabled = true;
            }
              
            
        }

            void EmptyFieldButtonClick(FieldButton clickedButton)
            { 
               //iterate through buttons array to find coordinates (location) of the clicked one
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (field[x, y] == clickedButton)
                        {
                            OpenRegion(x, y, clickedButton);
                        }
                    }
                }

                
            }


        //Reveals a clicked cell (which is not a bomb - the method is called only in these cases)
        //If it has 0 neigbouring bombs, its surrounding neighbours (and their neighbours) are also revealed 
        void OpenRegion(int xIndex, int yIndex, FieldButton clickedButton)
        {
            Queue<FieldButton> queue = new Queue<FieldButton>();
            queue.Enqueue(clickedButton);
            clickedButton.wasAdded = true; //Ensures buttons are processed only once

            while (queue.Count > 0)
            {

                FieldButton currentCell = queue.Dequeue();

                OpenCell(currentCell.xIndex, currentCell.yIndex, currentCell);

                if (isLost != true && isWin != true)
                {
                    cellsOpened++;
                }
               

                if (CountBombsAround(currentCell.xIndex, currentCell.yIndex) == 0)
                {
                    for (int x = currentCell.xIndex - 1; x <= currentCell.xIndex + 1; x++)
                    {
                        for (int y = currentCell.yIndex - 1; y <= currentCell.yIndex + 1; y++)
                        {
                            //ensure we stay within bounds
                            if (x >= 0 && x < width && y >= 0 && y < height)
                            {
                              
                                if (x==currentCell.xIndex && y==currentCell.yIndex)
                                {
                                    continue; //skip adding the current button in the queue, because it is already opened at the beginning of the while loop
                                }
                                if (!field[x, y].wasAdded)
                                {
                                    queue.Enqueue(field[x, y]);
                                    field[x, y].wasAdded = true;
                                }

                            }
                        }
                    }
                }
            }
            
        }

        //Reveals the content of a single button
        void OpenCell(int x, int y, FieldButton currentCell)
        {
            int bombsAround = CountBombsAround(x, y);

            if (bombsAround == 0)
            {
               currentCell.BackColor = Color.LightGreen;
            }
            else
            {
                currentCell.BackColor = Color.LightGreen;
                currentCell.Text = "" + bombsAround;
            }

            //disable button to prevent further interaction
            currentCell.Enabled = false;
        }


        //Counts the number of bombs surrounding a button at position(xB, yB).
        int CountBombsAround(int xB, int yB)
        {
            int bombCount = 0;

            //Iterate through neighboring buttons(up to 8) and check if they contain bombs
            for (int x = xB - 1; x <= xB + 1; x++)
            {
                for (int y = yB - 1; y <= yB + 1; y++)
                {
                    //for buttons on the edge, diagonal neighbours may not exist
                    //ensure we stay within bounds
                    if (x >= 0 && x < width && y >= 0 && y < height)
                    {
                        if (field[x, y].isBomb)
                        {
                            bombCount++;
                        }
                    }

                }
            }
            return bombCount;
        }

        

        void CheckWin()
        {
            if (isLost)
            {
                return;
            }
            else if (cellsOpened == (width * height) - bombs) 
            {
                isWin =true;
                stopwatch.Stop();
                MessageBox.Show("Победа!", "Резултат");
                lblResult.Text = "резултат: победа";
                btnSaveResult.Enabled = true;
                
            }
        }


        //Removes all buttons from the form, clearing the grid
        //Used when restarting or switching difficulty levels
        void RemoveButtons()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    this.Controls.Remove(field[row, col]);
                }

            }
        }


        //Difficulty levels
        private void firstLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
        
            this.Text = "Ниво на трудност: ниско";
            width = 5;
            height = 5;
            this.Width = 510;
            this.Height = 320;

            //determine if this is the first time the grid is being generated
            //for the current game instance
            if (field.Length == 0)
            {
                GenerateField(width, height,5,2);
               
            }
            else
            {
                RestartInitialValuesOfVariables();
                GenerateField(width, height,5,2);
            }
        }

        private void secondLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopwatch.Start();

            this.Text = "Ниво на трудност: средно";
            
            width = 10;
            height = 10;
            this.Width = 510;
            this.Height = 500;
            if (field.Length == 0)
            {

                GenerateField(width, height,10,5);
            }
            else
            {
                RestartInitialValuesOfVariables();
                GenerateField(width, height,10,5);
            }
        }

        private void thirdLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopwatch.Start();

            this.Text = "Ниво на трудност: високо";
            width = 15;
            height = 15;
            this.Width = 600;
            this.Height = 665;
            if (field.Length == 0)
            {
                GenerateField(width, height,15,9);
            }
            else
            {
                RestartInitialValuesOfVariables();
                GenerateField(width, height,15,9);
            }
        }


        //Clear the grid
        //Reset bomb count, opened cells and timer
        //Disables the save result button until the game is finished

        void RestartInitialValuesOfVariables()
        {
            
            RemoveButtons();
            bombs = 0;
            isFirstClick = true; 
            stopwatch.Reset();
            stopwatch.Start();
            lblResult.Text = "резултат: ";
            btnSaveResult.Enabled = false;
            isWin = false;
            isLost = false;
            cellsOpened = 0;
        }


        //Update timer label with the elapsed time
        //Format the output
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = string.Format("{0:hh\\:mm\\:ss\\:fff}", stopwatch.Elapsed);
        }


        //Save game result to a file
        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            string result = lblResult.Text;
            
            string time = lblTime.Text;

            saveResult.DefaultExt = ".txt";
            saveResult.Filter = "Text file| *.txt ";
            saveResult.Title = "Запазване на резултат ...";
            //default file name
            saveResult.FileName = "myMinesweeperResult";

            if (saveResult.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveResult.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("играч: " + plname + separator + " " + result + separator + " брой бомби: " + bombs + separator + " размер на полето: " + width + " x " + height + separator + " отворени клетки: " + cellsOpened + separator + " времетраене: " + time);
                    }
                }
                //disable save results button, after saving current game result once
                btnSaveResult.Enabled = false;
            }
            
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Сигурни ли сте, че искате да напуснете Minesweeper ", "С това действие ще затворите приложението!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                // cancel FormClosing event
                e.Cancel = true;
            } else
            {
                // Access the main form (InitialForm) to stop application
                Application.OpenForms[0].Close();
            }
        }


        //Display information about the maximum bomb count for each difficulty level
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Най-големият възможен брой бомби при ниво:"+ Environment.NewLine +"- 5х5 е: 5" + Environment.NewLine + 
                "- 10х10 е: 10" 
                + Environment.NewLine + "- 15х15 е: 15", "Информация за нивата", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
        }

        //Show the rules of the Minesweeper game
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameRules gameRules = new GameRules();
            gameRules.ShowDialog();
        }
    }


    //Custom class which represents a button in the Minesweeper game grid
    public class FieldButton: Button
    {
        public bool isBomb;
        public bool isClickable;
        public bool wasAdded; // tracks if the current button has been processed in OpenRegion()
        public int xIndex; // current button column index
        public int yIndex; // current button row index
    }
}
