using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class GameModeController
    {
        public enum GameMode
        {
            Menu,
            Game,
            Serving
        }

        public GameMode Mode { get; set; }


        public GameModeController(GameMode _mode)
        {
            Mode = _mode;
        }

        public void SetmenuMode()
        {
            Mode = GameMode.Menu;
        }

        public void SetGameMode()
        {
            Mode = GameMode.Game;
        }

        public void SetServingMode()
        {
            Mode = GameMode.Serving;

        }
    }
}
