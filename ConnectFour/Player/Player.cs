namespace ConnectFour {
    
    /// <summary>
    /// Human player
    /// </summary>
    public abstract class Player : IPlayer
    {
        protected readonly int _numberOfColumns;

        protected Player(int numberOfColumns) {
            _numberOfColumns = numberOfColumns;
        }

        public abstract string Name {get;}

        public abstract int Number {get;}

        public abstract int GetNextMove();
    }
}