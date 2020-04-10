﻿namespace Just_Chess.Figures
{
    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color) : base(color)
        {

        }
    }
}