namespace Ex05.Logic
{
    public class Board
    {
        private readonly eCellState[,] r_Grid;
        private int m_Rows;
        private int m_Cols;

        public event CellChangedEventHandler CellChanged;

        public int Rows
        {
            get { return m_Rows; }
            private set { m_Rows = value; }
        }

        public int Cols
        {
            get { return m_Cols; }
            private set { m_Cols = value; }
        }

        public Board(int i_Rows, int i_Cols)
        {
            Rows = i_Rows;
            Cols = i_Cols;
            r_Grid = new eCellState[Rows, Cols];
            clearWithoutEvents();
        }

        public Board(Board i_Other)
        {
            Rows = i_Other.Rows;
            Cols = i_Other.Cols;
            r_Grid = new eCellState[Rows, Cols];

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    r_Grid[r, c] = i_Other.r_Grid[r, c];
                }
            }
        }

        public Board Clone()
        {
            return new Board(this);
        }

        public void Clear()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (r_Grid[r, c] != eCellState.Empty)
                    {
                        r_Grid[r, c] = eCellState.Empty;
                        OnCellChanged(new CellChangedEventArgs(r, c, eCellState.Empty));
                    }
                }
            }
        }

        private void clearWithoutEvents()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    r_Grid[r, c] = eCellState.Empty;
                }
            }
        }

        public eCellState GetCellState(int i_Row, int i_Col)
        {
            return r_Grid[i_Row, i_Col];
        }

        public bool TryGetCellState(int i_Row, int i_Col, out eCellState o_State)
        {
            bool isValid = isValidIndex(i_Row, i_Col);

            if (isValid)
            {
                o_State = r_Grid[i_Row, i_Col];
            }
            else
            {
                o_State = eCellState.Empty;
            }

            return isValid;
        }

        private bool isValidIndex(int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < Rows && i_Col >= 0 && i_Col < Cols;
        }

        public bool TryDropPiece(int i_Col, eCellState i_Piece, out int o_RowPlaced)
        {
            o_RowPlaced = -1;
            bool success = false;

            if (i_Col >= 0 && i_Col < Cols)
            {
                for (int r = Rows - 1; r >= 0 && !success; r--)
                {
                    if (r_Grid[r, i_Col] == eCellState.Empty)
                    {
                        r_Grid[r, i_Col] = i_Piece;
                        o_RowPlaced = r;
                        OnCellChanged(new CellChangedEventArgs(r, i_Col, i_Piece));
                        success = true;
                    }
                }
            }

            return success;
        }

        protected virtual void OnCellChanged(CellChangedEventArgs i_EventArgs)
        {
            if (CellChanged != null)
            {
                CellChanged.Invoke(this, i_EventArgs);
            }
        }

        public bool IsColumnFull(int i_Col)
        {
            bool isColumnFull;

            if (i_Col < 0 || i_Col >= Cols)
            {
                isColumnFull = true;
            }
            else
            {
                isColumnFull = r_Grid[0, i_Col] != eCellState.Empty;
            }

            return isColumnFull;
        }

        public bool IsFull()
        {
            bool isFull = true;

            for (int c = 0; c < Cols; c++)
            {
                if (r_Grid[0, c] == eCellState.Empty)
                {
                    isFull = false;
                }
            }

            return isFull;
        }
    }
}