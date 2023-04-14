namespace TicTacToe
{
    internal class Program
    {
        static string[,] xOrO =
        {
            {"1","2","3"},
            {"4","5","6"},
            {"7","8","9"}
        };
        static int player = 1;


        static void Main(string[] args)
        {
            bool forTheWin = false;

            Console.Write("Name of player one: ");
            string playerOne = Console.ReadLine();
            Console.Write("Name of player two: ");
            string playerTwo = Console.ReadLine();
            Console.WriteLine($"Ok {playerOne} and {playerTwo}, lets play TicTacToe!");
            int turns = 0;

                do
                {
                    Console.WriteLine($@"
     |     |     
  {xOrO[0, 0]}  |  {xOrO[0, 1]}  |  {xOrO[0, 2]}  
_____|_____|_____
     |     |     
  {xOrO[1, 0]}  |  {xOrO[1, 1]}  |  {xOrO[1, 2]}  
_____|_____|_____
     |     |     
  {xOrO[2, 0]}  |  {xOrO[2, 1]}  |  {xOrO[2, 2]}  
     |     |     ");

                    Console.Write($"{playerOne}! Choose the number you want to place your X: ");
                    string playerOneChoise = InputCheck(Console.ReadLine());
                    PlayerChoise(playerOneChoise);
                    turns++;
                    player++;
                    Console.Clear();
                    if (Checker(xOrO))
                    {
                        Console.WriteLine($"Congratulations {playerOne} you won!");
                        break;
                    }
                    else if (turns == 9)
                    {
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    Console.WriteLine($@"
     |     |     
  {xOrO[0, 0]}  |  {xOrO[0, 1]}  |  {xOrO[0, 2]}  
_____|_____|_____
     |     |     
  {xOrO[1, 0]}  |  {xOrO[1, 1]}  |  {xOrO[1, 2]}  
_____|_____|_____
     |     |     
  {xOrO[2, 0]}  |  {xOrO[2, 1]}  |  {xOrO[2, 2]}  
     |     |     ");

                    Console.Write($"{playerTwo}! Choose the number you want to place your O: ");
                    string playerTwoChoise = InputCheck(Console.ReadLine());
                    PlayerChoise(playerTwoChoise);
                    turns++;
                    player--;
                    Console.Clear();
                    if (Checker(xOrO))
                    {
                        Console.WriteLine($"Congratulations {playerTwo} you won!");
                        break;
                    }
                    else if (turns == 9)
                    {
                        Console.WriteLine("It's a draw!");
                        break;
                    }


                } while (!forTheWin);
            Console.WriteLine("Thank you for playing.");

            Console.ReadKey();
        }

        

        public static void PlayerChoise(string choise)
        {
            if (player == 1)
            {
                for (int i = 0; i < xOrO.GetLength(0); i++)
                {
                    for (int j = 0; j < xOrO.GetLength(1); j++)
                    {
                        if (xOrO[i, j] == choise)
                        {
                            xOrO[i, j] = "X";

                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < xOrO.GetLength(0); i++)
                {
                    for (int j = 0; j < xOrO.GetLength(1); j++)
                    {
                        if (xOrO[i, j] == choise)
                        {
                            xOrO[i, j] = "O";

                        }
                    }
                }
            }
        }


        public static string InputCheck(string input)
        {
            bool youShallPass = false;

            do
            {
                for (int i = 0; i < xOrO.GetLength(0); i++)
                {
                    for (int j = 0; j < xOrO.GetLength(1); j++)
                    {
                        if (input == xOrO[i, j])
                        {
                            youShallPass = true;
                        }
                    }
                }
                if (youShallPass == false)
                {
                    Console.WriteLine("Invalid input. Try Again!");
                    input = Console.ReadLine();
                }
            } while (youShallPass == false);

            return input;
        }

        public static bool Checker(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                {
                    return true;                    
                }
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[0, j] == board[1, j] && board[0, j] == board[2, j])
                    {
                        return true;                        
                    }
                    if (board[i, j] == board[0, 0] && board[i, j] == board[2, 2] || board[i, j] == board[0, 2] && board[i, j] == board[2, 0])
                    {
                        return true;                        
                    }
                }
            }


            return false;
        }
    }
}