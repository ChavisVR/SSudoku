using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSudoku
{

    using System;

    namespace SudokuGame
    {
        class Program
        {
            static int[,] board = new int[9, 9];

            static void Main(string[] args)
            {
                InitializeBoard();
                PrintBoard();

                while (!IsSudokuSolved())
                {
                    Console.Write("Selecciona la fila: ");
                    int row = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Selecciona la columna: ");
                    int col = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Selecciona el número: ");
                    int num = int.Parse(Console.ReadLine());

                    if (IsValidMove(row, col, num))
                    {
                        board[row, col] = num;
                        PrintBoard();
                    }
                    else
                    {
                        Console.WriteLine("Movimiento inválido. Intente nuevamente.");
                    }
                }

                Console.WriteLine("¡Felicidades! ¡Has ganado!");
            }

            static void InitializeBoard()
            {
                
                int[,] initialBoard = {
                {5, 3, 0, 0, 7, 8, 9, 1, 0},
                {0, 7, 2, 1, 0, 5, 0, 0, 8},
                {0, 0, 8, 3, 4, 0, 0, 6, 0},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9}


                /*{5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9} */
            };

                Array.Copy(initialBoard, board, initialBoard.Length);
            }

            static void PrintBoard()
            {
                Console.WriteLine("Tablero actual:\n");
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        Console.Write(board[row, col] + " ");
                        if (col == 2 || col == 5)
                        {
                            Console.Write("| ");
                        }
                    }
                    Console.WriteLine();
                    if (row == 2 || row == 5)
                    {
                        Console.WriteLine("---------------------");
                    }
                }
                Console.WriteLine();
                Console.ReadKey();
            }

            static bool IsValidMove(int row, int col, int num)
            {
                
                return IsValidInRow(row, num) && IsValidInColumn(col, num) && IsValidInRegion(row, col, num);
            }

            static bool IsValidInRow(int row, int num)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == num)
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool IsValidInColumn(int col, int num)
            {
                for (int row = 0; row < 9; row++)
                {
                    if (board[row, col] == num)
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool IsValidInRegion(int row, int col, int num)
            {
                int startRow = row - row % 3;
                int startCol = col - col % 3;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[startRow + i, startCol + j] == num)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            static bool IsSudokuSolved()
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row, col] == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }

}
