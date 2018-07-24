using System;

namespace TicTacToeHayes
{
    public class Board
    {
        //Fields
        private bool gameOver;
        private char[,] gameBoard;
        private int dimension = DEFAULT_DIMENSIONS;

        // Constants
        private const int DEFAULT_DIMENSIONS = 3;   // Default number of rows and columns.
        private const char NO_MARKER = ' ';        // Used to symbolize empty spot on the board.

        // Construct board object with empty game board.
        public Board()
        {
            // Generate game board.
            GameBoard = new char[Dimension, Dimension];

            // Fill game board with space character.
            ClearGameBoard();
        }

        // Construct board with test values.
        public Board(char[,] testValues)
        {
            GameBoard = testValues;
        }

        // Clear board by resetting all spaces to space character.
        public void ClearGameBoard()
        {
            GameBoard = new char[Dimension, Dimension];

            for(int row = 0; row < Dimension; row++)
            {
                for(int col = 0; col < Dimension; col++)
                {
                    GameBoard[row, col] = NO_MARKER;
                }
            }
        }

        // Adds play to game board.
        public void AddMark(Player player, int row, int col)
        {
            GameBoard[row, col] = player.Marker;
        }

        // Checks for player win, returns true if player won.
        public bool CheckBoard(Player player)
        {
            // Checks for row matching player marker.
            for(int row = 0; row < Dimension; row++)
            {
                // Column iteratable.
                int col;
                // Check current column matches..
                for(col = 0; col < Dimension; col++)
                {
                    if(!(GameBoard[row,col] == player.Marker))
                    {
                        break;
                    }
                }
                // Returns true when whole row matches.
                if(col == Dimension)
                {
                    return true;
                }
            }
            
            // Check each column for matching player marker.
            for(int col = 0; col < Dimension; col++)
            {
                // Row iterable.
                int row;
                // Check current row matches..
                for(row = 0; row < Dimension; row++)
                {
                    // Break when markers don't watch.
                    if(!(GameBoard[row,col] == player.Marker))
                    {
                        break;
                    }
                }
                // Returns true when whole column matches.
                if(row == Dimension)
                {
                    return true;
                }
            }

            // Check left-to-right angle for matching markers.
            for(int col = 0; col < Dimension;)
            {
                // Set row same as column.
                int row = col; 

                // Break when markers don't match.
                if(!(GameBoard[row,col] == player.Marker))
                {
                    break;
                }

                // Iterate column.
                col++;

                // Check if whole angle checked for matches.
                if (col == Dimension)
                {
                    // When angle matches..
                    return true;
                }
            }

            // Check right-to-left angle for matching markers.
            for(int col = Dimension - 1; col > 0;)
            {
                // Set row same as column.
                int row = col;

                // Break when markers don't match.
                if(!(GameBoard[row,col] == player.Marker))
                {
                    break;
                }

                // Iterate column.
                col--;

                // Check if whole angle checked for matches.
                if (col == 0)
                {
                    // When angle matches..
                    return true;
                }
            }

            // If no matches..
            return false;
        }

        // Properties
        public bool GameOver
        {
            get { return gameOver; }
            private set { this.gameOver = value; }
        }
        public char[,] GameBoard                    // Game Board which holds player markers.
        {
            get { return gameBoard; }
            private set { this.gameBoard = value; }
        }
        public int Dimension                        // Number of rows and columns on game board.
        {
            get { return dimension; }
            set { this.dimension = value; }
        }
    }
}