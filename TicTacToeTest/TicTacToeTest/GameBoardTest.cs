using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeHayes;

namespace TicTacToeTest
{
    [TestClass]
    public class GameBoardTest
    {
        [TestMethod]
        public void boardFunctionsTest()
        {
            /**Test Board Creation**/

            // Create an empty game board.
            Board board = new Board();
            // Create dummy players.
            Player playerX = new Player('X');
            Player playerY = new Player('O');
            // Expected results, board with empty characters.
            char[,] createExpectedResult = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
            // Actual results, returns game board from board object.
            char[,] createActualResult = board.GameBoard;
            // Assert.
            CollectionAssert.AreEqual(createExpectedResult, createActualResult);

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
        public void checkRowsTest()
        {
            /**Test CheckRows Method**/

            // Create dummy player.
            Player playerX = new Player('X');
            Player playerO = new Player('O');
            // Test boards
            Board board0 = new Board(new char[3, 3] // No winner.
{
                {'O', 'O', ' ' },
                {'X', ' ', 'X' },
                {'X', ' ', ' ' }
});
            Board board1 = new Board(new char[3, 3] // Check rows.
            {
                {'O', 'O', ' ' },
                {'X', 'X', 'X' },
                {'X', ' ', ' ' }
            });
            Board board2 = new Board(new char[3, 3] // Check columns.
            {
                {'X', 'O', 'O' },
                {'X', 'X', ' ' },
                {'X', ' ', ' ' }
            });
            Board board3 = new Board(new char[3, 3] // Check left angles.
            {
                {'X', 'O', 'O' },
                {'X', 'X', ' ' },
                {'O', ' ', 'X' }
            });
            Board board4 = new Board(new char[3, 3] // Check right angles.
            {
                {'O', 'O', 'X' },
                {'X', 'X', ' ' },
                {'X', ' ', 'X' }
            });
            Board board5 = new Board(new char[3, 3] // Cat's game.
            {
                {'O', 'X', 'O' },
                {'O', 'X', 'X' },
                {'X', 'O', 'X' }
            });

            /** No Winner**/

            // Expected results, check returns false.
            bool noWinnerExpectedResult = false;
            // Actual results, from CheckBoard method.
            bool noWinnerActualResult = board0.CheckBoard(playerX);
            // Assert
            Assert.AreEqual(noWinnerExpectedResult, noWinnerActualResult);

            /** Check Rows **/

            // Expected results, 
            // X should return true,
            // O should return false.
            bool checkRowsExpectedResultX = true;
            bool checkRowsExpectedResultO = false;
            // Actual results, from CheckBoard method.
            bool checkRowsActualResultX = board1.CheckBoard(playerX);
            bool checksRowsActualResultO = board1.CheckBoard(playerO);
            // Assert
            Assert.AreEqual(checkRowsExpectedResultX, checkRowsActualResultX);
            Assert.AreEqual(checkRowsExpectedResultO, checksRowsActualResultO);
        }
    }
}
