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
        SpriteFont scoreFont;

        Player player1;
        Player player2;
        Sprite background;
        Sprite ball;
        Bonus bonus1;
        Bonus bonus2;

        GameModeChanger gameModeChanger;

        public const int ScreenWidth = 768;
        public const int GameFieldHeight = 512;
        public const int ScoreFieldHeight = 50;
        public const int ScreenHeight = GameFieldHeight + ScoreFieldHeight;


        public Game1()
            : base()
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            scoreFont = Content.Load<SpriteFont>("RoboticFont");

            background = new Sprite(Content.Load<Texture2D>("Textures/background"), new Vector2(0f, ScoreFieldHeight), new Vector2(ScreenWidth, ScreenHeight - ScoreFieldHeight) );

            ball = new Sprite(Content.Load<Texture2D>("Textures/ball"), new Vector2(ScreenWidth / 2, GameFieldHeight / 2),
                new Vector2(20, 20), new Rectangle(0, ScoreFieldHeight + 10, ScreenWidth, GameFieldHeight - 20));

            player1 = new Player(Content.Load<Texture2D>("Textures/Pad"), new Vector2(40, ScoreFieldHeight + (GameFieldHeight / (float)2.0)), 
                new Vector2(ScreenWidth * 0.03f, GameFieldHeight * 0.15f), new Rectangle(0, ScoreFieldHeight + 12, Convert.ToInt32(ScreenWidth * 0.1f), GameFieldHeight - 24 ), Keys.W, Keys.S, 1);
            player2 = new Player(Content.Load<Texture2D>("Textures/Pad"), new Vector2(ScreenWidth - 40 - player1.Size.X, ScoreFieldHeight + (GameFieldHeight / (float)2.0)), 
                new Vector2(ScreenWidth * 0.03f, GameFieldHeight * 0.15f), new Rectangle(0, ScoreFieldHeight + 12, Convert.ToInt32(ScreenWidth * 0.1f), GameFieldHeight - 24 ), Keys.Up, Keys.Down, 2);

            bonus1 = new Bonus(Content.Load<Texture2D>("Textures/AccelerateBallicon"), new Vector2(30, 30), 1);
            bonus2 = new Bonus(Content.Load<Texture2D>("Textures/DeaccelerateBallIcon"), new Vector2(30, 30), 2);

            gameModeChanger = new GameModeChanger();

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameModeChanger.GameMode == 1)
            {
                ball.ChangePosition((float) (gameTime.ElapsedGameTime.TotalMilliseconds/30));
                player1.PadSteering((float) (gameTime.ElapsedGameTime.TotalMilliseconds/30));
                player2.PadSteering((float) (gameTime.ElapsedGameTime.TotalMilliseconds/30));
                player1.CollisionControll(ball);
                player2.CollisionControll(ball);
                ball.UpdatePoints(player1, player2);
            }
            if (gameModeChanger.MenuMode == 1)
            {
                
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            if (gameModeChanger.GameMode == 1)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(background.Texture, background.Border, Color.White);
                spriteBatch.Draw(ball.Texture, ball.Border, Color.White);
                spriteBatch.Draw(player1.Texture, player1.Border, Color.YellowGreen);
                spriteBatch.Draw(player2.Texture, player2.Border, Color.YellowGreen);
                spriteBatch.DrawString(scoreFont, player1.Points.ToString(), new Vector2(100, (ScoreFieldHeight/2) - 24),
                    Color.DarkGreen);
                spriteBatch.DrawString(scoreFont, player2.Points.ToString(),
                    new Vector2(ScreenWidth - 100, (ScoreFieldHeight/2) - 24), Color.DarkGreen);
                if (bonus1.State == 1)
                    spriteBatch.Draw(bonus1.Texture, bonus1.Border, Color.White);
                if (bonus2.State == 1)
                    spriteBatch.Draw(bonus2.Texture, bonus2.Border, Color.White);
                spriteBatch.End();
            }
            else if (gameModeChanger.MenuMode == 1)
            {
                
            }
            

            base.Draw(gameTime);
        }
    }
}
