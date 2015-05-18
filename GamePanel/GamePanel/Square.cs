using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame
{

    public struct Square
    {

        public static readonly Square Negative = new Square(-1, -1);

        private int row;
        private int column;

        public Square(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj is Square)
            {
                Square other = (Square)obj;
                return other.column == column && other.row == row;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (row << 8) | column;
        }


        public int Row
        {
            get { return row; }
        }

        public int Column
        {
            get { return column; }
        }

    }
}
