namespace TicTacToeHayes
{
    public class Player
    {
        private char marker;

        // Create a player, defined by their marker.
        public Player(char marker)
        {
            // Set default marker.
            Marker = marker;
        }

        // Getters and Setters
        public char Marker
        {
            get { return marker; }
            set { marker = value; }
        }
    }
}