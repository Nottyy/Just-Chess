namespace Just_Chess.InputProviders.Contracts
{
    using System.Collections.Generic;
    using Just_Chess.Players.Contracts;
    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
    }
}
