using Ex05.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class FormGame : Form
    {
        //Board UI controls
        private Button[] m_ColumnButtons;
        private Button[,] m_CellButtons;

        //UI layout constants (pixel-perfect board):
        private const int k_CellSize = 58;
        private const int k_CellMargin = 4;
        private const int k_HeaderHeight = 30;
        private const int k_ScoreHeight = 32;
        private const int k_WindowPadding = 12;

        private readonly Game r_Game;

        public FormGame(Game i_Game)
        {
            InitializeComponent();

            //Ensure the form opens fully visible (top aligned to working area)
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Left,
                Screen.PrimaryScreen.WorkingArea.Top + 10);

            //Fixed-size window: no resize/maximize, minimize is allowed
            this.AutoSize = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            r_Game = i_Game;

            //Build UI according to the logic board size
            buildBoard(r_Game.Board.Rows, r_Game.Board.Cols);

            r_Game.Board.CellChanged += board_CellChanged;

            //Paint initial empty board
            refreshBoard();

            updateColumnButtonsEnabledState();

            //Initialize the score display
            updateScoreBoard();
        }

        private void board_CellChanged(object sender, CellChangedEventArgs e)
        {
            updateCellDisplay(e.Row, e.Col, e.NewState);
            updateColumnButtonsEnabledState();
        }

        private void updateCellDisplay(int i_Row, int i_Col, eCellState i_State)
        {
            Button cellButton = m_CellButtons[i_Row, i_Col];

            if (i_State == eCellState.Empty)
            {
                cellButton.Text = string.Empty;
                cellButton.ForeColor = SystemColors.ControlText;
            }
            else
            {
                cellButton.Text = (i_State == eCellState.X) ? "X" : "O";
                cellButton.Font = new Font(cellButton.Font.FontFamily, 14f, FontStyle.Bold);
                cellButton.ForeColor = Color.Black;
            }
        }

        private void buildBoard(int i_Rows, int i_Cols)
        {            
            //Clear any existing controls and styles
            tableLayoutPanelBoard.Controls.Clear();
            tableLayoutPanelBoard.RowStyles.Clear();
            tableLayoutPanelBoard.ColumnStyles.Clear();

            //Row 0 will be the column selection buttons (1..Cols)
            tableLayoutPanelBoard.RowCount = i_Rows + 1;
            tableLayoutPanelBoard.ColumnCount = i_Cols;

            //Set equal-size columns
            for (int c = 0; c < i_Cols; c++)
            {
                tableLayoutPanelBoard.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100f / i_Cols));
            }

            //Set equal-size rows (including the top row of column buttons)
            for (int r = 0; r < i_Rows + 1; r++)
            {
                tableLayoutPanelBoard.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100f / (i_Rows + 1)));
            }

            m_ColumnButtons = new Button[i_Cols];
            m_CellButtons = new Button[i_Rows, i_Cols];

            //Create the column buttons row (clickable)
            for (int c = 0; c < i_Cols; c++)
            {
                Button columnButton = new Button();
                columnButton.Text = (c + 1).ToString();
                columnButton.Tag = c; 
                columnButton.Dock = DockStyle.Fill;

                columnButton.Click += columnButton_Click;

                m_ColumnButtons[c] = columnButton;
                tableLayoutPanelBoard.Controls.Add(columnButton, c, 0);
            }

            //Create the board cells (disabled buttons - display only)
            for (int r = 0; r < i_Rows; r++)
            {
                for (int c = 0; c < i_Cols; c++)
                {                   
                    Button cellButton = new Button();
                    cellButton.Enabled = true;
                    cellButton.TabStop = false;
                    cellButton.Dock = DockStyle.Fill;
                    cellButton.Text = string.Empty;
                    cellButton.Cursor = Cursors.Default;

                    m_CellButtons[r, c] = cellButton;

                    //+1 row offset because row 0 is the column buttons row
                    tableLayoutPanelBoard.Controls.Add(cellButton, c, r + 1);
                }
            }

            applySquareLayoutAndFixWindow(i_Rows, i_Cols);
            centerBoard();
        }
        private void centerBoard()
        {
            int x = (panelBoardHost.ClientSize.Width - tableLayoutPanelBoard.Width) / 2;
            if (x < 0) x = 0;

            tableLayoutPanelBoard.Left = x;
            tableLayoutPanelBoard.Top = 0;
        }

        private void applySquareLayoutAndFixWindow(int i_Rows, int i_Cols)
        {
            tableLayoutPanelBoard.SuspendLayout();
            tableLayoutPanelMain.SuspendLayout();
            panelScore.SuspendLayout();

            tableLayoutPanelBoard.ColumnStyles.Clear();
            tableLayoutPanelBoard.RowStyles.Clear();

            //Create ColumnStyles
            for (int c = 0; c < i_Cols; c++)
            {
                tableLayoutPanelBoard.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Absolute, k_CellSize + k_CellMargin));
            }

            //Header row
            tableLayoutPanelBoard.RowStyles.Add(
                new RowStyle(SizeType.Absolute, k_HeaderHeight + k_CellMargin));

            //Cell rows
            for (int r = 0; r < i_Rows; r++)
            {
                tableLayoutPanelBoard.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, k_CellSize + k_CellMargin));
            }

            //Margins for all buttons
            foreach (Control ctrl in tableLayoutPanelBoard.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Margin = new Padding(k_CellMargin / 2);
                }
            }

            //Column buttons style
            for (int c = 0; c < i_Cols; c++)
            {
                m_ColumnButtons[c].FlatStyle = FlatStyle.Standard;
                m_ColumnButtons[c].UseVisualStyleBackColor = true;
                m_ColumnButtons[c].Font = new Font(Font.FontFamily, 10f, FontStyle.Bold);
            }

            //Board cells: Enabled so X/O won't be gray
            for (int r = 0; r < i_Rows; r++)
            {
                for (int c = 0; c < i_Cols; c++)
                {
                    Button cell = m_CellButtons[r, c];

                    cell.Enabled = true;
                    cell.TabStop = false;
                    cell.Cursor = Cursors.Default;

                    cell.FlatStyle = FlatStyle.Flat;
                    cell.FlatAppearance.BorderSize = 1;
                    cell.FlatAppearance.BorderColor = Color.DimGray;
                    cell.BackColor = Color.Gainsboro;
                    cell.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    cell.FlatAppearance.MouseDownBackColor = Color.Gainsboro;

                    cell.Font = new Font(Font.FontFamily, 16f, FontStyle.Bold);
                }
            }

            //calculate exact board size
            int colW = k_CellSize + k_CellMargin;
            int rowH = k_CellSize + k_CellMargin;
            int headerH = k_HeaderHeight + k_CellMargin;

            int boardWidth = i_Cols * colW;
            int boardHeight = headerH + (i_Rows * rowH);

            //remove gaps
            tableLayoutPanelMain.Padding = Padding.Empty;
            tableLayoutPanelMain.Margin = Padding.Empty;
            tableLayoutPanelBoard.Padding = Padding.Empty;
            tableLayoutPanelBoard.Margin = Padding.Empty;
            panelScore.Padding = Padding.Empty;
            panelScore.Margin = Padding.Empty;

            //make main rows exact (board + score)
            tableLayoutPanelMain.RowStyles.Clear();
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, boardHeight));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, k_ScoreHeight));

            //prevent "last column larger" by NOT stretching the board
            tableLayoutPanelBoard.Dock = DockStyle.None;
            tableLayoutPanelBoard.AutoSize = true;
            tableLayoutPanelBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelBoard.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            //set window size exact
            this.ClientSize = new Size(boardWidth + (k_WindowPadding * 2),
                boardHeight + k_ScoreHeight + (k_WindowPadding * 2));

            panelScore.ResumeLayout(true);
            tableLayoutPanelMain.ResumeLayout(true);
            tableLayoutPanelBoard.ResumeLayout(true);

            this.PerformLayout();
        }

        private void columnButton_Click(object sender, EventArgs e)
        {
            int selectedCol = (int)((Button)sender).Tag;

            //Perform a move through the logic layer
            int rowPlaced;
            eMoveState state = r_Game.PlayHumanMove(selectedCol, out rowPlaced);

            handleRoundEndIfNeeded(state);

            //If playing vs computer and round did not end - let the computer play
            if (state == eMoveState.Dropped && r_Game.CurrentPlayer.PlayerType == ePlayerType.Computer)
            {
                handleComputerTurn();
            }
        }

        private void handleComputerTurn()
        {
            int colPlaced;
            int rowPlaced;

            eMoveState state = r_Game.PlayComputerMove(out colPlaced, out rowPlaced);
            handleRoundEndIfNeeded(state);
        }

        private void handleRoundEndIfNeeded(eMoveState i_State)
        {
            if (i_State == eMoveState.Win)
            {
                updateScoreBoard();
                showEndOfRoundDialog(
                    string.Format("{0} Won!!{1}Another Round?", r_Game.LastRoundWinner.Name, Environment.NewLine),
                    "A Win!");
            }
            else if (i_State == eMoveState.Tie)
            {
                updateScoreBoard();
                showEndOfRoundDialog(
                    string.Format("Tie!!{0}Another Round?", Environment.NewLine),
                    "A Tie!");
            }
        }

        private void refreshBoard()
        {
            int rows = r_Game.Board.Rows;
            int cols = r_Game.Board.Cols;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    eCellState cellState = r_Game.Board.GetCellState(r, c);
                    updateCellDisplay(r, c, cellState);
                }
            }            
        }

        private void showEndOfRoundDialog(string i_Message, string i_Title)
        {
            DialogResult result = MessageBox.Show(i_Message, i_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                r_Game.StartNewRound();
                updateColumnButtonsEnabledState();
            }
            else
            {
                Close();
            }
        }
      
        private void updateScoreBoard()
        {
            labelPlayer1Score.Text = string.Format(
                "{0}: {1}",
                r_Game.Player1.Name,
                r_Game.Player1.Score);

            labelPlayer2Score.Text = string.Format(
                "{0}: {1}",
                r_Game.Player2.Name,
                r_Game.Player2.Score);
        }

        private void updateColumnButtonsEnabledState()
        {
            int cols = r_Game.Board.Cols;

            for (int c = 0; c < cols; c++)
            {
                bool columnIsFull = r_Game.Board.GetCellState(0, c) != eCellState.Empty;
                m_ColumnButtons[c].Enabled = !columnIsFull;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            r_Game.Board.CellChanged -= board_CellChanged;
            base.OnFormClosed(e);
        }

        private void panelScore_Paint(object sender, PaintEventArgs e)
        {
        }

        private void labelPlayer1Score_Click(object sender, EventArgs e)
        {
        }

        private void labelPlayer2Score_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanelBoard_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
