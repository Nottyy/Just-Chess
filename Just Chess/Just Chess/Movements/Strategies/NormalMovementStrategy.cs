
namespace Just_Chess.Movements.Strategies
{

    using System.Collections.Generic;
    using Just_Chess.Movements.Contracts;
    using Just_Chess.Movements.Contracts;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>
        {
            {
                "Pawn", new List<IMovement>
                {
                    new NormalPawnMovement()
                }
            },
            {
                "Bishop", new List<IMovement>
                {
                    new NormalBishopMovement()
                }
            },
            {
                "Rook", new List<IMovement>
                {
                    new NormalRookMovement()
                }

            },
            {
                "Queen", new List<IMovement>
                {
                    new NormalRookMovement(),
                    new NormalBishopMovement()
                }

            },

        };
        public IList<IMovement> GetAllMovements(string figureName)
        {
            return this.movements[figureName];
        }
    }
}
