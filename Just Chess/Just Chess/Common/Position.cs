using System;
using System.Collections.Generic;
using System.Text;

namespace Just_Chess.Common
{
    public struct Position
    {
        public static Position FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
        }
        public Position(int row, char col) 
            : this()
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; private set; }
        public char Col { get; private set; }
    }
}
