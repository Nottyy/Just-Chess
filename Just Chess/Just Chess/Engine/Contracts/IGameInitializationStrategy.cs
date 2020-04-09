namespace Just_Chess.Engine.Initializations
{
    using Just_Chess.Board;
    using Just_Chess.Players.Contracts;
    using System.Collections.Generic;
    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
