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
            //TODO: Validate Console dimensions
            var startRowPrint = Console.WindowHeight / 2 - (board.TotalRows / 2) * CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowWidth / 2 - (board.TotalCols / 2) * CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            Console.BackgroundColor = ConsoleColor.White;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentRowPrint = startRowPrint + left * CharactersPerColPerBoardSquare;
                    currentColPrint = startColPrint + top * CharactersPerRowPerBoardSquare;

                    Console.SetCursorPosition(currentColPrint, currentRowPrint);
                    Console.Write(" ");
                }
            }

            

            Console.ReadLine();
        }
    }
}
