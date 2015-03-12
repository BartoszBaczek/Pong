using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Bonus
    {

        public int BonusType;                                                             //1. Accelerate ball 2. Deaccelerate ball
        public Texture2D Texture;
        public Vector2 Placement;
        public Vector2 Size;
        public Rectangle Border
        {
            get
            {
                return new Rectangle((int)Placement.X, (int)Placement.Y, (int)Size.X, (int)Size.Y);
            }
        }

        public Bonus(Texture2D texture, Vector2 size, int bonusType)
        {
            Texture = texture;  
            Size = size;
            BonusType = bonusType;
            Placement = SetRandomPosition();
        }

        public Vector2 SetRandomPosition()
        {
            var randomXdouble = new Random();
            var randomYdouble = new Random();
            
            double positionX = randomXdouble.NextDouble() * Game1.ScreenWidth;
            double positionY = randomYdouble.NextDouble() * Game1.ScreenHeight;

            return Placement = new Vector2((float) positionX, (float) positionY);


        }
    }
}
