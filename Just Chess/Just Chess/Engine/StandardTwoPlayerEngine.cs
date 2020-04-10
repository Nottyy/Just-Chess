namespace Just_Chess.Engine.Contracts
{
    using Just_Chess.Common;
    using Just_Chess.Engine.Contracts;
    using Just_Chess.Board;
    using Just_Chess.Engine.Initializations;
    using Just_Chess.InputProviders.Contracts;
    using Just_Chess.Players.Contracts;
    using Just_Chess.Renderers.Contracts;
    using System.Collections.Generic;
    using Just_Chess.Players;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            // TODO: remove using Just_Chess.Players; and use input
            var players = new List<IPlayer>
            {
                new Player("Pesho", ChessColor.Black),
                new Player("Gosho", ChessColor.White)
            };
                
                //this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);
            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(board);
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
