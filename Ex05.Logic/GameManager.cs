using System;


namespace Ex05.Logic
{
    // $G$ CSS-999 (-3) Unclear name: "GameManager" suggests it manages game logic (scores, rules),
    // this class manages flow and UI coordination. Names like GameController or GameOrchestrator would be clearer.
    public class GameManager
    {
        private Game m_Game;
        private eGameMode m_GameMode;
        private eMoveState m_LastUiMessage = eMoveState.Dropped;

        public void Run()
        {
            initializeGame();

            bool playAnotherGame = true;

            while (playAnotherGame)
            {
                m_Game.StartNewRound();
                runSingleRound();

                ConsoleView.IsContinueGame(out playAnotherGame);
            }
        }

        // $G$ DSN-002 (-5) The ComputerAi object belongs to pure logic class (Game). not classes that interact with the user.        
        // The Game should enable performing a computer move, if in the future the UI is drag and drop for example You still need the game to expose "computer move" functionality.
        // $G$ DSN-999 (0) It would have been better for the Game to expose GameMode to the UI classes, and not have eGameMode here.
        private void initializeGame()
        {
            int rows;
            int columns;

            ConsoleView.GetBoardSize(out rows, out columns);

            m_GameMode = ConsoleView.GetGameMode();

            Player player1 = new Player(ConsoleView.GetPlayerName(1), eCellState.X, ePlayerType.Human);

            Player player2;
            ComputerAi computerAi = null;

            if (m_GameMode == eGameMode.HumanVsHuman)
            {
                player2 = new Player(ConsoleView.GetPlayerName(2), eCellState.O, ePlayerType.Human);
            }
            else
            {
                player2 = new Player("Computer", eCellState.O, ePlayerType.Computer);
                computerAi = new ComputerAi();
            }

            m_Game = new Game(rows, columns, player1, player2, computerAi);
        }

        private void runSingleRound()
        {
            bool roundOver = false;
            m_LastUiMessage = eMoveState.Dropped;

            while (!roundOver)
            {
                ConsoleView.PrintBoard(m_Game.Board);
                printLastMessageIfNeeded();

                ConsoleView.PrintPlayerTurn(m_Game.CurrentPlayer);

                if (m_Game.CurrentPlayer.PlayerType == ePlayerType.Human)
                {
                    ConsoleView.PrintTurnInstructions(m_Game.Board);
                    roundOver = handleHumanTurn();
                }
                else
                {
                    roundOver = handleComputerTurn();
                }
            }

            ConsoleView.PrintBoard(m_Game.Board);
            printLastMessageIfNeeded();
            ConsoleView.PrintGameFinish();
            printScores();
        }


        private void printLastMessageIfNeeded()
        {
            if (m_LastUiMessage == eMoveState.InvalidInput)
            {
                ConsoleView.PrintInvalidInput();
                m_LastUiMessage = eMoveState.Dropped;
            }
            else if (m_LastUiMessage == eMoveState.ColumnFullOrOutOfRange)
            {
                ConsoleView.PrintInvalidMove();
                m_LastUiMessage = eMoveState.Dropped;
            }
            else if (m_LastUiMessage == eMoveState.Win)
            {
                ConsoleView.PrintWinnerPlayer(m_Game.LastRoundWinner);
                m_LastUiMessage = eMoveState.Dropped;
            }
            else if (m_LastUiMessage == eMoveState.Tie)
            {
                ConsoleView.PrintEvenGame();
                m_LastUiMessage = eMoveState.Dropped;
            }
            else if (m_LastUiMessage == eMoveState.Quit)
            {
                ConsoleView.PrintWinnerPlayer(m_Game.LastRoundWinner);
                m_LastUiMessage = eMoveState.Dropped;
            }
        }
        
        private void printScores()
        {
            Console.WriteLine("Score:");
            Console.WriteLine("{0}: {1}", m_Game.Player1.Name, m_Game.Player1.Score);
            Console.WriteLine("{0}: {1}", m_Game.Player2.Name, m_Game.Player2.Score);
        }

        // $G$ CSS-028 (-5) A method should not include more than one return statement.
        private bool handleHumanTurn()
        {
            string input = Console.ReadLine();

            if (isQuitInput(input))
            {
                m_LastUiMessage = m_Game.QuitRound();
                return true;
            }

            int chosenColumn;

            if (!tryParseColumn(input, m_Game.Board.Cols, out chosenColumn))
            {
                m_LastUiMessage = eMoveState.InvalidInput;
                return false;
            }

            int rowPlaced;
            eMoveState state = m_Game.PlayHumanMove(chosenColumn, out rowPlaced);

            return handleMoveState(state);
        }

        private bool handleComputerTurn()
        {
            int columnPlaced;
            int rowPlaced;

            eMoveState state = m_Game.PlayComputerMove(out columnPlaced, out rowPlaced);

            return handleMoveState(state);
        }

        private bool isQuitInput(string i_Input)
        {
            return !string.IsNullOrEmpty(i_Input) && i_Input.Length == 1 && (i_Input[0] == 'Q' || i_Input[0] == 'q');
        }

        // $G$ CSS-028 (0) A method should not include more than one return statement.
        private bool tryParseColumn(string i_Input, int i_Cols, out int o_Col)
        {
            o_Col = -1;

            if (string.IsNullOrEmpty(i_Input) || i_Input.Length != 1)
            {
                return false;
            }

            char singleChar = i_Input[0];

            if (singleChar >= 'a' && singleChar <= 'z')
            {
                singleChar = (char)(singleChar - 'a' + 'A');
            }

            char minimumColumn = 'A';
            char maximumColumn = (char)('A' + i_Cols - 1);

            if (singleChar < minimumColumn || singleChar > maximumColumn)
            {
                return false;
            }

            o_Col = singleChar - 'A';

            return true;
        }

        // $G$ CSS-999 (0) Notice that you could group conditions, for example if i_State == eMoveState.Invalid input || i_State == ... 
        // instead of having a series of if's.
        private bool handleMoveState(eMoveState i_State)
        {
            m_LastUiMessage = i_State;
            bool handleMoveStateStatus = false;

            if (i_State == eMoveState.InvalidInput)
            {
                handleMoveStateStatus = false;
            }

            if (i_State == eMoveState.ColumnFullOrOutOfRange)
            {
                handleMoveStateStatus = false;
            }

            if (i_State == eMoveState.Win)
            {
                handleMoveStateStatus = true;
            }

            if (i_State == eMoveState.Tie)
            {
                handleMoveStateStatus = true;
            }

            if (i_State == eMoveState.Quit)
            {
                handleMoveStateStatus = true;
            }

            return handleMoveStateStatus;
        }
    }
}
