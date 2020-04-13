namespace Just_Chess.Figures
{
    using System.Collections.Generic;

    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements.Contracts;

    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color) : base(color)
        {

        }

        public override ICollection<IMovement> Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
