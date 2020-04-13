using Just_Chess.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Just_Chess.Renderers.Contracts
{
    public interface IRenderer
    {
        void RenderMainMenu();
        void RenderBoard(IBoard board);
        void PrintErrorMessage(string errorMessage);
    }
}
