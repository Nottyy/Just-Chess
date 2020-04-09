namespace Just_Chess.Engine.Contracts
{
    using Just_Chess.Engine.Contracts;
    using Just_Chess.Engine.Initializations;
    using Just_Chess.Players.Contracts;
    using System.Collections.Generic;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players;

        public IEnumerable<IPlayer> Players 
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            //gameInitializationStrategy.Initialize();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public bool? WinningConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
