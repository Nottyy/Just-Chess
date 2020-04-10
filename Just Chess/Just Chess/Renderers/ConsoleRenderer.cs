namespace Just_Chess.Renderers
{
    using Just_Chess.Board;
    using Just_Chess.Common.Console;
    using Just_Chess.Renderers.Contracts;
    using System;
    using System.Threading;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "JUST CHESS";
        private const int CharactersPerRowPerBoardSquare = 9;
        private const int CharactersPerColPerBoardSquare = 9;


        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            // TODO: add main menu
            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ");

            Console.ReadLine();
        }
    }
}
