namespace Just_Chess
{
    using System;
    using Just_Chess.Engine.Contracts;
    using Just_Chess.Engine.Initializations;
    using Just_Chess.InputProviders;
    using Just_Chess.InputProviders.Contracts;
    using Just_Chess.Renderers;
    using Just_Chess.Renderers.Contracts;
    public class ChessFacade
    {

        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            //renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandardTwoPlayerEngine(renderer, inputProvider);

            IGameInitializationStrategy gameInitializationStrategy = new StandardStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
