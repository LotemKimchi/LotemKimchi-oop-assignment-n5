using System;

namespace Ex05.Logic
{
    public class ComputerAi
    {
        private const int k_ConnectLength = 4;

        public int GetBestMove(Board i_Board, eCellState i_AiPiece, eCellState i_HumanPiece)
        {
            int bestMoveColumn = -1;
            int[] validColumns;
            int validColumnsCount;

            getValidColumns(i_Board, out validColumns, out validColumnsCount);

            if (validColumnsCount > 0)
            {
                int winningColumn;
                int blockingColumn;

                if (tryFindWinningMove(i_Board, validColumns, validColumnsCount, i_AiPiece, out winningColumn))
                {
                    bestMoveColumn = winningColumn;
                }
                else if (tryFindWinningMove(i_Board, validColumns, validColumnsCount, i_HumanPiece, out blockingColumn))
                {
                    bestMoveColumn = blockingColumn;
                }
                else
                {
                    bestMoveColumn = chooseCenterMostColumn(i_Board, validColumns, validColumnsCount);
                }
            }

            return bestMoveColumn;
        }

        private int chooseCenterMostColumn(Board i_Board, int[] i_ValidColumns, int i_ValidCount)
        {
            int chosenColumn = -1;

            if (i_ValidCount > 0)
            {
                int centerColumn = i_Board.Cols / 2;
                chosenColumn = i_ValidColumns[0];
                int bestDistance = Math.Abs(chosenColumn - centerColumn);

                for (int i = 1; i < i_ValidCount; i++)
                {
                    int currentColumn = i_ValidColumns[i];
                    int currentDistance = Math.Abs(currentColumn - centerColumn);

                    if (currentDistance < bestDistance)
                    {
                        bestDistance = currentDistance;
                        chosenColumn = currentColumn;
                    }
                }
            }

            return chosenColumn;
        }

        private void getValidColumns(Board i_Board, out int[] o_Columns, out int o_Count)
        {
            o_Columns = new int[i_Board.Cols];
            o_Count = 0;

            for (int col = 0; col < i_Board.Cols; col++)
            {
                if (!i_Board.IsColumnFull(col))
                {
                    o_Columns[o_Count] = col;
                    o_Count++;
                }
            }
        }

        private bool tryFindWinningMove(Board i_Board, int[] i_ValidColumns, int i_ValidCount, eCellState i_Piece, out int o_Column)
        {
            bool foundWinningMove = false;
            o_Column = -1;

            for (int i = 0; i < i_ValidCount && !foundWinningMove; i++)
            {
                int column = i_ValidColumns[i];
                Board simulatedBoard = i_Board.Clone();
                int rowPlaced;
                bool dropped = simulatedBoard.TryDropPiece(column, i_Piece, out rowPlaced);

                if (dropped)
                {
                    if (hasAnyWin(simulatedBoard, i_Piece))
                    {
                        foundWinningMove = true;
                        o_Column = column;
                    }
                }
            }

            return foundWinningMove;
        }

        private bool hasAnyWin(Board i_Board, eCellState i_Piece)
        {
            bool hasWin = false;

            for (int row = 0; row < i_Board.Rows && !hasWin; row++)
            {
                for (int col = 0; col < i_Board.Cols && !hasWin; col++)
                {
                    if (i_Board.GetCellState(row, col) == i_Piece)
                    {
                        if (countInLine(i_Board, row, col, 0, 1, i_Piece) >= k_ConnectLength)
                        {
                            hasWin = true;
                        }
                        else if (countInLine(i_Board, row, col, 1, 0, i_Piece) >= k_ConnectLength)
                        {
                            hasWin = true;
                        }
                        else if (countInLine(i_Board, row, col, 1, 1, i_Piece) >= k_ConnectLength)
                        {
                            hasWin = true;
                        }
                        else if (countInLine(i_Board, row, col, 1, -1, i_Piece) >= k_ConnectLength)
                        {
                            hasWin = true;
                        }
                    }
                }
            }

            return hasWin;
        }

        private int countInLine(Board i_Board, int i_Row, int i_Col, int i_DeltaRow, int i_DeltaCol, eCellState i_Piece)
        {
            int count = 1;

            count += countDirection(i_Board, i_Row, i_Col, i_DeltaRow, i_DeltaCol, i_Piece);
            count += countDirection(i_Board, i_Row, i_Col, -i_DeltaRow, -i_DeltaCol, i_Piece);

            return count;
        }

        private int countDirection(Board i_Board, int i_StartRow, int i_StartCol, int i_DeltaRow, int i_DeltaCol, eCellState i_Piece)
        {
            int count = 0;
            int scanRow = i_StartRow + i_DeltaRow;
            int scanCol = i_StartCol + i_DeltaCol;
            bool keepScanning = true;

            while (keepScanning)
            {
                eCellState state;
                bool isValid = i_Board.TryGetCellState(scanRow, scanCol, out state);

                if (isValid && state == i_Piece)
                {
                    count++;
                    scanRow += i_DeltaRow;
                    scanCol += i_DeltaCol;
                }
                else
                {
                    keepScanning = false;
                }
            }

            return count;
        }
    }
}
