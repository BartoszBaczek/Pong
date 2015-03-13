using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        public int State;
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
            State = 0;
        }

        public Vector2 SetRandomPosition()
        {
            var randomXdouble = new Random();
            var randomYdouble = new Random();
            
            var positionX = randomXdouble.NextDouble() * (Game1.ScreenWidth - 40) + 40;
            var positionY = randomYdouble.NextDouble()*(Game1.ScreenHeight - 40) + 40;

            return new Vector2((float) positionX, (float) positionY);
        }

        public void TryToAppear()
        {
            var randomNumber = new Random();

            float myNumber = (float) (randomNumber.NextDouble() * 10.0f);

            if (myNumber <= 0.05)
                State = 1;
            else if (myNumber >= 9.99)          //
                State = 0;                      //  TODO Usunac warunek na usuniecie, a zastapic go stalym czasem istnieneia bonusu

        }

    }
}
