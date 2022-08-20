using System;

namespace Tic_Tac_Toe
{
    internal class GameTicTacToe
    {
        /*TO DO
         * Refactoring the PlayerInput()
         * Changing the size of the board
         * Refactoring the WinChecker()
        */

        // names of players
        static string player1 = "Player 1";
        static string player2 = "Player 2";
        // symbols visible on the board
        static char playerSymbol1 = 'X';
        static char playerSymbol2 = 'O';
        // which element of the board is changed
        static int elementOfBoard;
        //this is a main game board that we are modifying  
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
            Console.WriteLine("{0}: Please enter an integer value from 1 to 9 to place {1}", playerNumber, playerSymbol);
            if (Int32.TryParse(Console.ReadLine(), out elementOfBoard) && 0 <= elementOfBoard && elementOfBoard <= 9) 
            {
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
            else
            {
                PlayerInput(playerNumber, playerSymbol);
            }
        }
        /// <summary>
        /// Checks if one of the player wins the round
        /// </summary>
        /// <returns></returns>
        static bool WinChecker(string playerNumber)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                if(gameBoard[i,0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                {
                    Console.WriteLine("{0} won the game",playerNumber);
                    return true;
                }
                if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
                {
                    Console.WriteLine("{0} won the game", playerNumber);
                    return true;
                }
            }
            if(gameBoard[0, 0] == gameBoard[1, 1]&& gameBoard[1, 1]== gameBoard[2, 2])
            {
                Console.WriteLine("{0} won the game", playerNumber);
                return true;
            }
            if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])
            {
                Console.WriteLine("{0} won the game", playerNumber);
                return true;
            }
            //This if statment checks for a draw in a game
            if (FullBoard())
            {
                Console.WriteLine("Draw");
                GameRestart();
                return false;
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
            //initall board
            char[,] initialGameBoard = new char[,]
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
            gameBoard = initialGameBoard;
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
        static void Round(string playerNumber,char playerSymbol)
        {
            Console.Clear();
            Board();
            PlayerInput(playerNumber, playerSymbol);
            if (WinChecker(playerNumber))
            {
                GameRestart();
            }
        }
        /// <summary>
        /// Checks if any space on the board is free for 'X' or 'O'.
        /// </summary>
        /// <returns></returns>
        static bool FullBoard()
        {
            foreach(char i in gameBoard)
            {
                if (!(i == 'X' || i == 'O'))
                {
                    return false;
                } 
            }
            return true;
        }
    }
}
