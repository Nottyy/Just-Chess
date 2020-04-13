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

        public ConsoleRenderer()
        {
            // TODO : Change this magic values to something calculated
            if (Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.WriteLine("Please, set the Console window and buffer size to 100x80. For best experience use 8x8 font!");
                Environment.Exit(0);
            }
        }

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

            this.PrintBorder(startRowPrint,startColPrint, board.TotalRows, board.TotalCols);

            int counter = 1;
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
        }

        private void PrintBorder(int startRowPrint, int startColPrint, int totalRows, int totalCols)
        {
            
            // check the math
            for (int i = startRowPrint - 2; i < startRowPrint + totalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint - 2);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + totalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint + totalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 1);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + totalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint - 2, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + totalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + totalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 1, i);
                Console.Write(" ");
            }

            var startR = startRowPrint + ConsoleConstants.CharactersPerRowPerBoardSquare / 2;
            for (int i = 0; i < totalCols; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(startR + i * ConsoleConstants.CharactersPerRowPerBoardSquare, startColPrint - 1);
                Console.Write((char)('A' + i));

                Console.SetCursorPosition(startR + i * ConsoleConstants.CharactersPerRowPerBoardSquare, startColPrint + totalRows * ConsoleConstants.CharactersPerRowPerBoardSquare);
                Console.Write((char)('A' + i));
            }

            var startC = startColPrint + ConsoleConstants.CharactersPerRowPerBoardSquare / 2;
            for (int i = 0; i < totalRows; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(startRowPrint - 1, startC + i * ConsoleConstants.CharactersPerColPerBoardSquare);
                Console.Write(totalRows - i);

                Console.SetCursorPosition(startRowPrint + totalCols * ConsoleConstants.CharactersPerColPerBoardSquare, startC + i * ConsoleConstants.CharactersPerColPerBoardSquare);
                Console.Write(totalRows - i);
            }  
        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRoweForPlayerIO);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, ConsoleConstants.ConsoleRoweForPlayerIO);
            Console.Write(errorMessage);
            Thread.Sleep(2500);

            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRoweForPlayerIO);
        }
    }
}
