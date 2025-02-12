﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class Cell
    {
        private int m_Row { get; set; }
        private int m_Col { get; set; }
        public bool m_IsVisible { get; set; } = false;
        private char m_Letter;
        
        public Cell(int i_row, int i_col, char i_letter)
        {
            this.m_Row = i_row;
            this.m_Col = i_col;
            this.m_Letter = i_letter;
            
        }

        public char Letter
        {
            get { return m_Letter; }
            set { m_Letter = value; }
        }

        public void FlipVisibility()
        {
            m_IsVisible = !m_IsVisible;
        }

    }
}
