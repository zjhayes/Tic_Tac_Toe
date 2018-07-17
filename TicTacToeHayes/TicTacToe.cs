
/** =========================================================
Tic-Tac-Toe
 Program Description: Tic-Tac-Toe game.
 author: Zachary Hayes
=========================================================== **/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeHayes
{
    public partial class TicTacToe : Form
    {
        // Generate random number seed.
        private Random rand = new Random();

        // Create arrays to hold player symbols and scores.
        // Add symbols to this list to add more players!
        static string[] playerSymbols = { "O", "X" };

        static int numberOfPlayers = playerSymbols.Length; // Numbers of players in game.
        static int[] playerScores;  // Create array to hold player scores.

        // Board dimensions
        const int ROWS = 3; //Rows
        const int COLS = 3; //Columns

        // Declare two-dimensional array to store game board.
        Label[,] gameBoard = new Label[ROWS, COLS];

        public TicTacToe()
        {
            InitializeComponent();
        }

        /**
         * Randomly generates a play (X or O).
         **/
        private string randomPlay()
        {
            // Generate random number, either 0 or 1.
            int decision = rand.Next(numberOfPlayers);

            // Determines if decision is X or O.
            return playerSymbols[decision];
        }

        /**
        *   Create array to represent game board using controls.
        **/
        private void generateBoard()
        {
            // Array of board controls.
            Label[] GUI_CONTROLS = {topLeft, topCenter, topRight,
                                   centerLeft, centerCenter, centerRight,
                                   bottomLeft, bottomCenter, bottomRight};

            // Counts how many times loop runs.
            int count = 0;

            // Adds play (X or O) to each spot on game board.
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    // Adds GUI control to array.
                    gameBoard[row, col] = GUI_CONTROLS[count];

                    // Adds random play to control element.
                    gameBoard[row, col].Text = randomPlay();

                    count++; // Increment count variable.
                }
            }
        }

        /**
         * Checks if player symbols in rows match.
         **/
        private void checkRows()
        {
            // Loops through every row and compares columns. 
            for (int row = 0; row < ROWS; row++)
            {
                const int COMPARISONS = COLS - 1; // Number of comparisons that need to be made.
                
                // Compares adjacent player symbols, looks for matching row.
                for (int col = 0; col < COMPARISONS; col++)
                {
                    // Holds current and adjacent symbols.
                    string current = gameBoard[row, col].Text;
                    string next = gameBoard[row, col + 1].Text;

                    // Checks if current item in row matches next item in row.
                    if (current == next)
                    {
                        // If all comparisons in a row pass, the player scores.
                        if (col == COMPARISONS - 1)
                        {
                            // Gets the index of the player who scored.
                            int scoringPlayerIndex = Array.IndexOf(playerSymbols, gameBoard[row, col].Text);

                            // Player gets a point.
                            playerScores[scoringPlayerIndex]++;

                            break;
                        }
                    }
                    else
                    {
                        // If a match isn't found, loop moves on to next row.
                        break;
                    }
                }
            }
        }

        /**
         * Checks if player symbols in column match.
         **/
        private void checkColumns()
        {
            // Loops through every column and compares row items.
            for(int col = 0; col < COLS; col++)
            {
                const int COMPARISONS = ROWS - 1; // Number of comparisons that need to be made.

                // Compares adjacent player symbols, looks for matching row.
                for (int row = 0; row < COMPARISONS; row++)
                {
                    // Holds current and adjacent symbols.
                    string current = gameBoard[row, col].Text;
                    string next = gameBoard[row + 1, col].Text;

                    // Checks if current item in row matches next item in row.
                    if (current == next)
                    {
                        // If all comparisons in a row pass, the player scores.
                        if (row == COMPARISONS - 1)
                        {
                            // Gets the index of the player who scored.
                            int scoringPlayerIndex = Array.IndexOf(playerSymbols, gameBoard[row, col].Text);

                            // Player gets a point.
                            playerScores[scoringPlayerIndex]++;

                            break;
                        }
                    }
                    else
                    {
                        // If a match isn't found, loop moves on to next row.
                        break;
                    }
                }
            }
        }

        /**
         * Checks if player symbols match on angles.
         **/
        private void checkAngles()
        {
            const int COMPARISONS = COLS - 1; // Number of comparisons that need to be made.

            // Loop through and compare symbols, starting on top left corner.
            for (int i = 0; i < COMPARISONS; i++)
            {
                // Compares symbols adjacent at angle.
                string current = gameBoard[i, i].Text;
                string next = gameBoard[i + 1, i + 1].Text;

                if (current == next)
                {
                    if(i == COMPARISONS - 1)
                    {
                        // Gets the index of the player who scored.
                        int scoringPlayerIndex = Array.IndexOf(playerSymbols, gameBoard[i, i].Text);

                        // Player gets a point.
                        playerScores[scoringPlayerIndex]++;

                        break;
                    }
                }
                else
                {
                    // If a match isn't found, loop moves on to next row.
                    break;
                }
            }
        }

         /**
         * Checks if player symbols match on angles.
         **/
        private void checkReverseAngle()
        {
            // Variable to hold column number.
            int col = COLS - 1;

            // Checks reverse angle, starting on bottom right corner.
            for (int row = 0; row < ROWS - 1; row++)
            {
                // Compares symbols adjacent at angle.
                string current = gameBoard[row, col].Text;
                string next = gameBoard[row + 1, col - 1].Text;

                // Compares items adjacent at an angle.
                if (current == next)
                {
                    // If row is equal to 1 when current and next variables are equal
                    // it means the whole angle matches.
                    if (col == 1)
                    {
                        // Gets the index of the player who scored.
                        int scoringPlayerIndex = Array.IndexOf(playerSymbols, gameBoard[row, col].Text);

                        // Player gets a point.
                        playerScores[scoringPlayerIndex]++;

                        break;
                    }

                    // Move backwards one column.
                    col--;
                }
                else
                {
                    // If a match isn't found, loop moves on to next row.
                    break;
                }
            }
        }

        /**
         * Displays the winning player on the console using a label control.
         **/
        private void displayWinner(int winnerIndex)
        {
            // If index is not -1, it is not a tie.
            if (winnerIndex != -1)
            {
                // Get symbol of winner.
                string winnerSymbol = playerSymbols[winnerIndex];

                // Display winning message.
                resultsLabel.Text = winnerSymbol + " wins!";
            }
            else
            {
                // When score is tied, displays message.
                resultsLabel.Text = "The game is a tie.";
            }

        }

        /**
         * Determines and displays game winner.
         **/
        private void determineWinner()
        {
            int winnerIndex = 0; // Index of winning player, default as first player.

            // Check for matching rows.
            checkRows();

            // Check for matching columns.
            checkColumns();

            // Check for matching angles.
            checkAngles();
            checkReverseAngle();

            // Compares scores of all players.
            for (int i = 0; i < numberOfPlayers - 1; i++)
            {
                // Checks for tie.
                if (playerScores[i] == playerScores[i + 1])
                {
                    // Sets winner index to -1 to denote a tie.
                    winnerIndex = -1;
                }
                // Keeps track of index of best score so far.
                else if (playerScores[i] < playerScores[i + 1])
                {
                    winnerIndex = i + 1;
                }
            }

            // Display winning player.
            displayWinner(winnerIndex);
        }

        /**
         * Runs the simulator.
         **/
        private void runGame()
        {
            // Initialize score array.
            playerScores = new int[numberOfPlayers];

            // Send empty game board to generate board method.
            generateBoard();

            // Determine winner of game, display results.
            determineWinner();

            //MessageBox.Show("SCORE: O " + playerScores[0] + " - X " + playerScores[1]);

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Runs the simulation.
            runGame();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
