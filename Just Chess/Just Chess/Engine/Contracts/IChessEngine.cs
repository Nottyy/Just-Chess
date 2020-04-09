namespace Just_Chess.Engine.Contracts
{
    using Just_Chess.Engine.Initializations;
    using Just_Chess.Players.Contracts;
    using System.Collections.Generic;

    public interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; }
        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        bool? WinningConditions(); // make enumeration
    }
}
