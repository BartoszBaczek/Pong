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
        Sprite background;
        Sprite ball;

        public const int screenWidth = 768;
        public const int screenHeight = 512;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.ApplyChanges();

            this.Window.Title = "Pong";

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new Sprite(Content.Load<Texture2D>("background"), new Vector2(0f, 0f), new Vector2(screenWidth, screenHeight) );
            ball = new Sprite(Content.Load<Texture2D>("ball"), new Vector2(screenWidth/2, screenHeight/2),
                new Vector2(20, 20), new Vector2(3,3), new Rectangle(0, 10, screenWidth, screenHeight - 20));
            player1 = new Player(Content.Load<Texture2D>("Pad"), new Vector2(10, screenHeight / 2), new Vector2(screenWidth * 0.03f, screenHeight * 0.09f), new Rectangle(0, 0, Convert.ToInt32(screenWidth * 0.03f), screenHeight));
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background.Texture, background.Border, Color.White);
            spriteBatch.Draw(ball.Texture, ball.Border, Color.White);
            spriteBatch.Draw();
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
