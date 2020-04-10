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
    }
}
