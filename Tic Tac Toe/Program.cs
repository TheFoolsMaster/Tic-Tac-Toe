using System;

namespace Tic_Tac_Toe
{
    internal class GameTicTacToe
    {
        /*TO DO
         * Refactoring the player input 
         * Refactoring the game restart
        */

        // names of players
        static string player1 = "Player 1";
        static string player2 = "Player 2";
        // symbols visible on the board
        static char playerSymbol1 = 'X';
        static char playerSymbol2 = 'O';
        // which element of the board is changed
        static int elementOfBoard;
        //initall board
        static char[,] gameBoard = new char[,]
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        static void Main(string[] args)
        {
            GameRound();
        }
        /// <summary>
        /// Shows graphically game board in terminal and changes made by players
        /// </summary>
        static void Board()
        {
            Console.WriteLine(" {0} | {1} | {2} |", gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2]);
            Console.WriteLine("---|---|---|");
            Console.WriteLine(" {0} | {1} | {2} |", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
            Console.WriteLine("---|---|---|");
            Console.WriteLine(" {0} | {1} | {2} |", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
        }

        /// <summary>
        /// Decides if input is valid and handels all inputs made by players
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="playerSymbol"></param>
        static void PlayerInput(string playerNumber,char playerSymbol)
        {
            Console.WriteLine("{0}: Plese enter {1}", playerNumber, playerSymbol);
            Int32.TryParse(Console.ReadLine(), out elementOfBoard);
            switch (elementOfBoard)
            {
                case 1:
                    if(gameBoard[0, 0] == '1')
                    {
                        gameBoard[0, 0] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 2:
                    if (gameBoard[0, 1] == '2')
                    {
                        gameBoard[0, 1] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 3:
                    if (gameBoard[0, 2] == '3')
                    {
                        gameBoard[0, 2] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 4:
                    if (gameBoard[1, 0] == '4')
                    {
                        gameBoard[1, 0] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 5:
                    if (gameBoard[1, 1] == '5')
                    {
                        gameBoard[1, 1] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 6:
                    if (gameBoard[1, 2] == '6')
                    {
                        gameBoard[1, 2] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 7:
                    if (gameBoard[2, 0] == '7')
                    {
                        gameBoard[2, 0] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 8:
                    if (gameBoard[2, 1] == '8')
                    {
                        gameBoard[2, 1] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
                case 9:
                    if (gameBoard[2, 2] == '9')
                    {
                        gameBoard[2, 2] = playerSymbol;
                    }
                    else
                    {
                        PlayerInput(playerNumber, playerSymbol);
                    }
                    break;
            }
        }
        /// <summary>
        /// Checks if one of the player wins the round
        /// </summary>
        /// <returns></returns>
        static bool WinChecker()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                if(gameBoard[i,0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                {
                    return true;
                }
                if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
                {
                    return true;
                }
            }
            if(gameBoard[0, 0] == gameBoard[1, 1]&& gameBoard[1, 1]== gameBoard[2, 2])
            {
                return true;
            }
            if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Restarts the game and brings back initial game board
        /// </summary>
        static void GameRestart()
        {
            Console.WriteLine("");
            Console.WriteLine("Restarting the game");
            /*
            for(int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for(int j = 0 ; j < gameBoard.GetLength(1); j++)
                {

                }
            }
            */
            gameBoard[0, 0] = '1';
            gameBoard[0, 1] = '2';
            gameBoard[0, 2] = '3';
            gameBoard[1, 0] = '4';
            gameBoard[1, 1] = '5';
            gameBoard[1, 2] = '6';
            gameBoard[2, 0] = '7';
            gameBoard[2, 1] = '8';
            gameBoard[2, 2] = '9';
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        /// <summary>
        /// Used for starting the game
        /// </summary>
        static void GameRound()
        {
            Round(player1, playerSymbol1);
            Round(player2, playerSymbol2);
            GameRound();
        }
        /// <summary>
        /// Used for 1 round. Module contains clearing board, showing new board, handles player input, check for winner, restarts the game if necessary
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="playerSymbol"></param>
        private static void Round(string playerNumber,char playerSymbol)
        {
            Console.Clear();
            Board();
            PlayerInput(playerNumber, playerSymbol);
            if (WinChecker())
            {
                GameRestart();
            }
        }
    }
}
