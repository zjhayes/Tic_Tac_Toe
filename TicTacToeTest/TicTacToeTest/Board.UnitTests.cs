using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeHayes;

namespace TicTacToeUnitTests
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void AddMark_BoardsAreEqual_AreEqual()
        {
            // Create an empty game board.
            Board board = new Board();

            // Create dummy players.
            Player playerX = new Player('X');
            Player playerY = new Player('O');

            /**Test AddMark Method**/

            // Add marks to game board.
            board.AddMark(playerX, 1, 1);
            board.AddMark(playerY, 0, 1);
            board.AddMark(playerX, 2, 0);
            board.AddMark(playerY, 0, 0);
            board.AddMark(playerX, 0, 2);

            // Expected results, updated board with marks added.
            char[,] addMarkExpectedResult = new char[3, 3]
            {
                {'O', 'O', 'X' },
                {' ', 'X', ' ' },
                {'X', ' ', ' ' }
            };

            // Actual results, returns game board from board object.
            char[,] addMarkActualResult = board.GameBoard;

            // Assert.
            CollectionAssert.AreEqual(addMarkExpectedResult, addMarkActualResult);
        }

        [TestMethod]
        public void ClearBoard_BoardCleared_AreEqual()
        {
            /** Tests whether ClearGameBoard method replaces markers with empty strings.**/

            // Test board.
            Board board = new Board(new char[3, 3] // No winner.
            {
                {'X', 'O', ' ' },
                {'X', 'X', ' ' },
                {'O', ' ', ' ' }
            });
            // Expected results, board with empty characters.
            char[,] createExpectedResult = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
            // Run method.
            board.ClearGameBoard();
            // Actual results, returns game board from board object.
            char[,] createActualResult = board.GameBoard;
            // Assert.
            CollectionAssert.AreEqual(createExpectedResult, createActualResult);
        }

        [TestMethod]
        public void CheckBoard_NoMatch_ReturnFalse()
        {
            /**Test CheckRows Method when no rows match**/

            // Create dummy player.
            Player playerX = new Player('X');
            Player playerO = new Player('O');

            // Test boards
            Board board = new Board(new char[3, 3] // No winner.
            {
                {'X', 'X', ' ' },
                {'X', 'X', 'O' },
                {'O', ' ', ' ' }
            });

            // Actual results, from CheckBoard method.
            bool noMatchActualResult = board.CheckBoard(playerX);

            // Assert
            Assert.IsFalse(noMatchActualResult);
        }

        [TestMethod]
        public void CheckBoard_RowMatch_ReturnTrue()
        {
            /**Test CheckRows Method when row matches**/

            // Create dummy player.
            Player playerX = new Player('X');

            // Test board
            Board board = new Board(new char[3, 3] // Matching row.
            {
                {'O', 'O', ' ' },
                {'X', 'X', 'X' },
                {'X', ' ', ' ' }
            });

            // Actual results, from CheckBoard method.
            bool checkRowsActualResult = board.CheckBoard(playerX);

            // Assert
            Assert.IsTrue(checkRowsActualResult);
        }

        [TestMethod]
        public void CheckBoard_ColumnMatch_ReturnTrue()
        {
            /**Test CheckBoard Method when column matches**/

            // Create dummy player.
            Player playerX = new Player('X');

            // Test board
            Board board = new Board(new char[3, 3] // Column matches.
            {
                {'X', 'O', 'O' },
                {'X', 'X', ' ' },
                {'X', ' ', ' ' }
            });

            // Actual results, from CheckBoard method.
            bool checkColumnsActualResult = board.CheckBoard(playerX);

            // Assert
            Assert.IsTrue(checkColumnsActualResult);
        }

        [TestMethod]
        public void CheckBoard_LeftAngleMatch_ReturnTrue()
        {
            /**Test CheckBoard Method when left-to-right angle matches.**/

            // Create dummy player.
            Player playerX = new Player('X');

            // Test board.
            Board board = new Board(new char[3, 3] // Check left angles.
            {
                {'X', 'O', 'O' },
                {'X', 'X', ' ' },
                {'O', ' ', 'X' }
            });

            // Actual results, from CheckBoard method.
            bool checkLeftAngleActualResult = board.CheckBoard(playerX);

            // Assert
            Assert.IsTrue(checkLeftAngleActualResult);
        }

        [TestMethod]
        public void CheckBoard_RightAngleMatch_ReturnTrue()
        {
            /**Test CheckBoard Method when right-to-left angle matches.**/

            // Create dummy player.
            Player playerx = new Player('X');

            // Test board.
            Board board = new Board(new char[3, 3] // Check right angles.
            {
                {'O', 'O', 'X' },
                {'X', 'X', ' ' },
                {'X', ' ', 'X' }
            });

            // Actual results, from CheckBoard method.
            bool checkRightAngleActualResult = board.CheckBoard(playerx);

            // Assert
            Assert.IsTrue(checkRightAngleActualResult);
        }
    }
}