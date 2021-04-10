using System;

namespace Tic_tac
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            char player2;
            char[,] board =new char[3,3];
            bool isPlaying = true;

            TicTacToe ticTacToe = new TicTacToe();

            Console.WriteLine("Tic-Tac-Toe Game!");
            ticTacToe.PrintResetBoard();
            Console.WriteLine("Player is user and Player2 is computer");
            ticTacToe.AssignCharacter();
            ticTacToe.PlayGame();
        }
    }
}
