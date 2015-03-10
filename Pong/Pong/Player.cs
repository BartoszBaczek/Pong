using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Player
    {
        public Texture2D Texture;
        public Vector2 Placement;
        public Vector2 Size;
        public Vector2 Speed;
        public Rectangle AllowedMoveField;
        public Rectangle Border
        {
            get
            {
                return new Rectangle((int)Placement.X, (int)Placement.Y, (int)Size.X, (int)Size.Y);
            }
        }

        public Player(Texture2D texture, Vector2 placement, Vector2 size, Rectangle allowedMoveField)
        {
            this.Texture = texture;
            this.Placement = placement;
            this.Size = size;
            this.AllowedMoveField = allowedMoveField;
        }

        public void ChangePosition(float timeStep)
        {
            if (Placement.Y + Speed.Y * timeStep + Size.Y > AllowedMoveField.Bottom)
                Speed.Y = 0;
            if (Placement.Y + Speed.Y * timeStep < AllowedMoveField.Top)
                Speed.Y = 0;

            Placement.Y += Speed.Y*timeStep;
        }

        public void PadSteering(float timeStep)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
                Speed.Y = -8;
            if (keyboardState.IsKeyDown(Keys.Down))
                Speed.Y = 8;

            ChangePosition(timeStep);

           Speed.Y = 0;
           Speed.X = 0;
        }

        public void CollisionControll(Sprite ball)
        {
            const float maxBounceAngle = (float) (5*Math.PI/12);

            if (Border.Intersects(ball.Border))
            {
                var relativeIntersectY = (Placement.Y + Size.Y / 2.0f) - (ball.Placement.Y + (ball.Size.Y / 2.0f));
                var normalizedRelativeIntersectY = relativeIntersectY / (Size.Y / 2.0f);
                var bounceAngle = normalizedRelativeIntersectY * maxBounceAngle;

                ball.Speed.X = (float) (ball.Speed.Length() * Math.Cos(bounceAngle));
                ball.Speed.Y = (float) (ball.Speed.Length() * Math.Sin(bounceAngle));

            }

        }
    }
}
