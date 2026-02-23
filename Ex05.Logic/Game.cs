namespace Ex05.Logic
{
    public class Game
    {
        private const int k_ConnectLength = 4;
        private readonly ComputerAi r_ComputerAi;

        public Board Board
        {
            get;
            private set;
        }

        public Player Player1 
        { 
            get;
            private set;
        }

        public Player Player2
        {
            get; 
            private set;
        }

        public Player CurrentPlayer
        {
            get; 
            private set;
        }

        public Player LastRoundWinner
        { 
            get; 
            private set;
        }

        public Game(int i_Rows, int i_Cols, Player i_Player1, Player i_Player2, ComputerAi i_ComputerAi)
        {
            Board = new Board(i_Rows, i_Cols);
            Player1 = i_Player1;
            Player2 = i_Player2;
            CurrentPlayer = Player1;
            LastRoundWinner = null;
            r_ComputerAi = i_ComputerAi;
        }

        public void StartNewRound()
        {
            Board.Clear();
            CurrentPlayer = Player1;
            LastRoundWinner = null;
        }

        public eMoveState PlayHumanMove(int i_Col, out int o_RowPlaced)
        {
            eMoveState result;
            o_RowPlaced = -1;

            if (CurrentPlayer.PlayerType != ePlayerType.Human)
            {
                result = eMoveState.InvalidInput;
            }
            else
            {
                result = playMoveInternal(i_Col, out o_RowPlaced);
            }

            return result;
        }

        public eMoveState PlayComputerMove(out int o_ColPlaced, out int o_RowPlaced)
        {
            eMoveState result = eMoveState.InvalidInput;

            o_RowPlaced = -1;
            o_ColPlaced = -1;

            if (CurrentPlayer.PlayerType == ePlayerType.Computer && r_ComputerAi != null)
            {
                eCellState aiPiece = CurrentPlayer.PieceType;
                eCellState humanPiece = (aiPiece == eCellState.X) ? eCellState.O : eCellState.X;

                o_ColPlaced = r_ComputerAi.GetBestMove(Board, aiPiece, humanPiece);

                if (o_ColPlaced == -1)
                {
                    result = eMoveState.Tie;
                }
                else
                {
                    result = playMoveInternal(o_ColPlaced, out o_RowPlaced);
                }
            }

            return result;
        }

        private eMoveState playMoveInternal(int i_Col, out int o_RowPlaced)
        {
            o_RowPlaced = -1;
            eMoveState playMoveInternalResult;

            if (!Board.TryDropPiece(i_Col, CurrentPlayer.PieceType, out o_RowPlaced))
            {
                playMoveInternalResult = eMoveState.ColumnFullOrOutOfRange;
            }
            else if (checkWinFromLastMove(o_RowPlaced, i_Col, CurrentPlayer.PieceType))
            {
                CurrentPlayer.AddPoint();
                LastRoundWinner = CurrentPlayer;
                playMoveInternalResult = eMoveState.Win;
            }
            else if (Board.IsFull())
            {
                playMoveInternalResult = eMoveState.Tie;
            }
            else
            {
                switchTurn();
                playMoveInternalResult = eMoveState.Dropped;
            }

            return playMoveInternalResult;
        }

        private bool checkWinFromLastMove(int i_Row, int i_Col, eCellState i_Piece)
        {
            bool win = false;

            if (countInLine(i_Row, i_Col, 0, 1, i_Piece) >= k_ConnectLength)
            {
                win = true;
            }
            else if (countInLine(i_Row, i_Col, 1, 0, i_Piece) >= k_ConnectLength)
            {
                win = true;
            }
            else if (countInLine(i_Row, i_Col, 1, 1, i_Piece) >= k_ConnectLength)
            {
                win = true;
            }
            else if (countInLine(i_Row, i_Col, 1, -1, i_Piece) >= k_ConnectLength)
            {
                win = true;
            }

            return win;
        }
        
        private void switchTurn()
        {
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }

        private int countInLine(int i_Row, int i_Col, int i_DeltaRow, int i_DeltaCol, eCellState i_Piece)
        {
            int count = 1;
            count += countDirection(i_Row, i_Col, i_DeltaRow, i_DeltaCol, i_Piece);
            count += countDirection(i_Row, i_Col, -i_DeltaRow, -i_DeltaCol, i_Piece);

            return count;
        }

        private int countDirection(int i_StartRow, int i_StartCol, int i_DeltaRow, int i_DeltaCol, eCellState i_Piece)
        {
            int count = 0;
            int scanRow = i_StartRow + i_DeltaRow;
            int scanCol = i_StartCol + i_DeltaCol;
            eCellState state;

            while (Board.TryGetCellState(scanRow, scanCol, out state) && state == i_Piece)
            {
                count++;
                scanRow += i_DeltaRow;
                scanCol += i_DeltaCol;
            }

            return count;
        }
        
        public eMoveState QuitRound()
        {
            Player otherPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
            otherPlayer.AddPoint();
            LastRoundWinner = otherPlayer;

            return eMoveState.Quit;
        }
    }
}
