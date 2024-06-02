using System;
using System.Collections.Generic;

namespace Ex_02
{
    internal class Board
    {
        private Cell[,] m_Cells;
        private int m_Column;
        private int m_Row;
        const int k_PrintMuliplier = 5;
        private bool[,] m_CellsMatched;
        public int NumOfCols 
        {
            get { return m_Column; }
        } 
        public int NumOfRows 
        { 
            get { return m_Row; } 
        }

        public Cell[,] Cells
        {
            get { return m_Cells; }
        }

        public Board(int i_row, int i_column)
        {
            m_Row = i_row;
            m_Column = i_column;
            m_Cells = new Cell[i_row, i_column];
            m_CellsMatched = new bool[i_row, i_column];

            int numOfPairs = (i_column * i_row) / 2;

            List<int> letterOptions = new List<int>();

            for (char c = 'A'; c < 'A' + numOfPairs; c++)
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
                    m_CellsMatched[i, j] = false;
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
            Console.Write("  ");
            Console.WriteLine(new string('=', k_PrintMuliplier * m_Column));
        }

        internal void GotAMatch((int Row, int Col) i_FirstCell, (int Row, int Col) i_SecondCell)
        {
            m_CellsMatched[i_FirstCell.Row, i_FirstCell.Col] = true;
            m_CellsMatched[i_SecondCell.Row, i_SecondCell.Col] = true;
            
        }

        internal bool IsBoardMatched()
        {
            bool isBoardMatched = true;

            for (int i = 0; i < m_Row;i++)
            {
                for (int j = 0;j < m_Column;j++)
                {
                    if (m_CellsMatched[i, j] == false)
                    {
                        isBoardMatched = false;
                        break;
                    }
                }
            }

            return isBoardMatched;
        }

        internal bool alreadyMatched(int i_Row, int i_Col)
        {
            bool alreadyMatched = m_CellsMatched[i_Row, i_Col];

            return alreadyMatched;
        }
    }
}
