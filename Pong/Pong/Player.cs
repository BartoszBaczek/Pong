using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Player
    {
        public Texture2D Texture;
        public Vector2 Placement;
        public Vector2 Size;
        public Vector2 Speed;
        public Rectangle AllowedMoveField;

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
    }
}
