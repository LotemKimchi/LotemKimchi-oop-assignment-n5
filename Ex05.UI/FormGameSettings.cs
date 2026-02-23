using Ex05.Logic;
using System;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();

            cbPlayer2IsComputer.Checked = false; //default = computer
            applyPlayer2ModeToUi();

        }

        private void cbPlayer2IsComputer_CheckedChanged(object sender, EventArgs e)
        {
            applyPlayer2ModeToUi();
        }

        private void applyPlayer2ModeToUi()
        {          
            //Checked  = Player 2 is HUMAN
            //Unchecked = Player 2 is COMPUTER (default)
            bool isHuman = cbPlayer2IsComputer.Checked;

            tbPlayer2Name.Enabled = isHuman;

            if (!isHuman) //Computer mode
            {
                tbPlayer2Name.Text = "[Computer]";
            }
            else //Human mode
            {
                if (tbPlayer2Name.Text == "[Computer]")
                {
                    tbPlayer2Name.Text = string.Empty;
                }

                tbPlayer2Name.Focus();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Game game = createGameFromSettings();

            using (FormGame formGame = new FormGame(game))
            {
                Hide();
                formGame.ShowDialog();
                Close();
            }
        }

        private Game createGameFromSettings()
        {
            int rows = (int)nudRows.Value;
            int cols = (int)nudCols.Value;

            string player1Name = tbPlayer1Name.Text.Trim();
            if (string.IsNullOrEmpty(player1Name))
            {
                player1Name = "Player 1";
            }

            Player player1 = new Player(player1Name, eCellState.X, ePlayerType.Human);

            bool isComputer = !cbPlayer2IsComputer.Checked;

            Player player2;
            ComputerAi computerAi = null;

            if (isComputer)
            {
                player2 = new Player("Computer", eCellState.O, ePlayerType.Computer);
                computerAi = new ComputerAi();
            }
            else
            {
                string player2Name = tbPlayer2Name.Text.Trim();
                if (string.IsNullOrEmpty(player2Name))
                {
                    player2Name = "Player 2";
                }

                player2 = new Player(player2Name, eCellState.O, ePlayerType.Human);
            }

            return new Game(rows, cols, player1, player2, computerAi);
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {
        }
    }
}
