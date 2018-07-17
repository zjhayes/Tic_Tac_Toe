﻿using System;

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
        public void AddMark(char mark, int row, int col)
        {
            GameBoard[row, col] = mark;
        }

        // Returns winner, if any.
        public char CheckBoard()
        {
            return NO_MARKER;
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