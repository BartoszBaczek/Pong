using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class MenuController
    {
        public enum GameMode
        {
            Menu,
            Game,
            Serving
        }

        public enum CursorPosition
        {
            StartGame,
            Credits,
            GameMode
        }

        public GameMode Mode { get; set; }
        public CursorPosition TextChosen { get; set;}


        public MenuController(GameMode _mode, CursorPosition _cursorPosition)
        {
            Mode = _mode;
            TextChosen = _cursorPosition;
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

        public void Navigate()
        {
            switch (TextChosen)
            {
                case CursorPosition.StartGame:
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        TextChosen = CursorPosition.GameMode;
                    else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        TextChosen = CursorPosition.Credits;
                    break;

                case CursorPosition.Credits:
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        TextChosen = CursorPosition.StartGame;
                    else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        TextChosen = CursorPosition.GameMode;
                    break;

                case CursorPosition.GameMode:
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        TextChosen = CursorPosition.Credits;
                    else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        TextChosen = CursorPosition.StartGame;
                    break;

            }
        }

    }
}
