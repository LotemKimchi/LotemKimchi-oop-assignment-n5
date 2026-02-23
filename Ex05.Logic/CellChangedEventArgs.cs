using System;

namespace Ex05.Logic
{
    public delegate void CellChangedEventHandler(object i_Sender, CellChangedEventArgs i_EventArgs);

    public class CellChangedEventArgs : EventArgs
    {
        private readonly int m_Row;
        private readonly int m_Col;
        private readonly eCellState m_NewState;

        public int Row
        {
            get { return m_Row; }
        }

        public int Col
        {
            get { return m_Col; }
        }

        public eCellState NewState
        {
            get { return m_NewState; }
        }

        public CellChangedEventArgs(int i_Row, int i_Col, eCellState i_NewState)
        {
            m_Row = i_Row;
            m_Col = i_Col;
            m_NewState = i_NewState;
        }
    }
}
