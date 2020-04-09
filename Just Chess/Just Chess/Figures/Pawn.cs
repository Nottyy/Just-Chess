using Just_Chess.Common;
using Just_Chess.Figures.Contracts;

namespace Just_Chess.Figures
{
    public class Pawn : IFigure
    {
        public Pawn(ChessColor color)
        {
            this.Color = color;
        }
        public ChessColor Color { get; private set; }
    }
}
