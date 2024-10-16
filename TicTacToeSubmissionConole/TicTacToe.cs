using System;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public enum MyPlayerEnum
    {
        None,
        X,
        O
    }
    public class TicTacToe
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private TicTacToeConsoleRenderer _boardRenderer;
#pragma warning restore IDE0044 // Add readonly modifier
        private readonly MyPlayerEnum[,] _board; // To store the current state of the board
        private readonly MyPlayerEnum _currentPlayer; // To keep track of the current player


        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
            _board = new MyPlayerEnum[3, 3]; // Initialize the board with None
            _currentPlayer = MyPlayerEnum.X; // X starts first
        }

        public MyPlayerEnum Get_currentPlayer()
        {
            return _currentPlayer;
        }

        public void Run(MyPlayerEnum _currentPlayer)
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                Console.SetCursorPosition(2, 19);
                Console.Write("Player " + _currentPlayer);
                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row: ");
                var row = Console.ReadLine();

                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column: ");
                var column = Console.ReadLine();

                // Input Validation
                if (int.TryParse(row, out int rowInt)
                    && rowInt >= 0
                    && rowInt <= 2
                    && int.TryParse(column, out int colInt)
                    && colInt >= 0
                    && colInt <= 2
                    && _board[rowInt, colInt] == MyPlayerEnum.None)
                {
                    _boardRenderer.AddMove(rowInt, colInt, (PlayerEnum)_currentPlayer, true);
                    _board[rowInt, colInt] = _currentPlayer; // Update internal board

                    // Check for winner or draw
                    gameEnded = CheckForWinner() || CheckForDraw();

                    // Switch player (only if the game hasn't ended)
                    if (!gameEnded)
                    {
                        _currentPlayer = (_currentPlayer == MyPlayerEnum.X) ? MyPlayerEnum.O : MyPlayerEnum.X;
                    }
                }
                else
                {
                    Console.SetCursorPosition(2, 24);
                    Console.Write("Invalid input. Please try again.");
                    continue;
                }
            }

            Console.SetCursorPosition(2, 24);

            // Check and display the result
            if (CheckForWinner())
            {
                Console.Write("Player " + _currentPlayer + " wins!");
            }
            else
            {
                Console.Write("It's a draw!");
            }
        }

        private bool CheckForDraw()
        {
            // You need to implement this method to check for a draw
            throw new NotImplementedException();
        }

        private bool CheckForWinner()
        {
            // You need to implement this method to check for a winner
            throw new NotImplementedException();
        }
    }
}