using System;
using System.Collections.Generic;

namespace Ex_02
{
    internal class Board
    {
        private readonly Cell[,] m_Cells;
        private int m_Column;
        private int m_Row;
        const int k_PrintMuliplier = 5;

        public Board(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Cells = new Cell[i_row, i_column];

            int numberOfPairs = (i_column * i_row) / 2;

            List<int> letterOptions = new List<int>();

            for (char c = 'A'; c <= 'A' + numberOfPairs; c++)
            {
                letterOptions.Add(c);
                letterOptions.Add(c);
            }

            Random random = new Random();
            for (int i = 0; i < i_row; i++)
            {
                for (int j = 0; j < i_column; j++)
                {
                    int index = random.Next(0, letterOptions.Count);
                    m_Cells[i, j] = new Cell(i, j, (char)letterOptions[index]);
                    letterOptions.RemoveAt(index);
                }
            }
        }
        public char FlipCell(int i_row, int i_column)
        {
            char cellLetterValue = m_Cells[i_row,i_column].Letter;
            m_Cells[i_row, i_column].FlipVisibility();
            return cellLetterValue;
        }

        public void PrintBoard()
        {
            Console.Write(' ');
            Console.Write(' ');
            for (int j = 0; j < m_Column; j++)
            {
                Console.Write($"  {(char)('A' + j)}  ");
            }

            Console.WriteLine();


            for (int i = 0; i < m_Row; i++)
            {
                Console.Write("  ");
                Console.WriteLine(new string('=', k_PrintMuliplier * m_Column));
                Console.Write($"{i + 1} ");
                Console.Write("|");
                for (int j = 0; j < m_Column; j++)
                {
                    if (m_Cells[i, j].m_IsVisible)
                    {
                        Console.Write($" {m_Cells[i, j].Letter} | ");
                    }
                    
                    else
                    {
                        Console.Write(new string(' ', 3 ) + "| ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
