namespace Just_Chess.InputProviders
{
    using System;
    using Just_Chess.Common.Console;
    using Just_Chess.Players.Contracts;
    using System.Collections.Generic;
    using Just_Chess.Players;
    using Just_Chess.Common;
    using Just_Chess.InputProviders.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter Player {0} name: ";

        
        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(string.Format(PlayerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            return players;
        }

        /// <summary>
        /// Command is in format : a5-c5
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Move GetNextPlayerMove(IPlayer player)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRoweForPlayerIO);
            // a5-c5
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, ConsoleConstants.ConsoleRoweForPlayerIO);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("{0} is next: ", player.Name);
            var positionAsString = Console.ReadLine().Trim().ToLower();

            return ConsoleHelpers.CreateMoveFromCommand(positionAsString);
        }
    }
}
