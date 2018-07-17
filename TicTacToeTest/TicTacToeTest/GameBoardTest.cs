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
            board.AddMark('X', 1, 1);
            board.AddMark('O', 0, 1);
            board.AddMark('X', 2, 0);
            board.AddMark('O', 0, 0);
            board.AddMark('X', 0, 2);
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

            // Expected results, X has the most rows.
            char noWinnerExpectedResult = ' ';
            // Actual results, from CheckBoard method.
            char noWinnerActualResult = board1.CheckBoard();
            // Assert
            Assert.AreEqual(noWinnerExpectedResult, noWinnerActualResult);

            /** Check Rows

            // Expected results, X has the most rows.
            char checkRowsExpectedResult = 'X';
            // Actual results, from CheckBoard method.
            char checkRowsActualResult = board1.CheckBoard();
            // Assert
            Assert.AreEqual(checkRowsExpectedResult, checkRowsActualResult);**/
        }
    }
}
