/*  QGardinAssignment3.cs
 *  
 *  N-Tile Game.
 *  
 *  Revision History:
 *      Quinn Gardin, 2017.11.30: Created
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QGardinAssignment3
{

    /// <summary>
    /// MainForm Class for Assignment3
    /// </summary>
    public partial class MainForm : Form
    {

        //Variable Declarations;
        Tile [,] gameBoard;
        bool gameCreated = false;
        string currentSolution;


        /// <summary>
        /// Initializes Main Form Component
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event Handler For Main Form Loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Clears Current Board State for Re-creating
        /// </summary>
        public void clearBoard()
        {
            if(gameCreated == true)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    for (int i = 0; i < gameBoard.GetLength(0); i++)
                    {
                        this.Controls.Remove(gameBoard[i, j]);
                    }
                }
            }
            
        }


        /// <summary>
        /// Generate A Global Tile array to use for board generation
        /// </summary>
        public void createGameBoardArray()
        {
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);

            int currentVal = 1;
            int maxVal = x * y;

            gameBoard = new Tile[x, y];

            for (int i = 0; i < gameBoard.GetLength(1); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(0); j++)
                {
                    gameBoard[j, i] = new Tile(currentVal);

                    if(currentVal<maxVal-1)
                    {
                        currentVal = currentVal + 1;
                    }
                    else
                    {
                        currentVal = 0;
                    }
                }
            }
        }


        /// <summary>
        /// Create Game Board Using Global Tile Array
        /// </summary>
        /// <param name="boardTiles"></param>
        public void createGameBoard(Tile [,] boardTiles)
        {
            const int TILE_SIZE = 50;
            const int PLAYFIELD_X = 0;
            const int PLAYFIELD_Y = 100;

            int pos_x = PLAYFIELD_X;
            int pos_y = PLAYFIELD_Y;

            currentSolution = "";

            for (int i = 0; i < boardTiles.GetLength(1); i++)
            {
                for (int j = 0; j < boardTiles.GetLength(0); j++)
                {
                    boardTiles[j, i].Text = boardTiles[j, i].getValueString();
                    boardTiles[j, i].setTilePosX(j);
                    boardTiles[j, i].setTilePosY(i);
                    boardTiles[j, i].Name = "tile" + j + i;
                    boardTiles[j, i].Size = new System.Drawing.Size(TILE_SIZE, TILE_SIZE);
                    boardTiles[j, i].Location = new System.Drawing.Point(pos_x, pos_y);
                    this.Controls.Add(boardTiles[j, i]);
                    boardTiles[j, i].Click += new System.EventHandler(this.gameBoardClick);

                    currentSolution = currentSolution + boardTiles[j, i].getValueString();

                    if(boardTiles[j,i].getTileValue() == 0)
                    {
                        boardTiles[j, i].Text = "";
                    }

                    pos_x = pos_x + TILE_SIZE;
                }
                pos_x = PLAYFIELD_X;
                pos_y = pos_y + TILE_SIZE;
            }
        }
        

        /// <summary>
        /// Click Event Handler for Dynamically Generated Tile Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gameBoardClick(object sender, EventArgs e)
        {
            Tile clickedTile = (Tile)sender;
            bool tileMoved = false;

            int clickedX = clickedTile.getTilePosX();
            int clickedY = clickedTile.getTilePosY();

            //MessageBox.Show("Tile clicked: "+clickedTile.getValueString());

            if (clickedX>0)
            {
                if(gameBoard[clickedX-1,clickedY].getTileValue() == 0)
                {
                    moveLeft(clickedTile);
                    tileMoved = true;
                }
            }
            if (clickedX < gameBoard.GetLength(0) - 1 && tileMoved==false)
            {
                if (gameBoard[clickedX + 1, clickedY].getTileValue() == 0)
                {
                    moveRight(clickedTile);
                    tileMoved = true;
                }
            }
            if (clickedY > 0 && tileMoved==false)
            {
                if (gameBoard[clickedX, clickedY-1].getTileValue() == 0)
                {
                    moveUp(clickedTile);
                    tileMoved = true;
                }
            }
            if (clickedY < gameBoard.GetLength(1) - 1 && tileMoved == false)
            {
                if (gameBoard[clickedX, clickedY + 1].getTileValue() == 0)
                {
                    moveDown(clickedTile);
                    tileMoved = true;
                }
            }

            if (checkBoardWin()==true)
            {
                MessageBox.Show("Wowe you won");
            }
        }


        /// <summary>
        /// Mix Values of Current Global Tile array to start puzzle
        /// </summary>
        public void mixValues()
        {
            const int mixTimes = 100;
            Random rnd = new Random();
            int randomNumber;

            int max_x = gameBoard.GetLength(0);
            int max_y = gameBoard.GetLength(1);

            int currentZeroX = gameBoard.GetLength(0) - 1;
            int currentZeroY = gameBoard.GetLength(1) - 1;

            for (int i = 0; i < mixTimes; i++)
            {
                randomNumber = rnd.Next(1, 5);
                //MessageBox.Show("Number rolled was: " + randomNumber);
                switch (randomNumber)
                {
                    case 1:

                        if (currentZeroY > 0)
                        {
                            gameBoard[currentZeroX, currentZeroY].setTileValue(gameBoard[currentZeroX, currentZeroY - 1].getTileValue());
                            gameBoard[currentZeroX, currentZeroY].Text = gameBoard[currentZeroX, currentZeroY].getValueString();

                            gameBoard[currentZeroX, currentZeroY - 1].setTileValue(0);
                            gameBoard[currentZeroX, currentZeroY - 1].Text = "";

                            currentZeroY = currentZeroY - 1;
                        }
                        else
                        {
                            i = i - 1;
                        }
                        break;
                    case 2:
                        if(currentZeroY<max_y-1)
                        {
                            gameBoard[currentZeroX, currentZeroY].setTileValue(gameBoard[currentZeroX, currentZeroY + 1].getTileValue());
                            gameBoard[currentZeroX, currentZeroY].Text = gameBoard[currentZeroX, currentZeroY].getValueString();

                            gameBoard[currentZeroX, currentZeroY + 1].setTileValue(0);
                            gameBoard[currentZeroX, currentZeroY + 1].Text = "";

                            currentZeroY = currentZeroY + 1;
                        }
                        else
                        {
                            i = i - 1;
                        }
                        break;
                    case 3:
                        if(currentZeroX>0)
                        {
                            gameBoard[currentZeroX, currentZeroY].setTileValue(gameBoard[currentZeroX-1, currentZeroY].getTileValue());
                            gameBoard[currentZeroX, currentZeroY].Text = gameBoard[currentZeroX, currentZeroY].getValueString();

                            gameBoard[currentZeroX-1, currentZeroY].setTileValue(0);
                            gameBoard[currentZeroX-1, currentZeroY].Text = "";

                            currentZeroX = currentZeroX - 1;
                        }
                        else
                        {
                            i = i - 1;
                        }
                        break;
                    case 4:
                        if(currentZeroX<max_x-1)
                        {
                            gameBoard[currentZeroX, currentZeroY].setTileValue(gameBoard[currentZeroX + 1, currentZeroY].getTileValue());
                            gameBoard[currentZeroX, currentZeroY].Text = gameBoard[currentZeroX, currentZeroY].getValueString();

                            gameBoard[currentZeroX + 1, currentZeroY].setTileValue(0);
                            gameBoard[currentZeroX + 1, currentZeroY].Text = "";

                            currentZeroX = currentZeroX + 1;
                        }
                        else
                        {
                            i = i - 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Check if the board is in a win state
        /// </summary>
        /// <returns></returns>
        public bool checkBoardWin()
        {
            string checkString = "";
            for (int i = 0; i < gameBoard.GetLength(1); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(0); j++)
                {
                    checkString = checkString + gameBoard[j, i].getValueString();
                }
            }
            if (checkString.Equals(currentSolution))
            {
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Move selected tile up if possible
        /// </summary>
        /// <param name="selectedTile"></param>
        public void moveUp(Tile selectedTile)
        {
            try
            {
                gameBoard[selectedTile.getTilePosX(), selectedTile.getTilePosY() - 1].setTileValue(selectedTile.getTileValue());
                gameBoard[selectedTile.getTilePosX(), selectedTile.getTilePosY() - 1].Text = selectedTile.getValueString();

                selectedTile.setTileValue(0);
                selectedTile.Text = "";
            }
            catch(Exception e)
            {

            }
        }


        /// <summary>
        /// Move selected Tile left if possible
        /// </summary>
        /// <param name="selectedTile"></param>
        public void moveLeft(Tile selectedTile)
        {
            try
            {
                gameBoard[selectedTile.getTilePosX()-1, selectedTile.getTilePosY()].setTileValue(selectedTile.getTileValue());
                gameBoard[selectedTile.getTilePosX()-1, selectedTile.getTilePosY()].Text = selectedTile.getValueString();

                selectedTile.setTileValue(0);
                selectedTile.Text = "";
            }
            catch (Exception e)
            {

            }
        }


        /// <summary>
        /// Move selected Tile Down if possible
        /// </summary>
        /// <param name="selectedTile"></param>
        public void moveDown(Tile selectedTile)
        {
            try
            {
                gameBoard[selectedTile.getTilePosX(), selectedTile.getTilePosY() + 1].setTileValue(selectedTile.getTileValue());
                gameBoard[selectedTile.getTilePosX(), selectedTile.getTilePosY() + 1].Text = selectedTile.getValueString();

                selectedTile.setTileValue(0);
                selectedTile.Text = "";
            }
            catch (Exception e)
            {

            }
        }


        /// <summary>
        /// Move selected Tile Right if possible
        /// </summary>
        /// <param name="selectedTile"></param>
        public void moveRight(Tile selectedTile)
        {
            try
            {
                gameBoard[selectedTile.getTilePosX()+1, selectedTile.getTilePosY()].setTileValue(selectedTile.getTileValue());
                gameBoard[selectedTile.getTilePosX()+1, selectedTile.getTilePosY()].Text = selectedTile.getValueString();

                selectedTile.setTileValue(0);
                selectedTile.Text = "";
            }
            catch (Exception e)
            {

            }
        }


        /// <summary>
        /// Generate New Game based on size determined by text box inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(txtX.Text);
                int y = int.Parse(txtY.Text);
                
                if(x<3||x>8||y<3||y>8)
                {
                    throw new Exception();
                }           
            
                clearBoard();
                createGameBoardArray();
                createGameBoard(gameBoard);
                mixValues();
                gameCreated = true;
            }
            catch
            {
                MessageBox.Show("Must Enter X and Y as numbers from 3 to 8.");
            }

        }


        /// <summary>
        /// Save Game To File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text File | *.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                StreamWriter writer = new StreamWriter(saveFile.OpenFile());
                string arrayLine = "";

                writer.WriteLine(gameBoard.GetLength(0).ToString() + " " + gameBoard.GetLength(1).ToString());

                for (int i = 0; i < gameBoard.GetLength(1); i++)
                {
                    for (int j = 0; j < gameBoard.GetLength(0); j++)
                    {
                        arrayLine = arrayLine + gameBoard[j, i].getValueString() + " ";
                    }

                    writer.WriteLine(arrayLine);
                    arrayLine = "";
                }

                writer.WriteLine(currentSolution);

                writer.Dispose();
                writer.Close();
            }
        }


        /// <summary>
        /// Load Game From File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFile.OpenFile());

                string bufferString = "";

                while ((bufferString = reader.ReadLine())!=null)
                {

                }
            }
        }
    }
}
