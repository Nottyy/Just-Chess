namespace Just_Chess.Figures
{
    using System.Collections.Generic;

    using Just_Chess.Common;
    using Just_Chess.Figures.Contracts;
    using Just_Chess.Movements;
    using Just_Chess.Movements.Contracts;
    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color) : base(color)
        {

        }

        public override ICollection<IMovement> Move()
        {
            return new List<IMovement>
            {
                new NormalPawnMovement(),
                //new AnPasanMovement()
            };
        }
    }
}
