namespace Just_Chess.Engine.Contracts
{
    using System;
    using System.Linq;
    using Just_Chess.Common;
    using Just_Chess.Board;
    using Just_Chess.Engine.Initializations;
    using Just_Chess.InputProviders.Contracts;
    using Just_Chess.Players.Contracts;
    using Just_Chess.Renderers.Contracts;
    using System.Collections.Generic;
    using Just_Chess.Players;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        private int currentPlayerIndex;

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
            this.players = new List<IPlayer>
            {
                new Player("Pesho", ChessColor.Black),
                new Player("Gosho", ChessColor.White)
            };

            this.GetFirstPlayerIndex();
            //this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(board);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }
            }
        }

        public bool? WinningConditions()
        {
            throw new System.NotImplementedException();
        }

        private void GetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }
    }
}
