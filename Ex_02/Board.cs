using System;
using System.Collections.Generic;

namespace Ex_02
{
    internal class Board
    {
        private readonly Cell[,] r_Cells;
        private readonly int r_Column;
        private readonly int r_Row;
        private readonly bool[,] r_CellsMatched;
        public int NumOfCols 
        {
            get { return r_Column; }
        } 
        public int NumOfRows 
        { 
            get { return r_Row; } 
        }

        public Cell[,] Cells
        {
            get { return r_Cells; }
        }

        public Board(int i_row, int i_column)
        {
            r_Row = i_row;
            r_Column = i_column;
            r_Cells = new Cell[i_row, i_column];
            r_CellsMatched = new bool[i_row, i_column];

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
                    r_Cells[i, j] = new Cell(i, j, (char)letterOptions[index]);
                    letterOptions.RemoveAt(index);
                    r_CellsMatched[i, j] = false;
                }
            }
        }
        public char FlipCell(int i_row, int i_column)
        {
            char cellLetterValue = r_Cells[i_row,i_column].Letter;
            r_Cells[i_row, i_column].FlipVisibility();
            return cellLetterValue;
        }



        internal void GotAMatch((int Row, int Col) i_FirstCell, (int Row, int Col) i_SecondCell)
        {
            r_CellsMatched[i_FirstCell.Row, i_FirstCell.Col] = true;
            r_CellsMatched[i_SecondCell.Row, i_SecondCell.Col] = true;
            
        }

        internal bool IsBoardMatched()
        {
            bool isBoardMatched = true;

            for (int i = 0; i < r_Row;i++)
            {
                for (int j = 0;j < r_Column;j++)
                {
                    if (r_CellsMatched[i, j] == false)
                    {
                        isBoardMatched = false;
                        break;
                    }
                }
            }

            return isBoardMatched;
        }

        internal bool AlreadyMatched(int i_Row, int i_Col)
        {
            bool alreadyMatched = r_CellsMatched[i_Row, i_Col];

            return alreadyMatched;
        }
    }
}
