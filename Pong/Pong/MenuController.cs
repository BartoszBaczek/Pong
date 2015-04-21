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
        public CursorPosition TextChosen { get; set; }
        public CursorPosition PrevTextChosen { get; set; }


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

        KeyboardState prevKeyPressed;
        public void Navigate()
        {
            var keyPressed = Keyboard.GetState();
            

            switch (TextChosen)
            {
                case CursorPosition.StartGame:
                    if (keyPressed.IsKeyDown(Keys.Up) && prevKeyPressed.IsKeyUp(Keys.Up))
                        TextChosen = CursorPosition.GameMode;
                    else if (keyPressed.IsKeyDown(Keys.Down) && prevKeyPressed.IsKeyUp(Keys.Down))
                        TextChosen = CursorPosition.Credits;
                    break;
                case CursorPosition.Credits:
                    if (keyPressed.IsKeyDown(Keys.Up) && prevKeyPressed.IsKeyUp(Keys.Up))
                        TextChosen = CursorPosition.StartGame;
                    else if (keyPressed.IsKeyDown(Keys.Down) && prevKeyPressed.IsKeyUp(Keys.Down))
                        TextChosen = CursorPosition.GameMode;
                    break;
                case CursorPosition.GameMode:
                    if (keyPressed.IsKeyDown(Keys.Up) && prevKeyPressed.IsKeyUp(Keys.Up))
                        TextChosen = CursorPosition.Credits;
                    else if (keyPressed.IsKeyDown(Keys.Down) && prevKeyPressed.IsKeyUp(Keys.Down))
                        TextChosen = CursorPosition.StartGame;
                    break;
            }
            prevKeyPressed = keyPressed;

        }

    }
}
