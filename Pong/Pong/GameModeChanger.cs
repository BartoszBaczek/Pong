using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Pong
{
    class GameModeChanger
    {

        public int MenuMode;
        public int GameMode;
        public int ServingMode;

        public GameModeChanger()
        {
            SetmenuMode();
        }

        public void SetmenuMode()
        {
            MenuMode = 1;
            GameMode = 0;
            ServingMode = 0;
        }

        public void SetGameMode()
        {
            MenuMode = 0;
            GameMode = 1;
            ServingMode = 0;
        }

        public void SetServingMode()
        {
            MenuMode = 0;
            GameMode = 0;
            ServingMode = 1;
        }

    }
}
