using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Design();


            int[,] numBoard = ConfigNumBoard();//filling the board with numbers
            int boardSize = numBoard.GetLength(0);

            string[] playersBoard = ConfigPlayersBoard(boardSize);//configuring the board of the players

            string[,] gameBoard = ConfigGameBoard(boardSize, empty);//configuring the board of the game itself

            Game(gameBoard, playersBoard, numBoard);
            Wining();


            Console.ReadLine();
        }

        const string empty = "~";
        const string RedQueen = "queen";
        const string RedKing = "king";
        const string BlueQueen = "queen";
        const string BlueKing = "king";












        public static bool Game(string[,] gameBoard, string[] playersBoard, int[,] numBoard)
        {
            Random rnd = new Random();
            gameBoard[rnd.Next(8), rnd.Next(8)] = RedQueen;
            gameBoard[rnd.Next(8), rnd.Next(8)] = RedKing;
            gameBoard[rnd.Next(8), rnd.Next(8)] = BlueQueen;
            gameBoard[rnd.Next(8), rnd.Next(8)] = BlueKing;///temporery solution, need to place all pieces

            int playersAmount = 2;

            bool isWon = false;

            int turns = 0;


            while (!isWon)
            {

                printBoard(gameBoard, numBoard);

                for (int i = 0; i < playersAmount; i++, turns++)
                {




                    MoveTo(gameBoard, playersBoard, numBoard, i, RedQueen);



                    //isWon = winChecker(gameBoard);


                    if (isWon)
                        return true;






                }




            }
            return false;
        }




        public static void MoveTo(string[,] gameBoard, string[] playersBoard, int[,] numBoard, int i, string piece)
        {
            //getting the input from the player
            Console.WriteLine();
            Console.WriteLine("{0} where do you want to move {1} to", playersBoard[i], piece);
            int place = int.Parse(Console.ReadLine());
            

            int[] placingIndex = FindNumIndex(numBoard, place);
            place = 0;

            if (IsPossibleToPlace(placingIndex, gameBoard))
            {
                int[] pieceIndex = FindPieceIndex(gameBoard, piece);
                gameBoard[pieceIndex[0], pieceIndex[1]] = empty;//set the prev place of this piece as empty
                gameBoard[placingIndex[0], placingIndex[1]] = piece;//moving the piece to the desired place
                if (playersBoard[i] == playersBoard[0])
                    printBoard(gameBoard, numBoard);
            }

            else
            {
                Console.WriteLine("you need to place your sign in existing and not occupied slot, please insert place again");
                place = int.Parse(Console.ReadLine());
            }
        }



        public static bool IsPossibleToPlace(int[] placingIndex, string[,] gameBoard)
        {
            if (placingIndex[0] != -1 /*that index exists*/ && gameBoard[placingIndex[0], placingIndex[1]] == empty/*that index is empty*/)
                return true;
            else
                return false;
        }
















        public static void Design()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public static void Wining()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Console.WriteLine("well played, game has finisihed as a win");
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
        }





        public static int[] FindNumIndex(int[,] arr, int num)
        {
            int[] index = new int[2];
            index[0] = -1;

            for (int row = 0; row < arr.GetLength(0); row++)
                for (int column = 0; column < arr.GetLength(1); column++)
                    if (arr[row, column] == num)
                    {
                        index[0] = row;
                        index[1] = column;
                        return index;
                    }


            return index;
        }




        public static int[] FindPieceIndex(string[,] arr, string piece)
        {
            int[] index = new int[2];
            index[0] = -1;

            for (int row = 0; row < arr.GetLength(0); row++)
                for (int column = 0; column < arr.GetLength(1); column++)
                    if (arr[row, column] == piece)
                    {
                        index[0] = row;
                        index[1] = column;
                        return index;
                    }


            return index;
        }





        public static int[,] ConfigNumBoard()
        {
            int boardSize = 8;
            int[,] numBoard = new int[boardSize, boardSize];
            int counter = 1;
            for (int row = 0; row < numBoard.GetLength(0); row++)
                for (int column = 0; column < numBoard.GetLength(1); column++, counter++)
                    numBoard[row, column] = counter;



            return numBoard;
        }




        public static string[] ConfigPlayersBoard(int size)
        {

            string[] playersBoard = new string[size];

            //calling the functions of each element in the playersBoard
            playersBoard[0] = ConfigP1(playersBoard);//p1 name
            playersBoard[1] = ConfigP2(playersBoard);//p2 name

            return playersBoard;
        }
        public static string ConfigP1(string[] playersBoard)
        {

            string p1 = "";
            Console.WriteLine("who is the next player?");
            p1 = Console.ReadLine();
            return p1;
        }
        public static string ConfigP2(string[] playersBoard)
        {
            string p2 = "";

            Console.WriteLine("who is the next player?");
            p2 = Console.ReadLine();
            return p2;

        }



        //to work on 1 ConfigGameBoard
        public static string[,] ConfigGameBoard(int size, string empty)
        {
            Random rnd = new Random();
            string[,] gameBoard = new string[size, size];

            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int column = 0; column < gameBoard.GetLength(1); column++)
                {
                    gameBoard[row, column] = empty;
                }
            }

            return gameBoard;

        }



        public static void printBoard(string[,] gameBoard, int[,] numBoard)
        {
            Console.Clear();
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                Console.WriteLine();
                for (int column = 0; column < gameBoard.GetLength(1); column++)
                {

                    if (gameBoard[row, column] != empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(gameBoard[row, column] + "\t");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    else
                    {
                        Console.Write(numBoard[row, column] + "\t");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}


