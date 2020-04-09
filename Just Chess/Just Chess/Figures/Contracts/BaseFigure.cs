using Just_Chess.Common;

namespace Just_Chess.Figures.Contracts
{
    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }
    }
}
