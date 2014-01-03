using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadgerBadgerBadger
{
    class Snake : MovableObject
    {
        public Snake(Texture2D snakeImage)
            : base(new Rectangle(1300, 0, 100, 50), 1)
        {
            Image = snakeImage;
            speed = 7;
            gravity = true;
            gravAccel = 0;
            this.Destination = new Rectangle(40, 19, 756, 511);
        }
   }
}
