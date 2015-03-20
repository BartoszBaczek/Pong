#region Using Statements
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Pong
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont _scoreFont;

        Player gamePlayer1;
        Player gamePlayer2;
        Sprite gameBackground;
        Sprite gameBall;
        Bonus gameBonus1;
        Bonus gameBonus2;
        GameModeController gameModeController;

        Sprite menuBackground;
        Sprite menuOpenPong;
        Sprite menuStartGame;
        Sprite menuCredits;
        Sprite menuGameMode;
        Sprite menuEasy;
        Sprite menuMedium;
        Sprite menuHard;



        public const int ScreenWidth = 768;
        public const int GameFieldHeight = 512;
        public const int ScoreFieldHeight = 50;
        public const int ScreenHeight = GameFieldHeight + ScoreFieldHeight;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.ApplyChanges();

            Window.Title = "Pong";

        }

        protected override void Initialize()
        {
            gameModeController = new GameModeController(GameModeController.GameMode.Menu);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            {
                _scoreFont = Content.Load<SpriteFont>("RoboticFont");

                gameBackground = new Sprite(Content.Load<Texture2D>("Textures/GameTextures/background"), new Vector2(0f, ScoreFieldHeight), new Vector2(ScreenWidth, ScreenHeight - ScoreFieldHeight) );
                gameBall = new Sprite(Content.Load<Texture2D>("Textures/GameTextures/ball"), new Vector2(ScreenWidth / 2, GameFieldHeight / 2),
                    new Vector2(20, 20), new Rectangle(0, ScoreFieldHeight + 10, ScreenWidth, GameFieldHeight - 20));
                gamePlayer1 = new Player(Content.Load<Texture2D>("Textures/GameTextures/Pad"), new Vector2(40, ScoreFieldHeight + (GameFieldHeight / (float)2.0)), 
                    new Vector2(ScreenWidth * 0.03f, GameFieldHeight * 0.15f), new Rectangle(0, ScoreFieldHeight + 12, Convert.ToInt32(ScreenWidth * 0.1f), GameFieldHeight - 24 ), Keys.W, Keys.S, 1);
                gamePlayer2 = new Player(Content.Load<Texture2D>("Textures/GameTextures/Pad"), new Vector2(ScreenWidth - 40 - gamePlayer1.Size.X, ScoreFieldHeight + (GameFieldHeight / (float)2.0)), 
                    new Vector2(ScreenWidth * 0.03f, GameFieldHeight * 0.15f), new Rectangle(0, ScoreFieldHeight + 12, Convert.ToInt32(ScreenWidth * 0.1f), GameFieldHeight - 24 ), Keys.Up, Keys.Down, 2);
                gameBonus1 = new Bonus(Content.Load<Texture2D>("Textures/GameTextures/AccelerateBallicon"), new Vector2(30, 30), 1);
                gameBonus2 = new Bonus(Content.Load<Texture2D>("Textures/GameTextures/DeaccelerateBallIcon"), new Vector2(30, 30), 2);

                menuBackground = new Sprite(Content.Load<Texture2D>("MenuBackground"));
                menuCredits = new Sprite(Content.Load<Texture2D>("MenuCredits"));
                menuEasy = new Sprite(Content.Load<Texture2D>("MenuEasy"));
                menuMedium = new Sprite(Content.Load<Texture2D>("MenuMedium"));
                menuHard = new Sprite(Content.Load<Texture2D>("MenuHard"));
                menuGameMode = new Sprite(Content.Load<Texture2D>("MenuGameMode"));
                menuOpenPong = new Sprite(Content.Load<Texture2D>("MenuOpenPong"));
                menuStartGame = new Sprite(Content.Load<Texture2D>("MenuStartGame"));


            }

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameModeController.Mode == GameModeController.GameMode.Menu)
            {
                menuOpenPong.SetPosition((ScreenWidth - menuOpenPong.Size.X) / 2, 20);
                menuStartGame.SetPosition((ScreenWidth - menuStartGame.Size.X) / 2, menuOpenPong.Placement.Y + menuOpenPong.Size.Y + 80);
                menuCredits.SetPosition((ScreenWidth - menuCredits.Size.X) / 2, menuStartGame.Placement.Y + menuStartGame.Size.Y + 15);
                menuGameMode.SetPosition(50f, menuCredits.Placement.Y + menuCredits.Size.Y + 15);
                menuEasy.SetPosition(((ScreenWidth - menuEasy.Size.X) / 2) + 150, menuGameMode.Placement.Y);
                menuMedium.SetPosition(((ScreenWidth - menuMedium.Size.X) / 2) + 150, menuGameMode.Placement.Y);
                menuHard.SetPosition(((ScreenWidth - menuHard.Size.X) / 2) + 150, menuGameMode.Placement.Y);
            }

            if (gameModeController.Mode == GameModeController.GameMode.Game)
            {
                gameBall.ChangePosition((float) (gameTime.ElapsedGameTime.TotalMilliseconds/30));
                gamePlayer1.PadSteering((float) (gameTime.ElapsedGameTime.TotalMilliseconds/30));
                gamePlayer2.PadSteering((float) (gameTime.ElapsedGameTime.TotalMilliseconds/30));
                gamePlayer1.CollisionControll(gameBall);
                gamePlayer2.CollisionControll(gameBall);
                gameBall.UpdatePoints(gamePlayer1, gamePlayer2);
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
            if ((gameModeController.Mode == GameModeController.GameMode.Game))
            {
                spriteBatch.Draw(gameBackground.Texture, gameBackground.Border, Color.White);
                spriteBatch.Draw(gameBall.Texture, gameBall.Border, Color.White);
                spriteBatch.Draw(gamePlayer1.Texture, gamePlayer1.Border, Color.YellowGreen);
                spriteBatch.Draw(gamePlayer2.Texture, gamePlayer2.Border, Color.YellowGreen);
                spriteBatch.DrawString(_scoreFont, gamePlayer1.Points.ToString(),
                    new Vector2(100, (ScoreFieldHeight/2) - 24),
                    Color.DarkGreen);
                spriteBatch.DrawString(_scoreFont, gamePlayer2.Points.ToString(),
                    new Vector2(ScreenWidth - 100, (ScoreFieldHeight/2) - 24), Color.DarkGreen);
                if (gameBonus1.State == 1)
                    spriteBatch.Draw(gameBonus1.Texture, gameBonus1.Border, Color.White);
                if (gameBonus2.State == 1)
                    spriteBatch.Draw(gameBonus2.Texture, gameBonus2.Border, Color.White);
            }
            if ((gameModeController.Mode == GameModeController.GameMode.Menu))
            {
                spriteBatch.Draw(menuBackground.Texture, menuBackground.Border, Color.White);
                spriteBatch.Draw(menuCredits.Texture, menuCredits.Border, Color.White);
                spriteBatch.Draw(menuEasy.Texture, menuEasy.Border, Color.White);
                spriteBatch.Draw(menuMedium.Texture, menuMedium.Border, Color.White);
                spriteBatch.Draw(menuHard.Texture, menuMedium.Border, Color.White);
                spriteBatch.Draw(menuGameMode.Texture, menuGameMode.Border, Color.White);
                spriteBatch.Draw(menuOpenPong.Texture, menuOpenPong.Border, Color.White);
                spriteBatch.Draw(menuStartGame.Texture, menuStartGame.Border, Color.White);

            }

            spriteBatch.End();
            base.Draw(gameTime);
            }

            


        }
    }
