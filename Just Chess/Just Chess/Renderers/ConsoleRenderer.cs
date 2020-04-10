namespace Just_Chess.Renderers
{
    using Just_Chess.Board;
    using Just_Chess.Common;
    using Just_Chess.Common.Console;
    using Just_Chess.Renderers.Contracts;
    using System;
    using System.Threading;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "JUST CHESS";
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

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
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            int counter = 0;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentColPrint = startRowPrint + left * ConsoleConstants.CharactersPerColPerBoardSquare;
                    currentRowPrint = startColPrint + top * ConsoleConstants.CharactersPerRowPerBoardSquare;

                    ConsoleColor backgroundColor;
                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarkSquareConsoleColor;
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        backgroundColor = LightSquareConsoleColor;
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);

                    counter++;
                }
                counter++;
            }

            

            Console.ReadLine();
        }
    }
}
