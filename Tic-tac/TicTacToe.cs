using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_tac
{
    public class TicTacToe 
    {
        char player, computer,marker;
        int row, col;
        string playerPlaying = "player";

        Random random = new Random();
        char[,] board = new char[3, 3];

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + this.board[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void positionRefernceBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.board[i, j] = (char)(i + ',');


                }
            }
            DisplayBoard();
        }

        public void PrintResetBoard()
        {
            int count = 0;
            for (int i = 0; i<3; i++)
            { 
                for (int j = 0; j< 3; j++)
                {
                    this.board[i, j] = ' ';
                    

                }
            }
            this.DisplayBoard();
        }

        public void AssignCharacter()
        {
            int a=this.random.Next(0, 2);
            if (a == 0)
            {
                this.player = 'X';
                this.computer = 'o';
            }
            else
            {
                this.player = 'o';
                this.computer = 'X';
            }
            Console.WriteLine("Player is " + this.player + " and computer is  " + this.computer);
          
        }

        public void CheckWhoIsPlaying()
        {
            if (playerPlaying == "player")                  
                this.playerPlaying = "computer";            
            else                                       
                this.playerPlaying = "player";           
        }

        public int GenerateRandomNumber()
        {
            return random.Next(0, 3);
        }

        public void PostionCheck()
        {
            if (playerPlaying == "player")
            {
                this.marker = this.player;
                Console.WriteLine("Type the row position to enter into ");
                row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Type the column position to enter into ");
                col = Convert.ToInt32(Console.ReadLine());
            }
            else  
            {
                Console.WriteLine("It is Computer's turn");
                this.marker = this.computer;
                row = GenerateRandomNumber();
                col = GenerateRandomNumber();
            }     
        }    

        public void PlayGame()
        {
            bool isPlaying = true;
            while (isPlaying)
            {                          
                PostionCheck();  
                validation:
                if (board[row,col] == ' ')
                {                       
                    board[row,col] = this.marker;
                }
                else
                {
                    Console.WriteLine("Position is not empty,Try another position");
                    PostionCheck();
                    goto validation;
                }                
                DisplayBoard();               
                if (CheckWinner())
                {
                    isPlaying = false;
                    Console.WriteLine(playerPlaying + " Won the game ");
                }
                CheckWhoIsPlaying();
            }
        }

        public bool CheckWinner()
        { 
            return CheckRows() || CheckColumns() || CheckDiagonals();
          
        }

        public bool CheckRows()
        {
            for(int rows = 0; rows< 3; rows++)
            {
                if(board[rows,0] == board[rows,1] && board[rows,1] == board[rows,2] && board[rows,1] != ' ')                
                    return true;                
            }
            return false;
        }

        public bool CheckColumns()
        {
            for(int columns = 0; columns < 3; columns++)
            {
                if(board[0,columns]==board[1,columns] && board[2,columns] == board[1,columns] && board[1,columns] != ' ')              
                    return true;           
            }
            return false;
        }

        public bool CheckDiagonals()
        {            
           if(board[0,0]==board[1,1] && board[1,1]==board[2,2] || board[0,2]==board[1,1] && board[1, 1] == board[2, 0] && board[1,1] != ' ')
                return true;       
            return false;
        }
    }
}
