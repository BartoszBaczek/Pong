#region Using Statements
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        Player player1;
        Player player2;
        Sprite background;
        Sprite ball;

        public const int ScreenWidth = 768;
        public const int ScreenHeight = 512;

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

            background = new Sprite(Content.Load<Texture2D>("background"), new Vector2(0f, 0f), new Vector2(ScreenWidth, ScreenHeight) );

            ball = new Sprite(Content.Load<Texture2D>("ball"), new Vector2(ScreenWidth/2, ScreenHeight/2),
                new Vector2(20, 20), new Vector2(8,8), new Rectangle(0, 10, ScreenWidth, ScreenHeight - 20));

            player1 = new Player(Content.Load<Texture2D>("Pad"), new Vector2(40, ScreenHeight / (float)2.0), 
                new Vector2(ScreenWidth * 0.03f, ScreenHeight * 0.15f), new Rectangle(0, 12, Convert.ToInt32(ScreenWidth * 0.1f), ScreenHeight - 24 ), Keys.Up, Keys.Down, 1);
            player2 = new Player(Content.Load<Texture2D>("Pad"), new Vector2(ScreenWidth - 40 - ScreenWidth * 0.03f, ScreenHeight / (float) 2.0 ), 
                new Vector2(ScreenWidth * 0.03f, ScreenHeight * 0.15f), new Rectangle(0, 12, Convert.ToInt32(ScreenWidth * 0.1f), ScreenHeight - 24 ), Keys.W, Keys.S, 2);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ball.ChangePosition((float)(gameTime.ElapsedGameTime.TotalMilliseconds / 30));

            player1.PadSteering((float)(gameTime.ElapsedGameTime.TotalMilliseconds / 30));
            player2.PadSteering((float)(gameTime.ElapsedGameTime.TotalMilliseconds / 30));
            player1.CollisionControll(ball);
            player2.CollisionControll(ball);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background.Texture, background.Border, Color.White);
            spriteBatch.Draw(ball.Texture, ball.Border, Color.White);
            spriteBatch.Draw(player1.Texture, player1.Border, Color.White);
            spriteBatch.Draw(player2.Texture, player2.Border, Color.Blue);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
