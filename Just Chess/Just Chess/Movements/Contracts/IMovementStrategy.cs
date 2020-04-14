namespace Just_Chess.Movements.Contracts
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IMovementStrategy
    {
        IList<IMovement> GetAllMovements(string figureName);
    }
}
