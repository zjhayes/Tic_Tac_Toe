using System;

namespace TicTacToeHayes
{
    public class Board
    {
        //Fields
        private bool gameOver;
        private char[,] gameBoard;
        private int boardRows = DEFAULT_DIMENSIONS;
        private int boardColumns = DEFAULT_DIMENSIONS;

        // Constants
        private const int DEFAULT_DIMENSIONS = 3;   // Default number of rows and columns.
        private const char NO_MARKER = ' ';        // Used to symbolize empty spot on the board.

        // Construct board object with empty game board.
        public Board()
        {
            // Generate game board.
            GameBoard = new char[BoardRows, BoardColumns];

            // Fill game board with space character.
            ClearGameBoard();
        }

        // Construct board with test values.
        public Board(char[,] testValues)
        {
            GameBoard = testValues;
        }

        // Clear board by resetting all spaces to space character.
        private void ClearGameBoard()
        {
            GameBoard = new char[BoardRows, BoardColumns];

            for(int row = 0; row < BoardRows; row++)
            {
                for(int col = 0; col < BoardColumns; col++)
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
            for(int row = 0; row < BoardRows; row++)
            {
                // Column iteratable.
                int col;
                // Check current column matches..
                for(col = 0; col < BoardColumns; col++)
                {
                    if(!(GameBoard[row,col] == player.Marker))
                    {
                        break;
                    }
                }
                // Returns true when whole row matches.
                if(col == BoardColumns)
                {
                    return true;
                }
            }
            
            // Check each column for matching player marker.
            for(int col = 0; col < BoardColumns; col++)
            {
                // Row iterable.
                int row;
                // Check current row matches..
                for(row = 0; row < BoardRows; row++)
                {
                    // Break when markers don't watch.
                    if(!(GameBoard[row,col] == player.Marker))
                    {
                        break;
                    }
                }
                // Returns true when whole column matches.
                if(row == BoardRows)
                {
                    return true;
                }
            }

            // Check left angles for matching markers.
            for(int row = 0, col = 0; row < BoardRows; row++)
            {
                // Break when markers don't match.
                if(!(GameBoard[row,col] == player.Marker))
                {
                    break;
                }

                // Iterate column.
                col++;

                // Check if whole angle checked for matches.
                if (col == boardColumns)
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
        public int BoardRows                        // Number of rows on game board.
        {
            get { return boardRows; }
            set { this.boardRows = value; }
        }
        public int BoardColumns                     // Number of columns on game board.
        {
            get { return boardColumns; }
            set { this.boardColumns = value; }
        }
    }
}