using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Bonuses
    {
        private int BallAccelerated;
        private int BallDeaccelerated;

        public Bonuses()
        {
            BallAccelerated = 0;
            BallDeaccelerated = 0;
        }

        public void AccelerateBall(Sprite ball, float timeStep)
        {
            while ( timeStep <= 3)
            {
                
            }
            BallAccelerated = 1;

        }
    }
}
