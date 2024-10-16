using System;
using TicTacToeSubmissionConole;

namespace TicTacToeSubmissionConole
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Run(            game.Get_currentPlayer());
        }
    }
    
}
