namespace TicTacToeHayes
{
    public class Player
    {
        private char marker;

        // Create a player, defined by their marker.
        // param marker - takes a character to denote player marker symbol.
        public Player(char marker)
        {
            // Set default marker.
            Marker = marker;
        }

        // Getters and Setters
        public char Marker          // Player marker symbol,
        {                           // used to represent character on board.
            get { return marker; }
            set { marker = value; }
        }
    }
}