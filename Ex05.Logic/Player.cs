namespace Ex05.Logic
{
    public class Player
    {
        public string Name
        {
            get;
            private set;
        }

        public int Score
        {
            get;
            private set;
        }

        public eCellState PieceType
        {
            get;
            private set;
        }

        public ePlayerType PlayerType
        {
            get;
            private set;
        }

        public Player(string i_Name, eCellState i_PieceType, ePlayerType i_PlayerType)
        {
            PlayerType = i_PlayerType;
            Name = (i_PlayerType == ePlayerType.Computer) ? "Computer" : i_Name;
            PieceType = i_PieceType;
            Score = 0;
        }
        
        public void AddPoint()
        {
            Score++;
        }
    }
}
