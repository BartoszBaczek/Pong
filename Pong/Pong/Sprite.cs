using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Placement;
        public Vector2 Size;
        public Vector2 Speed;
        private Rectangle AllowedMoveField;

        public Rectangle Border
        {
            get
            {
                return new Rectangle((int) Placement.X, (int) Placement.Y, (int) Size.X, (int) Size.Y);
            }
        }

        public Sprite(Texture2D texture, Vector2 placement, Vector2 size)
        {
            Texture = texture;
            Placement = placement;
            Size = size;
            Speed = new Vector2(0,0);
            AllowedMoveField = new Rectangle(0, 0, 0,0 );
        }

        public Sprite(Texture2D texture, Vector2 placement, Vector2 size, Rectangle allowedMoveField)
        {
            Texture = texture;
            Placement = placement;
            Size = size;
            Speed = new Vector2(8, 8);
            AllowedMoveField = allowedMoveField;
        }

        public void ChangePosition(float timeStep)
        {
            if (Placement.X + Size.X > AllowedMoveField.Right)              //
                Speed.X = -Speed.X;                                         // TODO Usunac ograniczenie z prawej i lewej strony;
            if (Placement.X < AllowedMoveField.Left)                        //
                Speed.X = - Speed.X;                                        //
            if (Placement.Y + Size.Y > AllowedMoveField.Bottom)             
                Speed.Y = - Speed.Y;                                        
            if (Placement.Y < AllowedMoveField.Top)
                Speed.Y = - Speed.Y;
            

            Placement += Speed * timeStep;
        }
    }
}
